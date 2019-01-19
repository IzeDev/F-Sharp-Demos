module Util

open System.IO
open Newtonsoft.Json
open Microsoft.FSharp.Collections

module private Json =
    let toJsonString object =
        JsonConvert.SerializeObject object

    let fromJsonString<'T> jsonString =
        JsonConvert.DeserializeObject<'T>(jsonString)

module IO =
    open System

    let writeToFile filename text =
        File.WriteAllText(@"C:\Temp\" + filename, text)

    let appendTextToFile filename text =
        File.AppendAllText(@"C:\Temp\" + filename, text + Environment.NewLine)

    let readAllFromFile filename =
        try
            File.ReadAllLines(@"C:\Temp\" + filename)
        with
            | :? System.IO.FileNotFoundException -> Array.empty

module JsonWithIO =
    open IO
    open Json

    let appendJsonToFile filename text =
        toJsonString text |> appendTextToFile filename

    let readSequenceFromFile<'T> filename =
        readAllFromFile filename |>
        Array.Parallel.map (fun jsonString -> fromJsonString<'T> jsonString) |>
        Array.toSeq
