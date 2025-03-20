[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageGrid

open Partas.Solid
open Partas.Solid.UI
open Fable.Core
open Fable.Core.JsInterop


[<Erase>]
type PageGrid() =
    inherit VoidNode()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        Grid(
            cols = Cols._1,
            colsMd = Cols._2,
            colsLg = Cols._3,
            class' = "w-full gap-2"
        ) {
            Col(span = Span._1, spanLg = Span._2) {
                Card() {
                    CardHeader() {
                        CardTitle() { "Title" }
                    }
                    CardContent() { "KPI 1" }
                }
            }
            Card() {
                CardHeader() {
                    CardTitle() { "Title" }
                }
                CardContent() { "KPI 2" }
            }
            Col() {
                Card() {
                    CardHeader() {
                        CardTitle() { "Title" }
                    }
                    CardContent() { "KPI 3" }
                }
            }
            Card() {
                CardHeader() {
                    CardTitle() { "Title" }
                }
                CardContent() { "KPI 4" }
            }
            Card() {
                CardHeader() {
                    CardTitle() { "Title" }
                }
                CardContent() { "KPI 5" }
            }
        }
