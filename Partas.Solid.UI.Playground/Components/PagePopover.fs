[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PagePopover

open Partas.Solid
open Partas.Solid.UI
open Fable.Core
open Partas.Solid.Polymorphism

[<Erase>]
type PagePopover() =
    inherit VoidNode()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(class' = "w-full flex p-6") {
            Popover() {
                PopoverTrigger().as'(Button()) { "Trigger me" }
                PopoverContent() { "A Fable Plugin for building accessible web apps and design systems with SolidJS" }
            }
        }