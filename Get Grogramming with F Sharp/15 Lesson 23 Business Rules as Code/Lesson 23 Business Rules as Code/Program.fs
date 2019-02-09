open System

// Unsafe customer
type UnsafeCustomer =
    { CustomerId : string
      CustomerName : string
      PhoneNumber : string
      EmailAddress : string }

let createUnsafeCustomer customerId customerName phoneNumber emailAddress =
    { CustomerId = customerId
      CustomerName = customerName
      PhoneNumber = phoneNumber
      EmailAddress = emailAddress }

// Safe customer
type CustomerId = CustomerId of string
type CustomerName = CustomerName of string
type PhoneNumber = PhoneNumber of string
type EmailAddress = EmailAddress of string

type Customer =
    { CustomerId : CustomerId
      CustomerName : CustomerName
      PhoneNumber : PhoneNumber
      EmailAddress : EmailAddress }

let createSafeCustomer customerId customerName phoneNumber emailAddress =
    { CustomerId = customerId
      CustomerName = customerName
      PhoneNumber = phoneNumber
      EmailAddress = emailAddress }

// Super-typed Customer
type ContactDetail =
    | Phone of string
    | Email of string

type SuperTypedCustomer =
    { CustomerId : CustomerId
      CustomerName : CustomerName
      ContactDetail : ContactDetail }

let createSuperTypedCustomer customerId customerName contactDetail =
    { CustomerId = customerId
      CustomerName = customerName
      ContactDetail = contactDetail }

// Creating a record category
type CustomerWithEmail = CustomerWithEmail of SuperTypedCustomer

let HasCustomerAnEmail customer =
    match customer.ContactDetail with
    | ContactDetail.Email _ -> Some(CustomerWithEmail customer)
    | _ -> None

type IsSuccess =
    | True of string
    | False of string

let HasCustomerAnOutlookEmail customer =
    match customer.ContactDetail with
    | Email _ -> True "Maybe!"
    | _ -> False "No!"

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    let uc = createUnsafeCustomer "Jimmy" "J57" "0762415677" "jimmy@jimmy.com"
    let sc =
        createSafeCustomer
            (CustomerId "J57")
            (CustomerName "Jimmy")
            (PhoneNumber "0762415677")
            (EmailAddress "jimmy@jimmy.com")
    let stc_Phone = createSuperTypedCustomer (CustomerId "J57")(CustomerName "Jimmy")(Phone"0762415677")
    let stc_Email = createSuperTypedCustomer (CustomerId "J57")(CustomerName "Jimmy")(Email"jimmy@jimmy.com")

    let stc_PhoneHasEmail = HasCustomerAnEmail stc_Phone
    let stc_EmailHasEmail = HasCustomerAnEmail stc_Email

    let x = HasCustomerAnOutlookEmail stc_Email

    printfn "%A" uc
    printfn "%A" sc
    printfn "%A" stc_Phone
    printfn "%A" stc_PhoneHasEmail
    printfn "%A" stc_EmailHasEmail
    0 // return an integer exit code
