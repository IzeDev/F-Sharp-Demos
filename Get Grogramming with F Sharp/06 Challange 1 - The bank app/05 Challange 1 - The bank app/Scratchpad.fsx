module Domain =
    type BankAccount = { Balance : decimal }
    type Customer = { Name : string; Account : BankAccount }

module Operations =
    open Domain

    let deposit account amount =
        if amount > 0m then { account with Balance = account.Balance + amount }
        else account

    let withdraw account amount =
        if account.Balance >= amount && amount > 0m then { account with Balance = account.Balance - amount }
        else account

let myAccount = { Domain.Balance = 1000m }
let myAccount2 = Operations.deposit myAccount 100m