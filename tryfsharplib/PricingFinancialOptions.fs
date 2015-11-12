namespace tryfsharplib

open System
open MathNet.Numerics.Distributions
open MathNet.Numerics.Statistics
open FSharp.Data

module EuroValue = 
    let call exercisePrice actualPrice = max (actualPrice - exercisePrice) 0.0
    let put exercisePrice actualPrice = max (exercisePrice - actualPrice) 0.0
    
    // Calculate the payoff of a given option 
    let optionPayoff option = 
        seq { 
            for p in 0.0..10.0..100.0 -> p, option p
        }

type PricingFinancialOptions(price : float) = 
    // Compare the payoff of call and put options
    let callPayoff = EuroValue.optionPayoff (EuroValue.call price)
    let putPayoff = EuroValue.optionPayoff (EuroValue.put price)
    member this.PutPayoff = putPayoff
    member this.CallPayoff = callPayoff

type BottomStraddle(exercisePrice : float) = 
    let bottomStraddle exercisePrice actualPrice = 
        (EuroValue.call exercisePrice actualPrice) + (EuroValue.put exercisePrice actualPrice)
    let payoff = EuroValue.optionPayoff (bottomStraddle exercisePrice)
    member this.Payoff = payoff

type ButterflySpread(lowPrice, highPrice : float) = 
    let butterflySpread lowPrice highPrice actualPrice = 
        (EuroValue.call lowPrice actualPrice) + (EuroValue.call highPrice actualPrice) 
        - 2.0 * (EuroValue.call ((lowPrice + highPrice) / 2.0) actualPrice)
    let payoff = EuroValue.optionPayoff (butterflySpread lowPrice highPrice)
    member this.Payoff = payoff

module SimulatingAndAnalyzingAssetPrices = 
    type RandomWalk(price : float) = 
        let sample = Normal(0.0, 2.0).Sample()
        
        // Generate random walk from 'value' recursively
        let rec randomWalk price = 
            seq { 
                yield price
                yield! randomWalk (price + sample)
            }
        
        let rw = randomWalk 10.0 |> Seq.take 100
        let a = seq { 1.0..100.0 }
        let prices = Seq.zip a rw
        
        // Generate price using geometric Brownian motion
        let randomPrice drift volatility dt initial (dist : Normal) = 
            // Calculate parameters of the exponential
            let driftExp = (drift - 0.5 * pown volatility 2) * dt
            let randExp = volatility * (sqrt dt)
            
            // Recursive loop that actually generates the price
            let rec loop price = 
                seq { 
                    yield price
                    let price = price * exp (driftExp + randExp * dist.Sample())
                    yield! loop price
                }
            // Return path starting at 'initial'
            loop initial
        
        // Create normal distribution and test the model
        let dist = Normal(0.0, 1.0, RandomSource = Random(100))
        let dist1 = Normal(0.0, 1.0, RandomSource = Random(100))
        let dist2 = Normal(0.0, 1.0, RandomSource = Random(100))
        // Vary the parameters between 0.01 to 0.10
        let drift1, vol1 = 0.05, 0.10
        let drift2, vol2 = 0.05, 0.10
        let rp = randomPrice 0.05 0.05 0.005 5.0 dist
        let rp1 = randomPrice drift1 vol1 0.005 5.0 dist1
        let rp2 = randomPrice drift2 vol2 0.005 5.0 dist2
        let rpSeq = Seq.take 100 rp
        let rpSeq1 = Seq.take 100 rp1
        let rpSeq2 = Seq.take 100 rp2
        let brownianSeq = Seq.zip a rpSeq
        let brownianSeq1 = Seq.zip a rpSeq1
        let brownianSeq2 = Seq.zip a rpSeq2
        let msft2014Url = new ChartingAndComparingPrices.UrlConstructor("MSFT", (DateTime(2014, 1, 1)), DateTime.Now)
        let msft2014 = msft2014Url.LoadCsvFromUrl
        let first = msft2014.Rows |> Seq.minBy (fun itm -> itm.Date)
        let firstClose = float first.Close
        
        /// Generates prices that can be compared with 'msft2014' data
        let simulateHistoricalPrices drift volatility = 
            let dist = Normal(0.0, 1.0)
            
            let dates = 
                [ for v in msft2014.Rows -> v.Date ]
                |> List.rev
            
            let randoms = randomPrice drift volatility 0.005 firstClose dist
            Seq.zip dates randoms
        
        let msft2014Actual = 
            let dates = 
                [ for v in msft2014.Rows -> v.Date ]
                |> List.rev
            
            let prices = 
                [ for v in msft2014.Rows -> float v.Close ]
                |> List.rev
            
            Seq.zip dates prices
        
        // used to find historical drift / volatility
        let logRatios = 
            msft2014.Rows
            |> Seq.sortBy (fun v -> v.Date)
            |> Seq.pairwise
            |> Seq.map (fun (prev, next) -> log (float next.Close / float prev.Close))
        
        // Use Math.NET to obtain descriptive statistics
        let stats = DescriptiveStatistics(logRatios)
        // Represents one day in a year with 252 trading days
        let tau = 1.0 / 252.0
        // Calculate volatility and drift from the above equations
        let volatilityMsft = sqrt (stats.Variance / tau)
        let driftMsft = (stats.Mean / tau) + (pown volatilityMsft 2) / 2.0
        // Obtain generated and real data
        let generated = simulateHistoricalPrices driftMsft volatilityMsft

        member this.Rw = rw
        member this.Prices = prices
        member this.BrownianSeq = brownianSeq
        member this.BrownianSeq1 = brownianSeq1
        member this.BrownianSeq2 = brownianSeq2
        member this.MsftSimulated = simulateHistoricalPrices 0.05 0.1
        member this.MsftActual = msft2014Actual
        member this.MsftHistoricalSimulated = generated

module PricingEuropeanOptions = 
    /// Option can be either Call or Put option
    type OptionType = 
        | Call
        | Put
    
    /// Represents information about European option, time to expiry in years
    type OptionInfo = 
        { ExercisePrice : float
          TimeToExpiry : float
          Kind : OptionType }
    
    /// Represents price and statistics about stock 
    type StockInfo = 
        { Volatility : float
          CurrentPrice : float }
    
    let getStockProperties name = 
        { // TODO: Obtain real stock data 
          CurrentPrice = 26.96
          Volatility = 0.2076 }
    
    // Used to get the cumulative distribution function
    let normal = Normal()
    
    type BlackScholes() = 
        
        /// Calculates the price of 'option' for a given 'stock' and 
        /// a global interest 'rate' using the Black-Scholes equation
        let blackScholes rate stock option = 
            // We can only calculate if the option concerns the future
            if option.TimeToExpiry > 0.0 then 
                // Calculate d1 and d2 and pass them to cumulative distribution
                let d1 = 
                    (log (stock.CurrentPrice / option.ExercisePrice) 
                     + (rate + 0.5 * pown stock.Volatility 2) * option.TimeToExpiry) 
                    / (stock.Volatility * sqrt option.TimeToExpiry)
                let d2 = d1 - stock.Volatility * sqrt option.TimeToExpiry
                let N1 = normal.CumulativeDistribution(d1)
                let N2 = normal.CumulativeDistribution(d2)
                // Calculate the call option (and derived put option) price
                let e = option.ExercisePrice * exp (-rate * option.TimeToExpiry)
                let call = stock.CurrentPrice * N1 - e * N2
                match option.Kind with
                | Call -> call
                | Put -> call + e - stock.CurrentPrice
            else 
                // If the option has expired, calculate payoff directly
                match option.Kind with
                | Call -> max (stock.CurrentPrice - option.ExercisePrice) 0.0
                | Put -> max (option.ExercisePrice - stock.CurrentPrice) 0.0
        
        // Get information about the stock and create sample option
        let msftStock = getStockProperties "MSFT"
        
        let msftOption = 
            { ExercisePrice = 30.0
              TimeToExpiry = 1.0
              Kind = Call }
        
        // Calculate the option value
        let bs = blackScholes 0.05 msftStock msftOption
        
        /// Generates an array with options of varying price
        let varyPrice option = 
            [| for price in 0.0..5.0..200.0 -> { option with ExercisePrice = price } |]
        
        /// Generates an array with varying times; the element
        /// of the array contains the time and a nested array
        /// containing options with varying prices
        let timePriceOptions = 
            seq { 
                for time in 0.0..0.5..10.0 -> 
                    let option = 
                        { ExercisePrice = 0.0
                          TimeToExpiry = time
                          Kind = Call }
                    time, varyPrice option
            }
        
        let timePriceValues = 
            // Iterate over all data 'lines' (with different time to expiry)
            timePriceOptions |> Seq.map (fun (time, options) -> 
                                    // Iterate over all options (with different exercise price)
                                    options |> Seq.map (fun option -> 
                                                   // Price the option using Black-Scholes
                                                   option.ExercisePrice, blackScholes 0.05 msftStock option))

        member this.TimePriceValues = timePriceValues
//    let bsPrices = for prices in timePriceValues -> Array.toSeq prices
