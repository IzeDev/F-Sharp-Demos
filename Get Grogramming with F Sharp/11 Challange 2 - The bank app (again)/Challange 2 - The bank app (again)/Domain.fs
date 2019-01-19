module Domain

open System

type BankAccount = { Balance : decimal }
type Customer = { Name : string; Account : BankAccount }
type Transaction = { Customer : Customer; Action : char; Amount : decimal; WasAccepted : bool}