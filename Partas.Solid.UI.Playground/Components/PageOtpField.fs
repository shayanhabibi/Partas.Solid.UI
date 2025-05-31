[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageOtpField

open Partas.Solid
open Partas.Solid.UI
open Fable.Core

[<Erase>]
type PageOtpField() =
    interface VoidNode
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(class' = "w-full flex p-6") {
            OtpField(maxLength = 6) {
                OtpFieldInput()
                OtpFieldGroup() {
                    OtpFieldSlot(index = 0)
                    OtpFieldSlot(index = 1)
                    OtpFieldSlot(index = 2)
                }
                OtpFieldSeparator()
                OtpFieldGroup() {
                    OtpFieldSlot(index = 3)
                    OtpFieldSlot(index = 4)
                    OtpFieldSlot(index = 5)
                }
                
            }
        }
