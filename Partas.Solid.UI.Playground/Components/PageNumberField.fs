[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageNumberField

open Partas.Solid.Kobalte.Enums
open Partas.Solid
open Partas.Solid.UI
open Fable.Core

[<Erase>]
type PageNumberField() =
    inherit VoidNode()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        let rawValue, setRawValue = createSignal<float>(JS.undefined)
        div(class' = "flex p-6 w-full") {
            NumberField(class' = "flex w-36 flex-col flex gap-2",
                        onRawValueChange = setRawValue,
                        validationState = if rawValue() <> 40 then ValidationState.Invalid else ValidationState.Valid) {
                NumberFieldGroup() {
                    NumberFieldInput()
                    NumberFieldIncrementTrigger()
                    NumberFieldDecrementTrigger()
                }
                NumberFieldErrorMessage() { "Hmm, I prefer 40." }
            }
        }
