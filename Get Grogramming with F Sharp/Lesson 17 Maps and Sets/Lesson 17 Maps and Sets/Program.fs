// Learn more about F# at http://fsharp.org

open System
open System.IO

let printRootFoldersWithAge =
    let getAllFiles path =
        Directory.EnumerateDirectories path |> Seq.cast 

    let myFiles =
        getAllFiles @"C:\"
        |> Seq.map (fun ele -> DirectoryInfo(ele))
        |> Seq.map (fun ele -> ele.Name, ele.CreationTimeUtc )
        |> Map.ofSeq

    let datetimeNowUtc = DateTime.UtcNow

    let myFilesWithAgeInDays = 
        myFiles |> Map.map (fun key item -> datetimeNowUtc.Subtract item)
        |> Map.map(fun key item -> item.Days)

    myFilesWithAgeInDays |> Map.iter (fun key item -> printfn "File: %s\nDays old: %d\n" key item)

let getFruitsJimmyAndEliseLikes =
    let fruitsJimmyLike =
        [ "banana"; "apple"; "orange"; "pear" ]
        |> Set.ofList

    let fruitsEliseLikes =
        [ "peach"; "clementine"; "apple"; ]
        |> Set.ofList

    let allKindsOfFruit = fruitsJimmyLike + fruitsEliseLikes

    let fruitsWeCanShare = fruitsJimmyLike |> Set.intersect fruitsEliseLikes

    fruitsWeCanShare |> Set.iter (fun item -> printfn "%s" item)

[<EntryPoint>]
let main argv =
    printRootFoldersWithAge
    getFruitsJimmyAndEliseLikes

    0 // return an integer exit code
