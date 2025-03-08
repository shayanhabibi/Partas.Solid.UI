namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Kobalte
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type Separator() =
    inherit Kobalte.Separator()
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.Separator(class' = Lib.cn [|
            "shrink-0 bg-border"
            if props.orientation = Orientation.Vertical then
                "h-full w-px"
            else "h-px w-full"
            props.class'
        |], orientation = (props.orientation ??= Orientation.Horizontal)).spread(props)

