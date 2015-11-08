namespace tryfsharplib

open System

type PricingFinancialOptions(price : float) = 
    let euroCallValue exercisePrice actualPrice = max (actualPrice - exercisePrice) 0.0
    let euroPutValue exercisePrice actualPrice = max (exercisePrice - actualPrice) 0.0
    
    // Calculate the payoff of a given option 
    let optionPayoff option = 
        seq { 
            for p in 0.0..10.0..100.0 -> p, option p
        }
    
    // Compare the payoff of call and put options
    let callPayoff = optionPayoff (euroCallValue price)
    let putPayoff = optionPayoff (euroPutValue price)

    member this.CallPayoff = callPayoff
    member this.PutPayoff = putPayoff
