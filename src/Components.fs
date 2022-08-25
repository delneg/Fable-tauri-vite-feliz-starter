namespace App

open Fable.Core.JS
open Fable.Core.JsInterop
open Feliz
open Feliz.DaisyUI
module Tauri =
  
  let invoke (fnName: string) (args: obj): Promise<string> = importMember "@tauri-apps/api/tauri"
  
type Components =
  /// <summary>
  /// Simple react component with button increase
  /// </summary>
  [<ReactComponent>]
  static member HelloWorld() =
    let (count, setCount) = React.useState 0
    let (name, setName) = React.useState ""
    let (greetMsg, setGreetMsg) = React.useState ""

    let greet() =
      promise {
        let! msg = Tauri.invoke "greet" (createObj [ "name" ==> name ])
        setGreetMsg(msg)
        return ()
      }
      
    Html.div [
      Daisy.button.button [
        button.primary
        prop.onClick (fun _ -> setCount (count + 1))
        prop.text ("Increment: " + string count)
      ]
      Html.div [
        Daisy.input [
          input.accent
          prop.id "greet-input"
          prop.onChange (fun (e: Browser.Types.Event) -> setName(e.currentTarget?value))
          prop.placeholder "Enter a name..."
        ]
        Daisy.button.button [
          button.accent
          prop.onClick (fun _ -> greet() |> ignore)
          prop.text "Greet"
        ]
        Html.p [
          prop.text greetMsg
        ]
      ]
    ]