namespace TransactionAPI

module Operations =
    type BankAccount = { CurrentBalance : decimal }

    module private Domain =

        let openAccount initialBalance =
            if initialBalance > 0m then
                (true, { CurrentBalance = initialBalance })
            else
                (false, { CurrentBalance = 0m })

        let withdrawFromAccount bankAccount amountToWithdraw =
            let updatedBankAccount =
                { bankAccount with CurrentBalance = bankAccount.CurrentBalance - amountToWithdraw }

            if updatedBankAccount.CurrentBalance < bankAccount.CurrentBalance then
                (true, updatedBankAccount)
            else
                (false, bankAccount)

        let depositToAccount bankAccount amountToDeposit =
            let updatedBankAccount =
                { bankAccount with CurrentBalance = bankAccount.CurrentBalance + amountToDeposit }

            if updatedBankAccount.CurrentBalance > bankAccount.CurrentBalance then
                (true, updatedBankAccount)
            else
                (false, bankAccount)

    let say msg = msg

    let openAccount initialBalance logCallback =
        let x = Domain.openAccount initialBalance

        if fst x = true then
            logCallback initialBalance true
            Some(snd x)
        else
            logCallback initialBalance false
            None           


    