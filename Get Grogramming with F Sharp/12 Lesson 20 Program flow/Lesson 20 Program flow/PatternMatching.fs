module PatternMatching

type Customer = { Name : string; Balance : decimal }

let getCustomerCredit customer =
    match customer with
    | "medium", 1 -> 500
    // good customer with 0 or 1 year history
    | "good", 0 | "good", 1 -> 750
    | "good", 2 -> 1000
    | "good", _ -> 2000
    | _ -> 250

let getCUstomerCredit2 customer =
    match customer with
    | "medium", 1 -> 500
    // Another way of expressing the OR-condition.
    | "good", years when years < 2 -> 750
    | "good", 2 -> 1000
    | "good", _ -> 2000
    | _ -> 250

let handleCustomers customers =
    match customers with
    | [] -> failwith "No customers supplied!"
    | [ customer ] -> printfn "Single customer, name is %s" customer.Name
    | [ first; second ] -> printfn "Two customers, balance %f" (first.Balance + second.Balance)
    | customers -> printfn "Customers supplied: %d" customers.Length

let handleCustomer customer =
    match customer with
    | { Name = "Jimmy" } -> printfn "This is a great customer!"
    // Access a field that isn't part of the matching.
    | { Name = name; Balance = 50m } -> printfn "%s is rich!" name
    | {Name = name } -> printfn "%s is a normal customer." name
