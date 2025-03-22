namespace Partas.Solid.UI

open Partas.Solid
open Fable.Core
open Fable.Core.JS
open Fable.Core.JsInterop
open Partas.Solid.Kobalte
open Partas.Solid.Polymorphism

[<Erase>]
type Progress() =
    inherit Kobalte.Progress()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        Kobalte.Progress().spread(props) {
            props.children
            Progress.Track(class' = "relative h-2 w-full overflow-hidden rounded-full bg-secondary") {
                Progress.Fill(class' = "h-full w-[var(--kb-progress-fill-width)] flex-1 bg-primary transition-all")
            }
            
        }

[<Erase>]
type ProgressLabel() =
    inherit Progress.Label()
    [<SolidTypeComponentAttribute>]
    member props.constructor = Progress.Label().as'(!@Label).spread(props)

[<Erase>]
type ProgressValueLabel() =
    inherit Progress.ValueLabel()
    [<SolidTypeComponentAttribute>]
    member props.constructor = Progress.ValueLabel().as'(!@Label).spread props

[<Erase>]
module progressCircle =
    [<StringEnum>]
    type Size =
        | Xs
        | Sm
        | Md
        | Lg
        | Xl
    
    let sizes = function
        | Xs -> {| radius = 15 ; strokeWidth = 3 |}
        | Sm -> {| radius = 19 ; strokeWidth = 4 |}
        | Md -> {| radius = 32 ; strokeWidth = 6 |}
        | Lg -> {| radius = 52 ; strokeWidth = 8 |}
        | Xl -> {| radius = 80; strokeWidth = 10 |}

open progressCircle

[<Erase>]
type ProgressCircle() =
    inherit div()
    [<Erase>] member val value: int = unbox null with get,set
    [<Erase>] member val size: Size = unbox null with get,set
    [<Erase>] member val radius: int = unbox null with get,set
    [<Erase>] member val strokeWidth: int = unbox null with get,set
    [<Erase>] member val showAnimation: bool = unbox null with get,set
    static member getLimitedValue (input: int) =
        if input = JS.undefined then 0
        elif input > 100 then 100
        else input
    [<SolidTypeComponent>]
    member props.constructor =
        props.size <- Md
        props.showAnimation <- true
        let value: unit -> float = fun () -> ProgressCircle.getLimitedValue(props.value)
        let radius = fun () -> float props.radius ??= float (sizes(props.size).radius)
        let strokeWidth = fun () -> float props.strokeWidth ??= float (sizes(props.size).strokeWidth)
        let normalizedRadius: unit -> float = fun () -> radius() - strokeWidth() / 2.
        let circumference = fun () -> normalizedRadius() * 2. * JS.Math.PI
        let strokeDashoffset = fun () -> (value() / 100.) * circumference()
        let offset = fun () -> circumference() - strokeDashoffset()
         
        div(
            class' = Lib.cn [|
                "flex flex-col items-center justify-center"
                props.class'
            |]
        ).spread props {
            Svg.svg(
                width = $"{radius() * 2.}",
                height = $"{radius() * 2.}",
                viewBox = $"0 0 {radius() * 2.} {radius() * 2.}",
                class' = "-rotate-90"
            ) {
                if value() >= 0 then
                    Svg.circle(
                        r = !!normalizedRadius(),
                        cx = !^radius(),
                        cy = !^radius(),
                        class' = Lib.cn [|
                            "stroke-primary transition-colors ease-linear"
                            if props.showAnimation then "transition-all duration-300 ease-in-out"
                            else ""
                        |]
                    )   .attr("stroke-width", !!strokeWidth())
                        .attr("fill", "transparent")
                        .attr("stroke", "")
                        .attr("stroke-linecap", !!Svg.StrokeLinecap.Round)
                        .attr("stroke-dasharray", $"{circumference()} {circumference()}")
                        .attr("stroke-dashoffset", $"{offset()}")
                else null
            }
            div(class' = "absolute flex") { props.children }
        }
         