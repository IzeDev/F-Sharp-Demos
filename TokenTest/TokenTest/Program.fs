open System.Security.Cryptography
open System.Text
open System

let constructToken (characters : Char []) doConvert =
    match characters with
    | [||] -> ""
    | _ ->
        match doConvert with
        | true -> characters |> String.Concat
        | false ->
            characters
                |> Array.map (fun e -> Convert.ToInt64(e).ToString())
                |> String.Concat

let generateToken seed =
    let randomGenerator = RandomNumberGenerator.Create()
    
    let mutable myBytes = Array.create seed 0uy
    randomGenerator.GetBytes(myBytes)    
    
    let characters = Encoding.UTF8.GetChars(myBytes)

    let rawTokenCharacters =
        characters |> Array.groupBy (fun c ->
            (c >= 'a' && c <= 'z') ||
            (c >= 'A' && c <= 'Z') ||
            (c >= '0' && c <= '9'))
            
    if rawTokenCharacters.Length = 1 then
        constructToken (rawTokenCharacters.[0] |> snd) (rawTokenCharacters.[0] |> fst)
    else
        constructToken (rawTokenCharacters.[1] |> snd) (rawTokenCharacters.[1] |> fst) +
        constructToken (rawTokenCharacters.[0] |> snd) (rawTokenCharacters.[0] |> fst)

[<EntryPoint>]
let main argv =
    for i in 1 .. 100 do
        Console.Write(generateToken 10)
        Console.WriteLine()

    Console.ReadKey() |> ignore
    0 // return an integer exit code
