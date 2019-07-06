open System.Security.Cryptography
open System.Text
open System

let generateToken x =
    let randomGenerator = RandomNumberGenerator.Create()
    
    let mutable myBytes = Array.create 10 0uy
    randomGenerator.GetBytes(myBytes)    
    
    let characters = Encoding.UTF8.GetChars(myBytes)

    let rawTokenCharacters =
        characters |> Array.groupBy (fun c -> Char.IsDigit c && Char.to)

    let x =
        if rawTokenCharacters.Length = 1 then
            rawTokenCharacters
            |> Array.head
            |> snd
            |> Array.map (fun e -> e.ToString())
            |> String.Concat
        else        
            rawTokenCharacters
                |> Array.filter (fun e -> fst e = false)
                |> Array.head
                |> snd // Get rid of the boolean and get the actual array
                |> Array.map (fun e -> Convert.ToInt64(e).ToString().ToCharArray())
                |> Array.reduce (fun ele1 ele2 -> Array.append ele1 ele2)
                |> Array.map (fun e -> e.ToString())
                |> Array.append (rawTokenCharacters
                    |> Array.filter (fun e -> fst e = true)
                    |> Array.head
                    |> snd // Get rid of the boolean and get the actual array
                    |> Array.map (fun e -> e.ToString()))
                |> String.Concat

    printfn "%A" rawTokenCharacters
    printfn "%s" x

[<EntryPoint>]
let main argv =
    for i in 1 .. 100 do
        generateToken i
        Console.WriteLine()

    Console.ReadKey() |> ignore
    0 // return an integer exit code
