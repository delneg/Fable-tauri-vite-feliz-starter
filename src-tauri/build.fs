open Fable.Core
open Fable.Core.Rust
import "tauri_build::*" ""

[<Emit("tauri_build::build()")>]
let build (): unit = nativeOnly

[<EntryPoint>]
let main _args =
    build()
    0
    
