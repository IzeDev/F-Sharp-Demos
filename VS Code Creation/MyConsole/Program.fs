module Program
    open System
    [<EntryPoint>]
    let main argv =
        let x = Console.ReadLine() |> Decimal.TryParse
        0
