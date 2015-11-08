namespace tryfsharplib

open FSharp.Data
open MathNet.Numerics.Statistics
open System

// Ported from http://www.tryfsharp.org/Learn/financial-computing
module ConvertCurrency = 
    type ConvertCurrency(rate : decimal, value : decimal) = 
        let convertedCurrency = rate * value
        member this.X = "F#"
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
    
    type Charting() = 
        let msft = Stocks.Load("http://ichart.finance.yahoo.com/table.csv?s=MSFT")
        
        //use seq {} instead of List to expose IEnumberable in C# PCL
        let recentDatePrice = 
            seq { 
                for row in msft.Rows do
                    if row.Date > System.DateTime.Now.AddDays(-30.0) then yield row.Date, row.Close
            }
        
        let recentPrices = 
            seq { 
                for row in msft.Rows do
                    if row.Date > System.DateTime.Now.AddDays(-30.0) then yield float row.Close
            }
        
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
        let charting = ExploringHistoricalStockPrices.Charting()
        // Get count and average price
        let count = Seq.length charting.RecentPricesOnly
        let avg = Seq.average charting.RecentPricesOnly
        
        // Calculate squares of differences
        let squares = 
            [ for p in charting.RecentPricesOnly -> ((p - avg) * (p - avg)) ]
        
        // Divide sum of squares by count and get square root
        member this.StandardDev = sqrt ((Seq.sum squares) / (float count))
    
    type StandardDeviationWithUnits() = 
        let charting = ExploringHistoricalStockPrices.Charting()
        // Get count and average price
        let count = Seq.length charting.RecentPricesOnly
        let avg = Seq.average charting.RecentPricesOnly
        
        // Calculate squares of differences
        let squares = 
            [ for p in charting.RecentPricesOnly -> ((p - avg) * (p - avg)) ]
        
        // Divide sum of squares by count and get square root
        member this.StandardDev = sqrt ((Seq.sum squares) / (float count))
    
    type StandardDeviationMath() = 
        let charting = ExploringHistoricalStockPrices.Charting()
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
    
    type UrlConstructor() = 
        
        // Helper method that returns a Yahoo! URL for specified stock and date range
        let urlForDates ticker (startDate : DateTime) (endDate : DateTime) = 
            let root = "http://ichart.finance.yahoo.com/table.csv"
            sprintf "%s?s=%s&a=%i&b=%i&c=%i&d=%i&e=%i&f=%i" root ticker (startDate.Month - 1) startDate.Day 
                startDate.Year (endDate.Month - 1) endDate.Day endDate.Year
        
        let urlFor ticker = 
            let root = "http://ichart.finance.yahoo.com/table.csv"
            sprintf "%s?s=%s&" root ticker
        
        let stockCsv (ticker : string) = Stocks.Load(urlFor ticker)
        member this.LoadStock = stockCsv
    
    type ComparingStocks(ticker : string) = 
        let tickerRows = UrlConstructor().LoadStock(ticker).Rows
        
        let recentDatePrice = 
            seq { 
                for row in tickerRows do
                    if row.Date > System.DateTime.Now.AddDays(-30.0) then yield row.Date, row.Close
            }
        
        let stats = 
            DescriptiveStatistics(seq<float> { 
                                      for row in tickerRows do
                                          if row.Date > System.DateTime.Now.AddDays(-30.0) then yield float row.Close
                                  })
        
        let avg = seq { for row in tickerRows do
                                if row.Date > System.DateTime.Now.AddDays(-30.0) then yield row.Date, decimal stats.Mean }
        
        let avgBy = Seq.averageBy snd recentDatePrice 

        member this.Stocks = recentDatePrice
        member this.AverageBy = avgBy
        member this.Average = avg
//        let msft2012ToPresent = stockData "MSFT" (DateTime(2012,1,1)) DateTime.Now
//        let msftMostRecent = msft2012ToPresent.Data |> Seq.head