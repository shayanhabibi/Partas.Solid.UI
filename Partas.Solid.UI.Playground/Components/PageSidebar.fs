[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageSidebar

open Partas.Solid
open Partas.Solid.UI
open Fable.Core

[<Erase>]
type PageSidebar() =
    inherit VoidNode()
    [<SolidTypeComponent>]
    member props.constructor =
        div() {
            Lucide.Lucide.ArrowLeft()
        }