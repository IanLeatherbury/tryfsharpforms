namespace tryfsharplib

open System
open MathNet.Numerics
open MathNet.Numerics.LinearAlgebra.Double

module AnalyzingStockMarkets = 
    type GetStockMarketIndicators () = 
        // Names of stock market indicators
        let names = 
          [|"AORD"; "FCHI"; "FTSE"; "GSPTSE"; "MERV"; "MXX"; "NDX" |]

        let indicators = 
          [| for name in names ->
               let data = new ChartingAndComparingPrices.CsvConstructor(("^" + name), DateTime(2015,1,1), DateTime.Now )
               name, Async.RunSynchronously(data.loadMarketCsvFromUrl()).Rows |]

        let chartData =  
                seq {
                for name, index in indicators -> name, seq {for item in index -> item.Date.DayOfYear, item.Close }
            }

        member this.ChartData = chartData