module Main

open Feliz
open App
open Browser.Dom

Fable.Core.JsInterop.importSideEffects "./index.css"

console.log("Fable is up and running...");

ReactDOM.render(
    Components.HelloWorld(),
    document.getElementById "feliz-app"
)