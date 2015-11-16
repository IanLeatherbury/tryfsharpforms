namespace tryfsharplib

open FSharp.Data
open MathNet.Numerics.Statistics
open MathNet.Numerics.Distributions
open System

// Ported from http://www.tryfsharp.org/Learn/financial-computing
module ConvertCurrency = 
    type ConvertCurrency(rate : decimal, value : decimal) = 
        let convertedCurrency = rate * value
        member this.ConvertedCurrency = convertedCurrency

module UnitsOfMeasure = 
    [<Measure>]
    type USD
    
    [<Measure>]
    type EUR
    
    [<Measure>]
    type JPY
    
    type ConvertUsdEur(rate : decimal<EUR / USD>, value : decimal<USD>) = 
        let convertUsdEur = rate * value
        member this.Convert = convertUsdEur
    
    type ConvertUsdJpy(rate : decimal<JPY / USD>, value : decimal<USD>) = 
        let convertUsdJpy = rate * value
        member this.Convert = convertUsdJpy

module ExploringHistoricalStockPrices = 
    [<Measure>]
    type USD
    
    [<Measure>]
    type EUR
    
    type Stocks = CsvProvider< "table.csv" >
    
    type Charting(days : float) = 
        let msft = Stocks.Load("http://ichart.finance.yahoo.com/table.csv?s=MSFT")
        
        //use seq {} instead of List to expose IEnumberable in C# PCL
        // Get Dates/Prices
        let recentDatePrice = 
            seq { 
                for row in msft.Rows do
                    if row.Date > System.DateTime.Now.AddDays(-days) then yield row.Date, row.Close
            }

        //Get prices only
        let recentPrices = 
            seq { 
                for row in msft.Rows do
                    if row.Date > System.DateTime.Now.AddDays(-days) then yield float row.Close
            }
        
        //Get prices typed with units of measure
        let recentPricesTyped = 
            seq<decimal<USD>> { 
                for row in msft.Rows do
                    if row.Date > System.DateTime.Now.AddDays(-30.0) then yield row.Close * 1.0M<USD>
            }
        
        member this.RecentDatePrice = recentDatePrice
        member this.RecentPricesOnly = recentPrices
        member this.RecentPricesTyped = recentPricesTyped

module AnalyzingStockPrices = 
    [<Measure>]
    type USD
    
    [<Measure>]
    type EUR
    
    type StandardDeviationWithoutUnits() = 

        //Use a 30 days for basic example
        let charting = ExploringHistoricalStockPrices.Charting(30.0)

        // Get count and average price
        let count = Seq.length charting.RecentPricesOnly
        let avg = Seq.average charting.RecentPricesOnly
        
        // Calculate squares of differences
        let squares = 
            [ for p in charting.RecentPricesOnly -> ((p - avg) * (p - avg)) ]
        
        // Divide sum of squares by count and get square root
        member this.StandardDev = sqrt ((Seq.sum squares) / (float count))
    
    type StandardDeviationWithUnits() = 
        //Use a 30 days for basic example
        let charting = ExploringHistoricalStockPrices.Charting(30.0)
        // Get count and average price
        let count = Seq.length charting.RecentPricesOnly
        let avg = Seq.average charting.RecentPricesOnly
        
        // Calculate squares of differences
        let squares = 
            [ for p in charting.RecentPricesOnly -> ((p - avg) * (p - avg)) ]
        
        // Divide sum of squares by count and get square root
        member this.StandardDev = sqrt ((Seq.sum squares) / (float count))
    
    type StandardDeviationMath() = 
        let charting = ExploringHistoricalStockPrices.Charting(30.0)
        //Obtain statistical information
        let stats = DescriptiveStatistics(charting.RecentPricesOnly)
        // Evaluate the following lines to see the result
        member this.StandardDev = stats.StandardDeviation
        member this.Mean = stats.Mean
        member this.Min = stats.Minimum
        member this.Max = stats.Maximum

module ChartingAndComparingPrices = 

    //strongly type CSV. moved here for convenience.
    type Stocks = CsvProvider< "table.csv" >
    type Markets = CsvProvider< "marketTable.csv" >
        
    type CsvConstructor(ticker : string, startDate : DateTime, endDate : DateTime) = 
        
        // Helper method that returns a Yahoo! URL for specified stock and date range
        let urlForDates ticker (startDate : DateTime) (endDate : DateTime) = 
            let root = "http://ichart.finance.yahoo.com/table.csv"
            sprintf "%s?s=%s&a=%i&b=%i&c=%i&d=%i&e=%i&f=%i" root ticker (startDate.Month - 1) startDate.Day 
                startDate.Year (endDate.Month - 1) endDate.Day endDate.Year

        let urlFor ticker = 
            let root = "http://ichart.finance.yahoo.com/table.csv"
            sprintf "%s?s=%s&" root ticker
   
        //loads CSV for typing
        let stockCsv (ticker : string, startDate : DateTime) =
            Stocks.Load(urlForDates ticker startDate System.DateTime.Now) 

        member this.LoadStockCsv = stockCsv

        member this.LoadCsvFromUrl() =
            this.loadCsvFromUrl()
            |> Async.StartAsTask

        member internal this.loadCsvFromUrl() =
            async {
                let! data = Stocks.AsyncLoad(urlForDates ticker startDate endDate) 
                return data }

        member internal this.loadMarketCsvFromUrl() = 
            async {
                let! data = Markets.AsyncLoad(urlForDates ticker startDate endDate) 
                return data }
    
    type ComparingStocks(tick : string, startDate : DateTime, endDate : DateTime) = 

        let tickerRows = CsvConstructor(tick, startDate, endDate).LoadStockCsv(tick, startDate).Rows

        let recentDatePrice = 
            [
                for row in tickerRows do
                    if row.Date > startDate then yield row.Date, row.Close
            ] |> List.rev |> List.toSeq
        

        let stats = 
            DescriptiveStatistics(seq<float> { 
                                      for row in tickerRows do
                                          if row.Date > System.DateTime.Now.AddDays(-30.0) then yield float row.Close
                                  })
        
        let avg = 
            seq { 
                for row in tickerRows do
                    if row.Date > startDate then yield row.Date, decimal stats.Mean
            }
        
        member this.Stocks = recentDatePrice 
        member this.Average = avg                               