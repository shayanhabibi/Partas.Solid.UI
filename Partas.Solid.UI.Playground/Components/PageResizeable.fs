[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageResizeable

open Partas.Solid
open Partas.Solid.UI
open Fable.Core

[<Erase>]
type PageResizeable() =
    inherit VoidNode()
    [<SolidTypeComponentAttribute>]
    member props.constructoro =
        div(class' = "size-full flex p-6 items-center justify-center") {
            Resizeable(class' = "max-w-md rounded-lg border") {
                ResizeablePanel(initialSize = 0.25, class' = "overflow-hidden") {
                    div(class' = "flex h-[200px] items-center justify-center p-6") {
                        span(class' = "font-semibold") {"One"}
                    }
                }
                ResizeablePanel(initialSize=0.75, class' = "overflow-hidden") {
                    Resizeable(orientation = Corvu.Orientation.Vertical) {
                        ResizeablePanel(initialSize = 0.5, class' = "overflow-hidden") {
                            div(class' = "flex h-full items-center justify-center p-6") {
                                span(class' = "font-semibold") { "Two" }
                            }
                        }
                        ResizeablePanel(initialSize = 0.5, class' = "overflow-hidden") {
                            div(class' = "flex h-full items-center justify-center p-6") {
                                span(class' = "font-semibold") { "Three" }
                            }
                        }
                    }
                }
            }
        }