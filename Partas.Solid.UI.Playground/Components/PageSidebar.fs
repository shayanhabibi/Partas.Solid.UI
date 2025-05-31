[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageSidebar

open Partas.Solid
open Partas.Solid.UI
open Fable.Core

[<Erase>]
type PageSidebar() =
    interface VoidNode
    [<SolidTypeComponent>]
    member props.constructor =
        div() {
            Lucide.Lucide.ArrowLeft()
        }
