// Learn more about F# at http://fsharp.org

open System

type Address =
    {   Street : string
        City : string
        Postalcode : int }

[<EntryPoint>]
let main argv =
    let myAddress = { Street = ""; City = ""; Postalcode = 10 }
    let myNewAddress = { myAddress with Postalcode = 15 }
    0 // return an integer exit code
