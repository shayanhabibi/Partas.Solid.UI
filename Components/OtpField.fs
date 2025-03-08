namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Corvu
open Fable.Core

[<Erase>]
type OtpField() =
    inherit Corvu.OtpField()
    [<SolidTypeComponent>]
    member props.constructor =
        Corvu.OtpField(class' = Lib.cn [|
            "flex items-center gap-2 disabled:cursor-not-allowed has-[:disabled]:opacity-50"
            props.class'
        |]).spread(props)

[<Erase>]
type OtpFieldInput() =
    inherit OtpField.Input()
    [<SolidTypeComponent>]
    member props.constructor = Corvu.OtpField.Input().spread props
        

[<Erase>]
type OtpFieldGroup() =
    inherit div()
    [<SolidTypeComponent>]
    member props.constructor =
        div(class' = Lib.cn [|
            "flex items-center"
            props.class'
        |]).spread props

[<Erase>]
type OtpFieldSlot() =
    inherit div()
    member val index: int = jsNative with get,set
    // [<SolidTypeComponent>]
    // member props.constructor =
        //todo

[<Erase; RequireQualifiedAccess>]
module OtpField =
    [<Import("useContext","@corvu/otp-field")>]
    let useContext () = jsNative

[<Erase>]
type OtpFieldSeparator() =
    inherit div()
    [<SolidTypeComponent>]
    member props.constructor =
        div().spread(props) {
            Lucide.Lucide.Dot(class'="size-6", strokeWidth = 2)
        }

