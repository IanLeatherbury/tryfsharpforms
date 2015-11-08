namespace tryfsharplib

open System

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

    let payoff = EuroValue.optionPayoff(bottomStraddle exercisePrice)

    member this.Payoff = payoff 

type ButterflySpread(exercisePrice, actualPrice : decimal) = 
        let butterflySpread lowPrice highPrice actualPrice = 
            (EuroValue.call lowPrice actualPrice) + (EuroValue.call highPrice actualPrice) 
            - 2.0 * (EuroValue.call ((lowPrice + highPrice) / 2.0) actualPrice)
