open System
//open Domain
//open Operations

let formAuditMessage customer action amount =
    let message = String.Format("{0} - {1} : {2} {3}", customer, customer, action, amount)
    message

let x = (formAuditMessage "Jimmy" "Stuff" 500)

printfn "%s" x
