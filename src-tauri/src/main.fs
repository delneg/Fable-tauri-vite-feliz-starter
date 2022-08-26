[<Fable.Core.Rust.OuterAttr("cfg_attr", [|
"all(not(debug_assertions), target_os = \"windows\")"
"windows_subsystem = \"windows\""
|])>]
module Main

open Fable.Core
open Fable.Core.Rust

[<OuterAttr("tauri::command")>]
let greet (name: string): string =
  $"Hello, {name}! You've been greeted from Rust!"

[<Emit("""tauri::Builder::default().invoke_handler(tauri::generate_handler![greet]).run(tauri::generate_context!()).expect("error while running tauri application");""")>]
let default_builder (): unit = nativeOnly


let main() = 
  default_builder()