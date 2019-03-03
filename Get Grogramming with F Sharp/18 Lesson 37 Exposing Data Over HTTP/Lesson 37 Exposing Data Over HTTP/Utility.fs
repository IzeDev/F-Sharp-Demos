module Utility

module String =
    open System
    open System.Text

    let fromBase64 text =
        Encoding.UTF8.GetString(Convert.FromBase64String(text));

    let toBase64 (text : string) =
        text.ToCharArray()
        |> Array.map(fun c -> Convert.ToByte c)
        |> Convert.ToBase64String

