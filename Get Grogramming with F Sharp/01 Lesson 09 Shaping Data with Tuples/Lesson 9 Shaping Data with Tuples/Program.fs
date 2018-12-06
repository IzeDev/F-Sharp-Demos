// Learn more about F# at http://fsharp.org

open System

let parseName (name : string) =
    let parts = name.Split(' ')
    let forename = parts.[0]
    let surname = parts.[1]
    forename, surname

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    let name = parseName "Jimmy Gustafsson" // Creating a tuple
    let forename, surname = name // Decostructing a tuple

    let forename, surname = parseName "Jimmy Gustafsson" // Deconstructing the tuple right at the call
    Console.ReadKey() |> ignore
    0 // return an integer exit code
