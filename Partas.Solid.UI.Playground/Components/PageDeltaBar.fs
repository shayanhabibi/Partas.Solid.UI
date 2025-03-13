[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageDeltaBar

open Partas.Solid
open Partas.Solid.UI
open Fable.Core

[<Erase>]
type PageDeltaBar() =
    inherit VoidNode()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(class' = "flex w-full items-center justify-center p-6 flex-col gap-4") {
            DeltaBar(value = 60, isIncreasePositive = true)
            DeltaBar(value = 30, isIncreasePositive = false)
            DeltaBar(value = -15, isIncreasePositive = false)
            DeltaBar(value = -30, isIncreasePositive = true)
        }