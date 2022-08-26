//[<Fable.Core.Rust.InnerAttr("cfg_attr", [|
//    "all(not(debug_assertions), target_os = \"windows\")"
//    "windows_subsystem = \"windows\""
//  |])>]
module Main
open Fable.Core
open Fable.Core.Rust


[<OuterAttr("tauri::command")>]
let greet ([<ByRef>] name: string) = 
  $"Hello, {name}! You've been greeted from Rust!"

[<OuterAttr("tauri::command")>]
let add (arg1: int) (arg2: int): int = arg1 + arg2

[<Emit("""tauri::Builder::default().invoke_handler(tauri::generate_handler![greet,add]).run(tauri::generate_context!()).expect("error while running tauri application");""")>]
let default_builder (): unit = nativeOnly


[<EntryPoint>]
let main _ =
  default_builder()
  0