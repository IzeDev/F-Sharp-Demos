open System
open Domain
open Transactionlog
open Operations
open Auditing

// Audits
let consoleDepositAudit = consoleAudit "deposit"
let consoleWithdrawAudit = consoleAudit "withdraw"

let performOperation customer decimalValue =
    if decimalValue > 0m then
        consoleDepositAudit |> depositWithAudit customer decimalValue 
    else
        consoleWithdrawAudit |> withdrawWithAudit customer decimalValue 

let rec playGame customer =
    printfn "Please enter your desired operation."
    printfn "{Amount} = deposits the amount."
    printfn "-{Amount} = withdraws the amount."
    printfn "0 = terminates the application."

    let isDecimal, decimalValue = Console.ReadLine() |> Decimal.TryParse
        
    if isDecimal && decimalValue = 0m then
        Environment.Exit 0   
        
    if isDecimal then
        performOperation customer decimalValue |> playGame
    else
        playGame customer

let getCustomer =
    let rec getCustomerName minimumNameLength =
        Console.Clear()
        printfn "Please type your name and press enter!"
        let name = Console.ReadLine()

        if name.Length >= minimumNameLength then
            name
        else
            getCustomerName minimumNameLength

    let rec getCustomerBalance minimumInitialBalance =
        Console.Clear()
        printfn "Please type your initial balance and press enter!"
        let isDecimal, decimalValue = Console.ReadLine() |> Decimal.TryParse

        if isDecimal && decimalValue >= minimumInitialBalance then
            decimalValue
        else
            getCustomerBalance 0m

    let customerName = getCustomerName 3
    let dummyCustomer = Some {Name = customerName; Account = { Balance = 0m }}
    let customerFromTransactionLog =
        customerName |>
        getAllTransactionsForCustomer |>
        updateCustomerFromTransactionLog dummyCustomer

    if customerFromTransactionLog.Account.Balance <= 0m then
        let balance = getCustomerBalance 0.1m
        let initialTransaction =
            { Customer = customerFromTransactionLog 
              Action = 'S'
              Amount = balance
              WasAccepted = true }          
        logTransaction initialTransaction

        { customerFromTransactionLog with Account = { Balance = balance } }
    else
        customerFromTransactionLog

[<EntryPoint>]
let main argv =
    let customer = getCustomer
    printfn "Welcome %s" customer.Name
    playGame customer
    0
