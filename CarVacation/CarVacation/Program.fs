open System

let validChoices = [|"H"; "O"; "S"; "G"|]

let canDrive currentPetrol cost =
    currentPetrol >= cost

let presentChoices petrolLeft =
    Console.Clear()
    printfn "You have %d petrol left!" petrolLeft 
    printfn "Where do you want to drive?"
    printfn "Home? (H)"
    printfn "The office? (O)"
    printfn "The stadium? (S)"
    printfn "The gas station? (G)"

let isValidChoice (choice) =
    Array.contains choice validChoices

let rec getUserAction petrolLeft =    
    presentChoices petrolLeft
    let userChoice = Console.ReadKey().Key.ToString()
    if isValidChoice userChoice then userChoice
    else getUserAction petrolLeft

let alertUserOfError petrolLeft cost =
    Console.Clear()
    printfn "You have %d petrol left and just tried to spend %d" petrolLeft cost
    Console.ReadKey() |> ignore

let rec playGame petrolInTank =    
    let choice = getUserAction petrolInTank
    let cost =
        match choice with
        | "H" -> 25
        | "O" -> 50
        | "S" -> 25
        | "G" -> 10
        | _ -> 0

    let refil = if choice = "S" then 50 else 0

    let petrolLeft = petrolInTank - (cost - refil);

    if cost > petrolInTank then
        alertUserOfError petrolInTank cost
        playGame petrolInTank
    elif petrolLeft = 0 then
        "You have 0 petrol left! Game over!"
    else
        playGame petrolLeft


[<EntryPoint>]
let main argv =
    let message = playGame 100
    Console.Clear()
    printfn "%s" message
    Console.ReadKey() |> ignore
    0 // return an integer exit code
