[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageAlert

open Partas.Solid.UI
open Partas.Solid
open Partas.Solid.Lucide
open Fable.Core

[<Erase>]
type PageAlert() =
    inherit VoidNode()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(class' = "size-full") {
            Alert() { "Default" }
            Alert(variant = alert.variant.destructive) { "Destructive" }
            Alert() {
                Lucide.Accessibility()
                span() {"Accessible"}
            }
        }
