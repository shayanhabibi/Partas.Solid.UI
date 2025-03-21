[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageProgress

open Partas.Solid
open Partas.Solid.UI
open Fable.Core

[<Erase>]
type PageProgress() =
    inherit VoidNode()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(class' = "w-full flex items-center justify-center p-6") {
            Progress(
                value = 3,
                minValue = 0,
                maxValue = 10,
                getValueLabel = (fun opts -> $"{opts.value} of {opts.max} tasks completed"),
                class' = "w-[300px] space-y-1"
            ) {
                div(class' = "flex justify-between") {
                    ProgressLabel() { "Processing..." }
                    ProgressValueLabel()
                }
            }
            
            ProgressCircle(value = 75)
        }
