open HttpFs.Client
open Hopac
open System

let basePath = "http://127.0.0.1:8080";

let postHelloMessageWithNameInQueryString =
    Request.createUrl Post (basePath + "/helloQ")
    |> Request.queryStringItem "name" "Jimmy"
    |> Request.responseAsString

let postHelloMessageWithNameInRequestBody =
    Request.createUrl Post (basePath + "/helloB")
    |> Request.bodyString "name=Jimmy"
    |> Request.responseAsString

let getWithAuthentication =
    Request.createUrl Get (basePath + "/getBankData")
    |> Request.setHeader (Authorization "amltbXk=" )
    |> Request.responseAsString

[<EntryPoint>]
let main argv =
    postHelloMessageWithNameInQueryString |> run |> printfn "%s"
    postHelloMessageWithNameInRequestBody |> run |> printfn "%s"
    getWithAuthentication |> run |> printfn "%s"
    Console.ReadKey() |> ignore
    0 // return an integer exit code
