[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageSkeleton

open Partas.Solid
open Partas.Solid.UI
open Fable.Core

[<Erase>]
type PageSkeleton() =
    interface VoidNode
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(class' = "flex items-center space-x-4") {
            Skeleton(height = 48, circle = true, animate = false)
            div(class' = "space-y-2") {
                Skeleton(height = 16, width = 250, radius = 10)
                Skeleton(height = 16, width = 200, radius = 10)
            }
        }
