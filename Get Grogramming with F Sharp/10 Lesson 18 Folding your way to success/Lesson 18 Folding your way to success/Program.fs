open System

type Rule = string -> bool * string

let getSumOfNumbers numbers =
    let sum inputs =
        (0, inputs) ||> List.fold (fun state input -> state + input)

    let sum2 inputs =
        inputs |> List.reduce (fun ele1 ele2 -> ele1 + ele2 )

    (sum numbers, sum2 numbers)

let createRule rules  =
    rules 
    |> List.reduce (fun rule1 rule2 ->
        fun word ->
            let passed, error = rule1 word
            if passed then
                let passed, error = rule2 word
                if passed then true, ""
                else false, error
            else
                false, error)

[<EntryPoint>]
let main argv =
    let myNumbers = [1..100]

    getSumOfNumbers myNumbers    

    let isDivisibleByTwo number =
        number % 2m = 0m

    let rules : Rule list =
        [
            (fun text -> Decimal.TryParse text |> fst, "Must be a number")
            (fun text -> Decimal.TryParse text |> snd > 0m, "Must be greater than zero.")
            (fun text -> Decimal.TryParse text |> snd |> isDivisibleByTwo, "Must be divisible by two.")
        ]
    
    let isNumber = rules.[0] "-15"
    let isNumbe2 = rules.[1] "-15"
    let isNumber3 = rules.[0] "apa"
    let isNumber4 = rules.[2] "2"
    let isNumber5 = rules.[2] "1"

    let isEvenNumberGreaterThanZero =
        rules 
        |> List.reduce (fun rule1 rule2 ->
        fun word ->
            let passed, error = rule1 word
            if passed then
                let passed, error = rule2 word
                if passed then true, ""
                else false, error
            else
                false, error)

    let someValue1 = isEvenNumberGreaterThanZero "apa"
    let someValue2 = isEvenNumberGreaterThanZero "-1"
    let someValue3 = isEvenNumberGreaterThanZero "1"
    let someValue4 = isEvenNumberGreaterThanZero "2"

    0 // return an integer exit code
