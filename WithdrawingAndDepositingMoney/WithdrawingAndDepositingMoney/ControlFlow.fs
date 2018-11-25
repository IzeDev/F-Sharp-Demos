module ControlFlow

open System

module Private =
    let rec getInitialBankAccountBalane(valueGetter) =
        let message = "Please state your initial balance"
        let value : string = valueGetter(message)

        let isSuccess, decimalValue = Decimal.TryParse value

        if isSuccess then decimalValue
        else getInitialBankAccountBalane valueGetter



let startFlow valueGetter =
    let initialValue = Private.getInitialBankAccountBalane valueGetter
        

    0