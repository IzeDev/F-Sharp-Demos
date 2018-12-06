namespace SomeAPI

module Operations =
    module private InnerOperations =
        let someCalculation x y = x + y

    let someCalculation x y =
        InnerOperations.someCalculation x y;