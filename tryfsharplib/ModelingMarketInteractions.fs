namespace tryfsharplib

open System
open MathNet.Numerics
open MathNet.Numerics.LinearAlgebra.Double
open MathNet.Numerics.LinearAlgebra

module AnalyzingStockMarkets = 
    type GetStockMarketIndicators () = 
        // Names of stock market indicators
        let names = 
          [|"AORD"; "FCHI"; "FTSE"; "MERV"; "MXX"; "NDX" |]

        let indicators = 
          [| for name in names ->
               let data = new ChartingAndComparingPrices.CsvConstructor(("^" + name), DateTime(2015,1,1), DateTime.Now )
               name, Async.RunSynchronously(data.loadMarketCsvFromUrl()).Rows |]

        let chartData =  
                seq {
                for name, index in indicators -> name, seq {for item in index -> item.Date.DayOfYear, item.Close }
            }
 
        // Dates when data for all indices are available
        let commonDates = 
          [ for name, index in indicators -> 
              // Return a set with available dates for the current index
              set [ for item in index -> item.Date ] ]
          |> Set.intersectMany

        // Create a matrix with historical data for available dates
        let historicalData = 
          [ for name, index in indicators ->
              [ for item in index do
                  if commonDates.Contains item.Date then
                    yield item.Close ] ] |> matrix

        member this.ChartData = chartData 