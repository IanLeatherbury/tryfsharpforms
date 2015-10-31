namespace tryfsharplib

    type ConvertCurrency(rate : decimal, value : decimal) =

        let convertedCurrency = rate * value

        member this.X = "F#"

        member this.ConvertedCurrency = convertedCurrency
