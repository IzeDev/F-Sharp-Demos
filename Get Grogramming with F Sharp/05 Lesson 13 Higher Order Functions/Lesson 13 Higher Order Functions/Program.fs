open System.IO

type Customer = { age : int}

// A higher order function
let where filter collection =
    seq {
        for item in collection do
            if filter item then yield item }

 // A helper
let toText separator collection =
    let mutable x = ""
    for item in collection do
        x <- x + separator + item.ToString()
    x

 // Hard implementation
let writeToConsole text =
    printfn "%s" text

// Hard implementation
let writeToFile text =
    File.WriteAllText(@"C:\temp\output.txt", text)

// A higher order function
let log writer x =
    writer x

[<EntryPoint>]
let main argv =
    let customers = [| { age = 12 }; { age = 13 }; { age = 14 } |]

    // Calling WHERE with the hard implementation inlined.
    let customersOfThirteenOrOlder =
        customers |> where (fun customer -> customer.age >= 13)

    // Shovin data to the log-function, defining which implementation to use.
    customersOfThirteenOrOlder |> toText " " |> log writeToConsole
    customersOfThirteenOrOlder |> toText " " |> log writeToFile
    0 // return an integer exit code
