namespace Partas.Solid.UI

open Partas.Solid
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type DeltaBar() =
    inherit div()
    [<Erase>] member val value: int = unbox null with get,set 
    [<Erase>] member val isIncreasePositive: bool = unbox null with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.isIncreasePositive <- true
        let barColor () =
            match props.value > 0, props.isIncreasePositive with
            | true, true
            | false, false -> "bg-success-foreground"
            | _ -> "bg-error-foreground"
        let absValue () = JS.Math.abs !!props.value
        div(class' = Lib.cn [|
            "relative flex h-2 w-full items-center rounded-full bg-secondary"
            props.class'
        |]).spread(props) {
            div(class' = "flex h-full w-1/2 justify-end") {
                if props.value < 0 then div(class' = Lib.cn [| "rounded-l-full"; barColor() |]).style' {| width = $"{absValue()}%%" |}
                div(class' = Lib.cn [|
                    "z-10 h-4 w-1 rounded-full ring-2 ring-background"
                    barColor()
                |])
                div(class' = "flex h-full w-1/2 justify-start") {
                    if props.value > 0 then div(class' = Lib.cn [| "rounded-r-full" ; barColor() |]).style' {| width = $"{absValue()}%%" |}
                }
            }
        }