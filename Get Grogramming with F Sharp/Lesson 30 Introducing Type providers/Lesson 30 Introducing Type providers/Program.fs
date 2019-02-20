// Learn more about F# at http://fsharp.org

open System
open FSharp.Data

type FoodItem = CsvProvider< @"D:\Source\F-Sharp Demos\Get Grogramming with F Sharp\00 Lesson data\Livsmedelsdatabasen.csv" >

[<EntryPoint>]
let main argv =
    let data = FoodItem.GetSample().Rows |> Seq.toArray
    let headers = FoodItem.GetSample().Headers;
    0
