namespace tryfsharplib

open System
open MathNet.Numerics.Distributions
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

        let a = seq {1.0 .. 100.0}

        let prices = Seq.zip a rw

        // Generate price using geometric Brownian motion
        let randomPrice drift volatility dt (initial) (dist:Normal) = 
            // Calculate parameters of the exponential
            let driftExp = (drift - 0.5 * pown volatility 2) * dt
            let randExp = volatility * (sqrt dt)

            // Recursive loop that actually generates the price
            let rec loop price = seq {
                yield price
                let price = price * exp (driftExp + randExp * dist.Sample()) 
                yield! loop price }

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


        let msft2014Url = new ChartingAndComparingPrices.UrlConstructor("MSFT", (DateTime(2014,1,1)), DateTime.Now)
        let msft2014 = msft2014Url.UrlForDates

        let first = msft2014.Rows |> Seq.minBy(fun itm -> itm.Date)
        let firstClose = float first.Close
        
        /// Generates prices that can be compared with 'msft2014' data
        let simulateHistoricalPrices drift volatility = 
            let dist = Normal(0.0, 1.0)
            let dates = [ for v in msft2014.Rows -> v.Date ] |> List.rev
            let randoms = randomPrice drift volatility 0.005 firstClose dist
            Seq.zip dates randoms

        let msft2014Actual = 
            let dates = [ for v in msft2014.Rows -> v.Date ] |> List.rev
            let prices = [ for v in msft2014.Rows -> float v.Close ] |> List.rev
            Seq.zip dates prices

        member this.Rw = rw
        member this.Prices = prices

        member this.BrownianSeq = brownianSeq
        member this.BrownianSeq1 = brownianSeq1
        member this.BrownianSeq2 = brownianSeq2

        member this.MsftSimulated = simulateHistoricalPrices 0.05 0.1
        member this.MsftActual = msft2014Actual 