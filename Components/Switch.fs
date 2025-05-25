namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Kobalte
open Fable.Core

[<Erase>]
type Switch()=
    inherit Kobalte.Switch()
    [<SolidTypeComponent>]
    member props.constructor = Kobalte.Switch().spread props
        
[<Erase>]
type SwitchDescription() =
    inherit Switch.Description()
    [<SolidTypeComponent>]
    member props.constructor = Switch.Description().spread props
        
[<Erase>]
type SwitchErrorMessage() =
    inherit Switch.ErrorMessage()
    [<SolidTypeComponent>]
    member props.constructor = Switch.ErrorMessage().spread props
        
[<Erase>]
type SwitchControl()=
    inherit Switch.Control()
    [<SolidTypeComponent>]
    member props.constructor =
        Fragment() {
            Switch.Input( class' = Lib.cn [|
                    "[&:focus-visible+div]:outline-none [&:focus-visible+div]:ring-2
                    [&:focus-visible+div]:ring-ring [&:focus-visible+div]:ring-offset-2
                    [&:focus-visible+div]:ring-offset-background"
                    props.class' |] )
            Switch.Control(class' = Lib.cn [|
                "inline-flex h-6 w-11 shrink-0 cursor-pointer items-center rounded-full
                border-2 border-transparent bg-input transition-[color,background-color,box-shadow]
                data-[disabled]:cursor-not-allowed data-[checked]:bg-primary data-[disabled]:opacity-50"
                props.class'
            |]).spread(props) { props.children }
        }

[<Erase>]
type SwitchThumb() =
    inherit Switch.Thumb()
    [<SolidTypeComponent>]
    member props.constructor =
        Switch.Thumb(
            class' = Lib.cn [|
                "pointer-events-none block size-5 translate-x-0 rounded-full bg-background
                shadow-lg ring-0 transition-transform data-[checked]:translate-x-5"
                props.class'
            |]
            ).spread props

[<Erase>]
type SwitchLabel() =
    inherit Switch.Label()
    [<SolidTypeComponent>]
    member props.constructor =
        Switch.Label(class' = Lib.cn [|
            "text-sm font-medium leading-none
            data-[disabled]:cursor-not-allowed data-[disabled]:opacity-70"
            props.class'
        |]).spread props

