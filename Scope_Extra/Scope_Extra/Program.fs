open System

let generateRandomNumber min max =
    let number =
        let min =
            if min > max || min < 0 then 0 else min
        let max =
            if max < 0 then 0 else max
        let r = new Random()
        r.Next(min, max)
    number

[<EntryPoint>]
let main argv =
    let myNum = generateRandomNumber 5 4
    printfn "Hello World from F#!"
    0 // return an integer exit code
