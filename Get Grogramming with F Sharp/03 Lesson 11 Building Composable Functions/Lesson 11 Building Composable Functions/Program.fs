open System

// A simple add-function
let add first second = first + second

// Partial application of add:
let addFive = add 5

// composing functions
let toUpper (text : string) = text.ToUpper()

let addExclamation text = text + "!"

let doShout = toUpper >> addExclamation

[<EntryPoint>]
let main argv =
    // Usage of addFive
    let fifteen = addFive 10

    // Pipelining data through functions
    let someValue = fifteen |> addFive |> addFive
    printfn "%d" someValue
    let greeting = "hello world"
    let shoutGreeting = doShout greeting
    printfn "%s" shoutGreeting
    0 // return an integer exit code
