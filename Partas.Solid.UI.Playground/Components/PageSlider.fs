[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageSlider

open Partas.Solid
open Partas.Solid.UI
open Fable.Core

[<Erase>]
type PageSlider() =
    interface VoidNode
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        Slider(
            minValue = 10,
            maxValue = 2000,
            defaultValue = [| 20; 500 |],
            getValueLabel = (fun param -> $"{param.values[0]} - {param.values[1]}"),
            class' = "w-[300px] space-y-3"
        ) {
            div(class' = "flex w-full justify-between") {
                SliderLabel() { "Money" }
                SliderValueLabel()
            }
            SliderTrack() {
                SliderFill()
                SliderThumb()
                SliderThumb()
            }
        }

