open System

type Customer = {Name : String option}

let printToScreen x =
    match x with
    | Some value -> printfn "%s" (value.ToString())
    | None -> printfn "Empty value!"

[<EntryPoint>]
let main argv =
    let myNumber = Some(10)
    let myUnknownThing = None

    // Using Option with a function
    printToScreen myNumber
    printToScreen myUnknownThing

    (*
        Option.map lets you return another type of Option from an Option.
    *)
    let myNumberAsText = myNumber |> Option.map(fun number -> number.ToString())
    let myUnknownThingAsText = myUnknownThing |> Option.map(fun number -> number.ToString())


    (*
        Option.bind is the same as Option.map, except it works with functions that
        themelseves return options.

        I don't really get this. Don't quote me.
    *)
    let mystrangeCustomers =
        [|  Some({ Name = Some("Jimmy") })
            Some({ Name = None })
            None
        |]

    let myCustomerName =
        mystrangeCustomers
        |> Array.map(fun c -> c |> Option.bind(fun x -> x.Name |> Option.map(fun y -> y.Length)))

    
    let x = Some(5) |> Option.filter(fun o -> o < 10) //Some(5)
    let y = Some(5) |> Option.filter(fun o -> o > 10) // Null
    let z = None |> Option.filter(fun o -> o > 10) // Null







    0
