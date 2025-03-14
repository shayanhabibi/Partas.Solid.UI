[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageSeparator

open Partas.Solid
open Partas.Solid.Kobalte
open Partas.Solid.UI
open Fable.Core

[<Erase>]
type PageSeparator() =
    inherit VoidNode()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div() {
            div(class' = "space-y-1") {
                h4(class' = "text-sm font-medium leading-none") { "Partas.Solid.UI" }
                p(class' = "text-sm text-muted-foreground") { "Port of Solid-UI; an open source UI Component library." }
            }
            Separator(class' = "my-4")
            div(class' = "flex h-5 items-center space-x-4 text-sm") {
                div() { "Blog" }
                Separator(orientation = Orientation.Vertical)
                div() { "Docs" }
                Separator(orientation = Orientation.Vertical)
                div() { "Source" }
            }
        }
