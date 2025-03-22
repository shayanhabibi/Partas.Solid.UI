[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageTextEffects

open Partas.Solid
open Partas.Solid.UI
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type PageTextEffects() =
    inherit VoidNode()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(
            class' = "w-full flex flex-col gap-8 items-center justify-center"
        ) {
            div(class' = "w-full flex items-center justify-center p-8 overflow-hidden py-2") {
                WordRotate(class' = "text-4xl md:text-6xl font-bold", words = [| "Word" ; "Rotate" |])
            }
            
            WordPullup(text = "Pullup Words")
        }
