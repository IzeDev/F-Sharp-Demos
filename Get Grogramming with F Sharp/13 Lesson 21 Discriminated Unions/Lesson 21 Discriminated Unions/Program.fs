open System

// Simple enum
type Power = 
    | Divine // = 0 could be added, but would make the code beneath more error-prone
    | Dark
    | Nature

// Match against enum
let getPowerName power =
    match power with
    | Power.Divine -> "Divine"
    | Power.Dark -> "Dark"
    | Power.Nature -> "Nature"

// Discriminated Union (with some data)
type Disk =
    | Harddisk of RPM : int
    | SSD

let seek disk =
    match disk with
    | Harddisk(_) -> "Searching at reasonable speed..."
    | SSD -> "Already found it!"

// In order to create general fields, shared by all cases, create a wrapper.
type DiskInfo = {
    DiskName : string
    SizeInGb : int
    Disk : Disk }

let seekWithDiskInfo diskInfo =
    diskInfo.DiskName + ", " + diskInfo.SizeInGb.ToString() +
    " GB, " + (seek diskInfo.Disk).ToLower()

[<EntryPoint>]
let main argv =
    Harddisk(5900) |> seek |> printfn "%s"

    SSD |> seek |> printfn "%s"

    {DiskName = "Samsung evo 850"; SizeInGb = 100; Disk = SSD }
    |> seekWithDiskInfo |> printfn "%s"
    
    0
