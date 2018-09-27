open System
open System.IO

let numberToString n = n.ToString()

let countNumberOfCharacters (word : string) =
    word.ToCharArray().Length

let writeToDisk (input : string) =
    let desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
    File.WriteAllText(desktopPath + @"\test.txt", input)


let writeNumberOfCharactersToDisk = 
    countNumberOfCharacters >> numberToString >> writeToDisk

writeNumberOfCharactersToDisk "Andreas"