open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful
open Newtonsoft.Json

let getAllTheAnimal =
    [|
        "Monkey"
        "Horse"
        "Dog"
        "Mouse"
        "Sparrow"
        "Snake"
    |]

let getAnimal strVal iVal =
    [| for i in 1 .. iVal -> strVal |]

//let app =
//  GET >=> choose // combines both WebParts
//       [ path "/hello" >=> OK "Hello GET"
//         pathScan "/add/%d/%d" (
//              fun (n1,n2) ->
//                OK <| sprintf "%d" (n1 + n2)
//            ) ]

let app =
  choose
    [ GET >=> choose
        [ path "/hello" >=> OK "Hello GET"
          path "/goodbye" >=> OK "Good bye GET" 
          path "/animals" >=> OK (getAllTheAnimal |> JsonConvert.SerializeObject) ]
      POST >=> choose
        [ path "/hello" >=> OK "Hello POST"
          path "/goodbye" >=> OK "Good bye POST"
          pathScan "/animals/%s%i" (fun (q, i) -> OK( getAnimal q i |> JsonConvert.SerializeObject) ) ]
    ]

[<EntryPoint>]
let main argv =
    startWebServer defaultConfig app
    0