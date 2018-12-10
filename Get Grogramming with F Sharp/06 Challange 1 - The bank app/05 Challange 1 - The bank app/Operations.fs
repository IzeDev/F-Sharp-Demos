module Operations 

open Domain

module private Operations =
    let deposit customer amount =
        let account =
            if amount > 0m then { customer.Account with Balance = customer.Account.Balance + amount }
            else customer.Account
        {customer with Account = account}

    let withdraw customer amount =
        let account =
            if customer.Account.Balance >= amount && amount > 0m then { customer.Account with Balance = customer.Account.Balance - amount }
            else customer.Account
        {customer with Account = account}

open Operations

let withdrawWithAudit customer amount audit =
    audit customer amount
    withdraw customer amount

let depositWithAudit customer amount audit =
    audit customer amount
    deposit customer amount