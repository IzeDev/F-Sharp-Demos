open HttpFs.Client
open Hopac
open System

let basePath = "http://127.0.0.1:8080";

//let getAllTheAnimals =
//    Request.createUrl Get (basePath + "/animals")
//    |> Request.responseAsString
//    |> run

let getSomeAnimal =
    try
        Request.createUrl Post (basePath + "/animals/")
        |> Request.queryStringItem "animalname" "m"
        |> Request.queryStringItem "numberOfThings" "5"
        |> Request.responseAsString
        |> run
    with
    | Failure(msg) -> Console.WriteLine(msg); msg;

[<EntryPoint>]
let main argv =
    //getAllTheAnimals |> printfn "%s"
    getSomeAnimal |> printfn "%s"
    Console.ReadKey() |> ignore
    0 // return an integer exit code
