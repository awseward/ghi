// Learn more about F# at http://fsharp.org

open System

type RepoId = string * string

type Command =
  | List

exception InvalidCommandException of string

let parseCommand (command: string) =
  match command.ToLowerInvariant() with
  | "list" -> List
  | _ -> raise (InvalidCommandException command)

let getRepoId localPath =
  let id : RepoId = "awseward", "ghi"
  id

let executeCommand args command =
  match command with
  | List ->
    printfn "TODO: Implement list %A" args
    let owner, repo = getRepoId "TODO"
    printfn "https://api.github.com/repos/%s/%s/issues" owner repo

    1

[<EntryPoint>]
let main argv =
  match argv with
  | [| |] ->
    printfn "Usage: TODO"

    1
  | _ ->
    try
      argv
      |> Seq.head
      |> parseCommand
      |> executeCommand (argv |> Array.toList |> List.tail)
    with
    | InvalidCommandException cmd ->
        printfn "Error: Command `%s` does not exist" cmd

        1
