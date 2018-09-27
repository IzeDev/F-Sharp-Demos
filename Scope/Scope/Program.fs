open System
open System.Net
open System.Windows.Forms

[<EntryPoint>]
[<STAThread>]
let main argv =
    (*
        "let webClient" is only needed to create "fsharpOrg", so it has been
        moved to the scope of the variable-declaration for "fsharpOrg".

        "fsharpOrg" is in turn only needed in order to declare "browser" and
        has thus been scoped in accordance with that.    
    *)
    
    let browser =
        let fsharpOrg =
            let webClient = new WebClient()
            webClient.DownloadString(Uri "http://fsharp.org")

        new WebBrowser(ScriptErrorsSuppressed = true,
            Dock = DockStyle.Fill,
            DocumentText = fsharpOrg)

    let form = new Form(Text = "Hello from F#!");
    form.Controls.Add browser
    form.Show();
    Console.ReadKey() |> ignore
    0
