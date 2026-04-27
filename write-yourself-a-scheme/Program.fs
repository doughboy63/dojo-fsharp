// For more information see https://aka.ms/fsharp-console-apps

open System
open NUnit.Framework
open FsUnit

[<Test>]
let ``test hello`` () =
    5 + 1 |> should equal 7
