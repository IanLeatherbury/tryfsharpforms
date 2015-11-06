namespace tryfsharplib

open FSharp.Data

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
    type [<Measure>] USD
    type [<Measure>] EUR

    type Stocks = CsvProvider< "table.csv" >
    
    type Charting() = 
        let msft = Stocks.Load("http://ichart.finance.yahoo.com/table.csv?s=MSFT")
        let firstRow = msft.Rows |> Seq.head
        let lastDate = firstRow.Date
        let lastOpen = firstRow.Open
        
        //use seq {} instead of List to expose IEnumberable in C# PCL
        let recentPricesWithDates = 
            seq { 
                for row in msft.Rows do
                    if row.Date > System.DateTime.Now.AddDays(-30.0) then yield row.Date, row.Close
            }
        
        let recentPricesOnly = 
            seq { 
                for row in msft.Rows do
                    if row.Date > System.DateTime.Now.AddDays(-30.0) then yield float row.Close
            }
        
        let recentPricesTyped = 
            seq<float<USD>> { 
                for row in msft.Rows do
                    if row.Date > System.DateTime.Now.AddDays(-30.0) then yield float<USD> row.Close
            }

        member this.RecentPricesWithDates = recentPricesWithDates
        member this.RecentPricesOnly = recentPricesOnly

module AnalyzingStockPrices = 
    type [<Measure>] USD
    type [<Measure>] EUR

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
        
        
        