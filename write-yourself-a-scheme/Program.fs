// For more information see https://aka.ms/fsharp-console-apps

//open System
open FParsec

type LispState = unit // doesn't have to be a unit
type Parser<'t> = Parser<'t, LispState>

let pSymbol: Parser<_> = anyOf "!#$%&|*+-/:<=>?@^_~"

let readExpr input = 
    match run pSymbol input with 
    | Failure (_, err, _) -> sprintf "No match: %s" (err.ToString())
    | Success _ -> "Found value"

[<EntryPoint>]
let main argv =
    let input = if argv.Length = 0 then "" else argv.[0]
    let result = readExpr input
    printfn "%s\n" result
    0 // return an integer exit code

