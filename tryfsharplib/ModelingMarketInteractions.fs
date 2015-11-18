namespace tryfsharplib

open System
open MathNet.Numerics
open MathNet.Numerics.LinearAlgebra.Double
open MathNet.Numerics.LinearAlgebra

module AnalyzingStockMarkets = 
          /// Represents the results of single iteration 
    type KalmanResult = 
      { LogLikelihood : float 
        Values : Vector<float> list
        Variances : Matrix<float> list }

        /// Updates the state after a single iteration
        /// (the loglik value is added to the log likelihood,
        /// and 'value' with 'variance' are added to lists)
        member x.Update(loglik, value, variance) =
            { LogLikelihood = x.LogLikelihood + loglik
              Values = value::x.Values
              Variances = variance::x.Variances }

        /// Reverse the accumulated values and variances
        member x.Reverse() =
            { x with Values = List.rev x.Values
                     Variances = List.rev x.Variances }

        /// Initial result with no values and 0 likelihood              
        static member Initial = 
            { LogLikelihood = 0.0
              Values = []; Variances = []; }

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
                for name, index in indicators -> name, seq {for item in index -> double(item.Date.DayOfYear), double(item.Close) }
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
                    yield double(item.Close) ] ] |> matrix

        // Split the data into training set and validation set
        let observedData, futureData = 
          let trainingT = historicalData.ColumnCount * 2 / 3
          historicalData.[0 .. , .. trainingT], 
          historicalData.[0 .. , trainingT + 1 .. ]

        // Size of the observedData matrix for future use
        let observedCount = observedData.ColumnCount  
        let indexCount = observedData.RowCount

        // Identity matrix of size indexCount*indexCount
        let idMatrix = 
          [ for i in 0 .. indexCount - 1 ->
              [ for j in 0 .. indexCount - 1 ->
                  if i = j then 1.0 else 0.0 ] ] |> matrix

        // Compute two diagonal matrices with the noise
        let noise = 0.01
        let noiseQ = noise * idMatrix
        let noiseR = noise * idMatrix

        // Corrects the given matrix to ensure it is symmetric
        let symmetrize (m:Matrix<float>) = 
          (m + m.Transpose()).Divide(2.0)

        // Calculates the change of the log likelihood after an update.
        // Estimates the likelihood of the actual 'observedValue' with respect 
        // to our 'projectedValue' given 'projectedVar' variance
        let logLikelihoodChange (observedValue:Vector<float>) (projectedValue:Vector<float>) projectedVar =
          // Projected probability with added noise
          let S:Matrix<float> = projectedVar + noiseR
          // Calculate log likelihood change
          let d = observedValue - projectedValue 
          -(float indexCount)*0.5*log(2.0*Math.PI) 
          - 0.5*log(S.Determinant()) - 0.5*(d * S.Inverse())*d

                        /// Calculates values projected by the Kalman filter model
        let rec kalmanFilter timeStep (results:KalmanResult) 
                             (dynamics:Matrix<_>) =
          if timeStep = observedCount then 
            // Return finalized results after completion
            results.Reverse()
          else
            // Get previous value and variance (start with the
            // first value from the data set and just noise)
            let pastValue, pastVar = 
              if timeStep = 0 then observedData.Column(0), noiseQ
              else List.head results.Values, List.head results.Variances

            // Calculate projected value and its variance
            let projectedValue = dynamics * pastValue
            let projectedVar = dynamics * pastVar * dynamics.Transpose() + noiseQ

            // Calculate 'Kalman gain' and update the values using observed data
            let observedValue = observedData.Column(timeStep)
            let kalmanGain = projectedVar * (projectedVar + noiseR).Inverse()
            let update = kalmanGain * (observedValue - projectedValue)
            let nextValue = projectedValue + update
            let nextVar = projectedVar - kalmanGain * projectedVar |> symmetrize

            // Compute the state for the next step of the iteration
            let logChange = logLikelihoodChange observedValue projectedValue projectedVar 
            let results = results.Update(logChange, nextValue, nextVar)
            kalmanFilter (timeStep + 1) results dynamics


        member this.ChartData = chartData 
        member this.HistoricalData = historicalData


        