module Transactionlog

open Domain
open Util.JsonWithIO

let transactionLogFileName = "transactionlog.txt"

let logTransaction transaction =
     appendJsonToFile transactionLogFileName transaction

let getAllTransactions =
    readSequenceFromFile<Transaction> transactionLogFileName

let getAllTransactionsForCustomer customerName =
    let x = getAllTransactions
    getAllTransactions |>
    Seq.filter (fun item -> item.Customer.Name = customerName)
    

let updateCustomerFromTransactionLog customer transactionsLog =
    let getBalanceFromLog log =
        {
            Balance =
                log |>
                Seq.filter (fun item -> item.WasAccepted = true) |>
                Seq.map (fun item -> item.Amount) |>
                Seq.sum
        }
        
    let getNameOfCustomerFromLog log =
        log |>
        Seq.map (fun item -> item.Customer.Name) |>
        Seq.head
        
    
    if Option.isNone customer && transactionsLog |> Seq.isEmpty then
        { Name = "Unknown"
          Account = { Balance = 0m } }
    elif Option.isNone customer then
        { Name = getNameOfCustomerFromLog transactionsLog
          Account = getBalanceFromLog transactionsLog }
    elif Option.isSome customer then
        { Name = customer.Value.Name
          Account = getBalanceFromLog transactionsLog }
    else
        raise (System.NotImplementedException("Unknown parameter-setup!"))