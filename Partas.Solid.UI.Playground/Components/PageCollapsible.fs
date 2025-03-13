[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageCollapsible

open Partas.Solid
open Partas.Solid.UI
open Fable.Core

[<Erase>]
type PageCollapsible() =
    inherit VoidNode()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(class' = "w-full p-6") {
            Collapsible(class' = "w-[300px]") {
                CollapsibleTrigger(class' = "flex w-full items-center justify-between rounded-md border p-3") {
                    span() {"What is Partas.Solid"}
                    Lucide.Lucide.ChevronDown()
                }
                CollapsibleContent(class' = "mt-2 rounded-md border p-3") {
                    "Partas.Solid is a Fable plugin and bindings library for the Solid-js framework."
                }
            }
        }