module Commands
open Fable.Core
open Fable.Core.Rust

[<Erase; Emit("String")>]
type StringHeap = interface end

[<Erase; Emit("&str")>]
type StrRef = interface end


[<Emit("$0.as_ref()")>]
let asRef x = nativeOnly

[<Emit("$0.to_string()")>]
let toString x = nativeOnly


[<OuterAttr("tauri::command")>]
let greet (name: StrRef) :StringHeap = 
  toString (asRef $"Hello, {name}! You've been greeted from Rust!")

[<OuterAttr("tauri::command")>]
let add (arg1: int) (arg2: int): int = arg1 + arg2