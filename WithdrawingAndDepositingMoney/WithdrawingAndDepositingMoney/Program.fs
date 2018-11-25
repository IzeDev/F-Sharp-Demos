
open System
open Domain
open Operations

let mutable bankAccount = { CurrentBalance = 0m }

let getInitialBalance =
    printfn "Please open a bank account with your first"

[<EntryPoint>]
let main argv =
    0 // return an integer exit code
