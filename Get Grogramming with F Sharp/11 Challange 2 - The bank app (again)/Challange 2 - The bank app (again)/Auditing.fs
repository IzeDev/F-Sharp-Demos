module Auditing

open System
open Util.IO

module private InternalFunctions =
    open Domain

    let formAuditMessage customer action amount =
        String.Format("{0} - {1} : {2} {3}", customer.Name, customer.Account, action, amount)

open InternalFunctions

let consoleAudit action customer  amount =
    formAuditMessage customer action amount |> printfn "%s"

let filesystemAudit action customer amount =
    formAuditMessage customer action amount |> writeToFile "audit.txt"
