module Loops
    open System

    let arrayOfChars = [| for c in 'a' .. 'z' -> Char.ToUpper c |]

    let forInLoops x =
        // Go from 1 to 10
        for number in 1 .. 10 do
            printfn "%d Hello!" number

        // Go from 20 to 10
        for number in 20 .. -1 .. 10 do
            printfn "%d Hello!" number

        let customerIds = [45 .. 47]

        for idValue in customerIds do
            printfn "CustomerId: %d !" idValue

        // Make 2 jumps per loop. 20 will be printed, 22 will not.
        for even in 2 .. 2 .. 21 do
            printfn "%d is even!" even
            
    let forToLoops x =
        for number = 1 to 10 do
            printf "%d " number

    let comprehensions x =
        for char in arrayOfChars do
            printfn "%c is in the list!" char