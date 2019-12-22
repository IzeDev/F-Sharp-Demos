open System
open System.Threading
open System.Net

// F-sharp "native"!
let downloadData url = async {
    use wc = new WebClient()
    printfn "Downloading data on thread %d" Thread.CurrentThread.ManagedThreadId
    // Execution of downloadData won't continue until the result
    // of AsyncDownloadData is bound to "data"
    let! data = wc.AsyncDownloadData(Uri url)
    return data.Length }

let asyncDownloadAndGetLength urls =
        urls
        |> Array.map downloadData
        |> Async.Parallel
        |> Async.RunSynchronously
        |> Array.sum
        
// Working with Tasks
let downloadDataAsync url = async {
    use wc = new WebClient()
    printfn "Downloading data on thread %d" Thread.CurrentThread.ManagedThreadId
    let! data =
        wc.DownloadDataTaskAsync(Uri url) |> Async.AwaitTask
    return data.Length }

let workWithTask urls =
    Array.sum (
        urls
        |> Array.map downloadData
        |> Async.Parallel
        |> Async.StartAsTask
    ).Result

[<EntryPoint>]
let main argv = 
    let urls = [| "http://fsharp.org"; "http://microsoft.com"; |]

    printfn "Async download!"

    asyncDownloadAndGetLength urls
        |> printfn "You downloaded %d characters!"

    printfn "Tasks!"

    workWithTask urls
        |> printfn "You downloaded %d characters!"

    0 // return an integer exit code