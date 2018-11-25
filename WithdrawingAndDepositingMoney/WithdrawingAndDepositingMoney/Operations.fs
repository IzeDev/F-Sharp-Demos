module Operations

open Domain

let getCurrentAmountInBankAccount bankAccount =
    bankAccount.CurrentBalance.ToString()

let isWithdrawalPossible bankAccount amountDesired =
    bankAccount.CurrentBalance >= amountDesired

let depositAmountToBankAccount bankAccount amount =
    { bankAccount with CurrentBalance = bankAccount.CurrentBalance + amount }

let withdrawAmountFromBankAccount bankAccount amount =
    { bankAccount with CurrentBalance = bankAccount.CurrentBalance - amount }

