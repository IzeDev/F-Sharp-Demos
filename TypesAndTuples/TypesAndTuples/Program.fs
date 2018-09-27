// Learn more about F# at http://fsharp.org

open System

type Car = { Petrol : int }

type Destination = {
    Name : string
    ShortName : char
    CostInPetrol : int 
    RefilOfPetrolOnArrival : int }

let presentChoices petrolLeftInTank (destinations : Destination[]) =
    Console.Clear()

    printfn "You have %d petrol left!" petrolLeftInTank

    for e in destinations do
        printfn "%s? (%c)" e.Name e.ShortName

let getChoice (validChoices : Destination[]) =
    let userChoice =
        let key = Console.ReadKey().KeyChar.ToString().ToUpper().ToCharArray().[0]
        Array.tryFind(fun e -> e.ShortName = key) validChoices

    match userChoice with
    | Some  x -> (true, x.CostInPetrol, x.RefilOfPetrolOnArrival)
    | None -> (false, 0, 0)

let informUserOfError petrolCost petrolLeft =
    Console.Clear()
    printfn "You just tried to spend %d petrol, you have %d!" petrolCost petrolLeft
    Console.ReadKey() |> ignore
    ()

let rec goForADrive car destinations =
    if car.Petrol = 0 then
        ()
    else
        presentChoices car.Petrol destinations

        let isValidChoice, petrolCost, petrolRefund = getChoice destinations

        if isValidChoice && petrolCost <= car.Petrol then        
            goForADrive {car with Petrol = car.Petrol - (petrolCost - petrolRefund)} destinations
        elif petrolCost > car.Petrol then
            informUserOfError petrolCost car.Petrol
            goForADrive car destinations
        else
            goForADrive car destinations

[<EntryPoint>]
let main argv =
    let destinations =
        [|
            {
                Name = "Home";
                ShortName = 'H';
                CostInPetrol = 25;
                RefilOfPetrolOnArrival = 0;
            };
            {
                Name = "The office";
                ShortName = 'O';
                CostInPetrol = 50;
                RefilOfPetrolOnArrival = 0;
            };
            {
                Name = "The stadium";
                ShortName = 'S';
                CostInPetrol = 25;
                RefilOfPetrolOnArrival = 0;
            };
            {
                Name = "The gas station";
                ShortName = 'G';
                CostInPetrol = 10;
                RefilOfPetrolOnArrival = 50;
            }
        |]

    let car = { Petrol = 100 }
    goForADrive car destinations
    Console.Clear();
    printfn "Game over!"
    Console.ReadKey() |> ignore
    0 // return an integer exit code
