open System

[<CustomEquality; CustomComparison>]
type Address =
    {   Street : string
        City : string
        Postalcode : int }
    override x.Equals(other) =
        match other with
        | null -> false
        | _ ->
            match other :? Address with
            | true -> x.Postalcode = (other :?> Address).Postalcode
            | _ -> false
    override x.GetHashCode() =
        x.Postalcode.GetHashCode()
    interface IComparable with
        member x.CompareTo(other) =
            match other with
            | null -> 1
            | _ ->
                match other :? Address with
                | true -> x.Postalcode.CompareTo((other :?> Address).Postalcode)
                | _ -> 1

[<EntryPoint>]
let main argv =
    //let mutable mySet = Set.empty
    let mutable myArr = [|{ Street = ""; City = ""; Postalcode = 0 } |]
    
    for i in 1 .. 10945859 do
        let stopwatch = System.Diagnostics.Stopwatch.StartNew()
        //mySet <- Set.add { Street = ""; City = ""; Postalcode = i } mySet
        myArr <- Array.append [| { Street = ""; City = ""; Postalcode = i } |] myArr
        stopwatch.Stop()
        printfn "Added item in %i milliseconds." stopwatch.ElapsedMilliseconds
    
    Console.ReadLine() |> ignore
    0