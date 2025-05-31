[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageFlex

open Partas.Solid
open Partas.Solid.UI
open Fable.Core

[<Erase>]
type PageFlex() =
    interface VoidNode
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(class' = "w-full items-center justify-center flex") {
            Card(class' = "w-full max-w-xs p-6") {
                Flex() {
                    div() {
                        p(class' = "text-sm font-normal text-gray-500") { "Tickets Sold" }
                        p(class' = "text-3xl font-semibold text-gray-700") { "9,876" }
                    }
                    div() {
                        p(class' = "text-sm font-normal text-gray-500") { "Average Selling Price" }
                        p(class' = "text-3xl font-semibold text-gray-700") { "$ 175.20" }
                    }
                }
            }
        }
