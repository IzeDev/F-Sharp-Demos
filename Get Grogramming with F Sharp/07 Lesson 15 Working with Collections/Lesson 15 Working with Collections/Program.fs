// Learn more about F# at http://fsharp.org

open System

module lists =
    let myList = [1 .. 10 ]

    // Attaching elements to the start of the list
    let myListWithAttachmentAtStart = 0 :: myList

    // Attaching elements to the end of the list (Concatenating lists)
    let myListWithAttachmentAtEnd = myList @ [11]

    // Concatenating lists
    let myConcatedList = myList @ [11 .. 20]

module sequences =

    let doStuff x =
        // Range sequence creation
        let mySeq = { 1 .. 10 }

        // Sequence creation with an increment of 10
        let myIncrementSeq = { 1 .. 10 .. 101 }

        // Sequence creation with a function instead
        // The sequence won't have values until the Seq.iter-function is called.
        let myFunctionSeq = seq { for i in 1 .. 10 -> i * i }
        myFunctionSeq |> Seq.iter (fun element -> Console.WriteLine element);

        x

module arrays =
    let doStuff x =
        // Creating arrays
        let myArr = [| 1 .. 10 |]

        let myOtherArr = 
            [|
                1
                2
                3
            |]

        // Creating an array with an expression
        let myArrayFromSequeceExpression = [| for i in 1 .. 10 -> i * i |]

        // Getting certain parts of the array
        let fromStartToElementX = myArrayFromSequeceExpression.[..4]
        let fromStartElementXToEnd = myArrayFromSequeceExpression.[3..]
        let someElements = myArrayFromSequeceExpression.[5..8]

        x
    

[<EntryPoint>]
let main argv =
    let x = sequences.doStuff 10
    let x = arrays.doStuff 10
    

    printfn "Hello World from F#!"
    0 // return an integer exit code
