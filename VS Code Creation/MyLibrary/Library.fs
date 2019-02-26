namespace MyLibrary

module ExchangeRate =
    type ExchangeRate =
        { CurrencyFrom : string
          CurrencyTo : string
          ExchangeRate : float32 }

    let rates = Set.ofArray [| { CurrencyFrom = "SWE"; CurrencyTo = "EUR"; ExchangeRate = 10.02345f } |]

    let exchange currencyFrom currencyTo amount =
        let rate = rates |> Seq.find(fun e -> e.CurrencyFrom = currencyFrom && e.CurrencyTo = currencyTo)
        amount * rate.ExchangeRate       
     
