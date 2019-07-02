open System
open SomeAPI // Open the namespace
open Operations // Open the public module
// Also an option -> open SomeApi.Operations

(*
    // This would not work since InnerOperations is private.
    open Operations.InnerOperations
*)

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    let myValue = someCalculation 10 15
    myValue
