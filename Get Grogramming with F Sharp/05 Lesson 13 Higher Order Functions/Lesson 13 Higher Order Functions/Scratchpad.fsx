type Customer = { age : int}

let where filter collection =
    seq {
        for item in collection do
            if filter item then yield item }

let toText collection =
    let mutable x = "";
    for item in collection do
        x <- x + item.ToString()
    x

let customers = [| { age = 12 }; { age = 13 } |]

let customersOfThirteenOrOlder =
    customers |> where (fun customer -> customer.age >= 13)

let x = customersOfThirteenOrOlder.ToString()

customersOfThirteenOrOlder |> toText |> printfn "%s"




