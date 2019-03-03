open Suave
open Suave.Successful
open Suave.RequestErrors
open Utility
open Newtonsoft.Json

let authenticate (request : HttpRequest) handler =
    match request.header "Authorization" with
    | Choice1Of2 header ->
        match String.fromBase64 header with
        | "jimmy" -> handler request
        | _ -> UNAUTHORIZED "Authentication failed."
    | _ -> UNAUTHORIZED "Authentication failed."

let handleHelloWithNameInQueryString (request : HttpRequest) =
    match request.queryParam "name" with
    | Choice1Of2 name -> OK("Hello " + name + " from Post!")
    | _ -> BAD_REQUEST("\"Name\" *is* required!")

let handleHelloWithNameInBody (request : HttpRequest) =
    match request.formData "name" with
    | Choice1Of2 name -> OK("Hello " + name + " from Post!")
    | _ -> BAD_REQUEST("\"Name\" *is* required!")

let getBankData (request : HttpRequest) =
    let bankData =
        [|
            100.03m
            140.25m
            2000m
            30000m
            -50m
        |]

    printfn "In bank function!"

    OK (bankData |> JsonConvert.SerializeObject)

let app =
    request (fun request ->
        match request.method with
        | GET | POST ->
            match request.path with
            | "/hello" -> OK "Hello GET"
            | "/helloQ" ->handleHelloWithNameInQueryString request
            | "/helloB" -> handleHelloWithNameInBody request
            | "/getBankData" -> authenticate request getBankData
            | _ -> NOT_FOUND("The resource you are looking for could not be found.")
        | _ -> BAD_REQUEST("That HTTP-method isn't supported.") )

[<EntryPoint>]
let main argv =
    startWebServer defaultConfig app
    0