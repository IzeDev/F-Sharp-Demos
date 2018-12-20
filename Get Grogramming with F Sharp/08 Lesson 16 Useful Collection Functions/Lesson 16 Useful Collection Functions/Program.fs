open System

type Person = 
    { 
        Firstname : String
        Age : int32
    }

[<EntryPoint>]
let main argv =
    let personList =
        [
            { Firstname = "Elise"; Age = 25 }
            { Firstname = "Jimmy"; Age = 26 }
            { Firstname = "Adam"; Age = 26 }
            { Firstname = "Emma"; Age = 25 }
        ]
    let listNumbers = [ 1; 2; 3 ]
    let arrayNumbers = [| 1; 2; 3 |]
    let seqNumbers = seq{ 1 .. 3 }

    // Map
    let mappedList = listNumbers |> List.map (fun ele -> ele * 2)
    let mappedArray = arrayNumbers |> Array.map (fun ele -> ele * 2)
    let mappedSeq = seqNumbers |> Seq.map (fun ele -> ele * 2)

    // Iter
    mappedList |> List.iter (fun ele -> Console.Write ele)
    mappedArray |> Array.iter (fun ele -> Console.Write ele)
    mappedSeq |> Seq.iter (fun ele -> Console.Write ele)

    // Collect
    let collectFromList = mappedList |> List.collect (fun ele -> [ ele .. 10 ])

    // Pairwise
    let pairwisedList = collectFromList |> List.pairwise

    // Group by
    let personByAgeList = personList |> List.groupBy (fun ele -> ele.Age)

    // Partition
    // (gets an object with two lists. Item1 = true, Item2 = false)
    let allInList2 = personList |> List.partition (fun ele -> ele.Age >= 50)
    let allInlist1 = personList |> List.partition (fun ele -> ele.Age >= 0)
    let some = personList |> List.partition (fun ele -> ele.Age >= 26)

    // Aggregates
    let sumOfAge = personList |> List.map (fun ele -> ele.Age) |> List.sum


    0
