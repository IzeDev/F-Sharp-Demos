// Learn more about F# at http://fsharp.org

open System
open SomeAPI // Open the namespace
open Operations // Open the public module

(*
    // This would not work since InnerOperations is private.
    open Operations.InnerOperations
*)

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    let myValue = someCalculation 10 15
    myValue
