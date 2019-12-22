// Learn more about F# at http://fsharp.org

open System
open FSharp.Data

let [<Literal>] Conn =
    "Server=Virgil\LocalDB;Database=TSQL2012;Integrated Security=SSPI"

type GetCustomers =
    SqlCommandProvider<"SELECT * FROM Sales.Customers", Conn>

type GetCustomersOfCity =
    SqlCommandProvider<"SELECT * FROM Sales.Customers WHERE city = @City", Conn, AllParametersOptional = true>

type InsertNewCustomer =
    SqlCommandProvider<
        "Insert Sales.Customers
        (
            companyname,
            contactname,
            contacttitle,
            address,
            city,
            country,
            phone
        )
        VALUES
        (
            @companyname,
            @contactname,
            @contacttitle,
            @address,
            @city,
            @country,
            @phone
        )",
        Conn>

type SearchCustomersByCity =
    SqlCommandProvider<"Exec Sales.Customers_SearchByCity @City = @City", Conn, AllParametersOptional = true>

[<EntryPoint>]
let main argv =
    let customers = GetCustomers.Create(Conn).Execute() |> Seq.toArray
    let customer = customers.[0]

    InsertNewCustomer.Create(Conn).Execute(
        "Multisoft", "Jimmy Gustafsson",
        "Developer", "Brunkebergstorg 5",
        "Stockholm", "Sweden", "0762417410") |> ignore

    let customers2 = GetCustomersOfCity.Create(Conn).Execute() |> Seq.toArray
    //let customer2 = customers2.[0]

    let customersOfStockholm = SearchCustomersByCity.Create(Conn).Execute(Some("Stockholm")) |> Seq.toArray

    //printfn "%s" customer2.contactname
    0 // return an integer exit code
