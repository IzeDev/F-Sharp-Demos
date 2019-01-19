module Operations 

open Domain
open Transactionlog

module private Operations =
    let deposit customer amount =
        if amount > 0m then
            { Customer = customer; Action = 'D'; Amount = amount; WasAccepted = true }
        else
            { Customer = customer; Action = 'D'; Amount = amount; WasAccepted = false }

    let withdraw customer amount =
        if customer.Account.Balance + amount >= 0m && amount < 0m then
            { Customer = customer; Action = 'W'; Amount = amount; WasAccepted = true }
        else
            { Customer = customer; Action = 'W'; Amount = amount; WasAccepted = false }

open Operations

let withdrawWithAudit customer amount audit =
    audit customer amount
    withdraw customer amount |> logTransaction
    getAllTransactionsForCustomer customer.Name |>
    updateCustomerFromTransactionLog (Some(customer))

let depositWithAudit customer amount audit =
    audit customer amount
    deposit customer amount |> logTransaction
    getAllTransactionsForCustomer customer.Name |>
    updateCustomerFromTransactionLog (Some(customer))