[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageToggle

open Partas.Solid.Lucide
open Partas.Solid
open Partas.Solid.UI
open Fable.Core
open Partas.Solid.Aria

[<Erase>]
type PageToggle() =
    interface VoidNode
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        let pressed,setPressed = createSignal(false)
        div(class' = "w-full flex flex-col gap-8 items-center justify-center p-6") {
            Toggle(onChange = setPressed) {
                if pressed() then
                    Sun(class' = "size-6")
                else
                    Moon(class' = "size-6")
            }
            ToggleGroup(multiple = true) {
                ToggleGroupItem(value = "bold", ariaLabel = "Bold") { Bold(class' = "size-6") }
                ToggleGroupItem(value = "italic", ariaLabel = "Italic") { Italic(class' = "size-6") }
                ToggleGroupItem(value = "underline", ariaLabel = "Underline") { Underline(class' = "size-6") }
                
            }
        }
