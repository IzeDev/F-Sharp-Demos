module Operations 

open Domain

let deposit account amount =
    if amount > 0m then { account with Balance = account.Balance + amount }
    else account

let withdraw account amount =
    if account.Balance >= amount && amount > 0m then { account with Balance = account.Balance - amount }
    else account