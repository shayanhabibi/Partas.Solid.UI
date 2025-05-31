namespace Partas.Solid.UI

open Fable.Core
open Partas.Solid.Aria
open Fable.Core.JS
open Fable.Core.JsInterop
open Partas.Solid
open Partas.Solid.Style
open Partas.Solid.Motion
open Partas.Solid.Experimental
open Partas.Solid.Experimental.U
open Browser.Types
open Browser.ResizeObserver
open Partas.Solid.Primitives.Tween
open Partas.Solid.Primitives.Timer

type private DV = DefaultValueAttribute

[<Erase>]
type AnimatedBeam() =
    interface VoidNode
    [<Erase>] member val curvature: int = JS.undefined with get,set
    [<Erase>] member val reverse: bool = JS.undefined with get,set
    [<Erase>] member val duration: int = JS.undefined with get,set
    [<Erase>] member val delay: int = JS.undefined with get,set
    [<Erase>] member val pathColor: string = JS.undefined with get,set
    [<Erase>] member val pathWidth: int = JS.undefined with get,set
    [<Erase>] member val pathOpacity: float = JS.undefined with get,set
    [<Erase>] member val gradientStartColor: string = JS.undefined with get,set
    [<Erase>] member val gradientStopColor: string = JS.undefined with get,set
    [<Erase>] member val startXOffset: int = JS.undefined with get,set
    [<Erase>] member val startYOffset: int = JS.undefined with get,set
    [<Erase>] member val endXOffset: int = JS.undefined with get,set
    [<Erase>] member val endYOffset: int = JS.undefined with get,set
    [<Erase>] member val containerRef: HTMLElement = JS.undefined with get,set
    [<Erase>] member val fromRef: HTMLElement = JS.undefined with get,set
    [<Erase>] member val toRef: HTMLElement = JS.undefined with get,set
    [<SolidTypeComponent>]
    member props.__ =
        props.curvature <- 0
        props.reverse <- false
        props.duration <- !!Math.random() * 3 + 4
        props.delay <- 0
        props.pathColor <- !!Color.Gray
        props.pathWidth <- 2
        props.pathOpacity <- 0.2
        props.gradientStartColor <- "#ffaa40"
        props.gradientStopColor <- "#9c40ff"
        props.startXOffset <- 0
        props.startYOffset <- 0
        props.endXOffset <- 0
        props.endYOffset <- 0
        let gradientCoordinates =
            if props.reverse then
                {|
                    x1 = [| "90%"; "-10%" |]
                    x2 = [| "100%"; "0%" |]
                    y1 = [| "0%"; "0%" |]
                    y2 = [| "0%"; "0%" |]
                |}
            else
                {|
                    x1 = [| "10%"; "110%" |]
                    x2 = [| "0%"; "100%" |]
                    y1 = [| "0%"; "0%" |]
                    y2 = [| "0%"; "0%" |]
                |}
        let uid = createUniqueId()
        let pathD,setPath = createSignal ""
        let svgDimensions, setSvgDimensions = createSignal({| Width = 0; Height = 0 |})
        createEffect(fun () ->
            let updatePath = fun () ->
                if props.containerRef &&= props.fromRef &&= !!props.toRef then
                    let containerRect = (props.containerRef |> unbox<HTMLElement>).getBoundingClientRect()
                    let rectA = props.fromRef.getBoundingClientRect()
                    let rectB = props.toRef.getBoundingClientRect()
                    
                    let svgWidth = containerRect.width
                    let svgHeight = containerRect.height
                    setSvgDimensions({| Height = int svgHeight; Width = int svgWidth |})
                    
                    let startX, startY, endX, endY =
                        (rectA.left - containerRect.left + rectA.width / 2. + float props.startXOffset)
                        ,(rectA.top - containerRect.top + rectA.height / 2. + float props.startYOffset)
                        ,(rectB.left - containerRect.left + rectB.width / 2. + float props.endXOffset)
                        ,(rectB.top - containerRect.top + rectB.height / 2. + float props.endYOffset)
                    let controlY = startY - !!props.curvature
                    let d = $"M {startX}, {startY} Q {(startX + endX) / 2.}, {controlY} {endX},{endY}"
                    setPath(d)
            
            let resizeObserver = ResizeObserver.Create(fun entries ->
                for entry in entries do
                    updatePath()
                !! ()
                )
            
            if !!props.containerRef then
                resizeObserver.observe(props.containerRef)
            
            updatePath()
            
            onCleanup( fun () ->
                resizeObserver.disconnect()
            )
        )
        let mutable linearGrad: HTMLElement = null
        mount {
            let controls = animate(linearGrad, gradientCoordinates, AnimateTransition(
                    duration = props.duration,
                    delay = props.delay,
                    ease = !![|0.16; 1; 0.3; 1|],
                    repeat = Infinity
                ))
            onCleanup(fun () ->
                controls.stop()
            )
        }
        Svg.svg(
            fill = "none",
            ariaHidden = true,
            width = !!svgDimensions().Width,
            height = !!svgDimensions().Height,
            xmlns = "http://www.w3.org/2000/svg",
            class' = Lib.cn [|
                "pointer-events-none absolute left-0 top-0 transform-gpu stroke-2"
                props.class'
            |],
            viewBox = $"0 0 {svgDimensions().Width} {svgDimensions().Height}"
            ) {
            Svg.path(
                d = pathD(),
                stroke = props.pathColor,
                strokeWidth = !!props.pathWidth,
                strokeOpacity = !!props.pathOpacity,
                strokeLinecap = "round"
                )
            Svg.path(
                d = pathD(),
                strokeWidth = !!props.pathWidth,
                stroke = $"url(#{uid})",
                strokeOpacity = "1",
                strokeLinecap = "round"
                )
            Svg.defs() {
                Svg.linearGradient(
                    class' = "transform-gpu",
                    id = uid,
                    gradientUnits = "userSpaceOnUse"
                    ).ref(linearGrad) {
                    Svg.stop(stopColor = props.gradientStartColor, stopOpacity = "0")
                    Svg.stop(stopColor = props.gradientStartColor)
                    Svg.stop(offset = "32.5%", stopColor = props.gradientStopColor)
                    Svg.stop(offset = "100%", stopColor = props.gradientStopColor, stopOpacity = "0%")
                }
            }
        }
    
