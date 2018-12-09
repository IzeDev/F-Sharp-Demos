module Domain

type BankAccount = { Balance : decimal }
type Customer = { Name : string; Account : BankAccount }