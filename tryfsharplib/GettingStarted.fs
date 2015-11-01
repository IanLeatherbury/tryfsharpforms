namespace tryfsharplib

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

    type ConvertUsdEur(rate : decimal<EUR/USD>, value : decimal<USD>) =

        let convertUsdEur = rate * value

        member this.Convert = convertUsdEur

    type ConvertUsdJpy(rate : decimal<JPY/USD>, value : decimal<USD>) = 

        let convertUsdJpy = rate * value

        member this.Convert = convertUsdJpy
