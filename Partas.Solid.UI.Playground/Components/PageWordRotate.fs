[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageWordRotate

open Partas.Solid
open Partas.Solid.UI
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type PageWordRotate() =
    inherit VoidNode()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(class' = "w-full flex items-center justify-center p-8 overflow-hidden py-2") {
            WordRotate(class' = "text-4xl md:text-6xl font-bold", words = [| "Word" ; "Rotate" |])
        }