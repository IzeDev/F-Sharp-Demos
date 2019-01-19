open System
open Loops

[<EntryPoint>]
let main argv =
    forInLoops 1
    Console.WriteLine(Environment.NewLine)

    forToLoops 1
    Console.WriteLine(Environment.NewLine)

    comprehensions 1
    Console.WriteLine(Environment.NewLine)
    0 // return an integer exit code
