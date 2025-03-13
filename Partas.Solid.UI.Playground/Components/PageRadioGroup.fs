[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageRadioGroup

open Partas.Solid
open Partas.Solid.UI
open Fable.Core

[<Erase>]
type PageRadioGroup() =
    inherit VoidNode()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(class' = "flex w-full p-6 items-center justify-center") {
            RadioGroup() {
                For(each =
                        [|
                            "Apple"
                            "Orange"
                            "Watermelon"
                        |]) {
                    yield fun item index ->
                        RadioGroupItem(value = item) {
                            RadioGroupItemLabel() { item }
                        }
                }
            }
        }
