// Learn more about F# at http://fsharp.org

open System
open Domain
open Operations
open Auditing

// Audits
let consoleDepositAudit = consoleAudit "deposit"
let consoleWithdrawAudit = consoleAudit "withdraw"    

[<EntryPoint>]
let main argv =
    printfn "Please type your name and press enter. Then type your initial balance and press enter."
    let  mutable customer = 
        {
            Name = Console.ReadLine();
            Account = 
            {
                Balance = Console.ReadLine() |> Decimal.Parse
            }
        }

    let performOperation decimalValue =
        if decimalValue > 0m then consoleDepositAudit |> depositWithAudit customer decimalValue 
        elif decimalValue < 0m then consoleWithdrawAudit |> depositWithAudit customer decimalValue 
        else customer

    while true do
        printfn "Please enter your desired operation."
        printfn "{Amount} = deposits the amount."
        printfn "-{Amount} = withdraws the amount."
        printfn "0 = terminates the application."

        let isDecimal, decimalValue = Console.ReadLine() |> Decimal.TryParse
        
        if isDecimal && decimalValue = 0m then Environment.Exit 0
        
        if isDecimal then customer <- performOperation decimalValue

    0 // return an integer exit code
