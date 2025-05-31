namespace Partas.Solid.UI

open Fable.Core
open Fable.Core.JS
open Fable.Core.JsInterop
open Partas.Solid
open Partas.Solid.Aria
open Partas.Solid.Experimental.U

[<Erase>]
type DotPattern() =
    inherit Svg.svg()
    [<Erase>] member val width: int = undefined with get,set
    [<Erase>] member val height: int = undefined with get,set
    [<Erase>] member val x: float = undefined with get,set
    [<Erase>] member val y: float = undefined with get,set
    [<Erase>] member val cx: float = undefined with get,set
    [<Erase>] member val cy: float = undefined with get,set
    [<Erase>] member val cr: float = undefined with get,set
    [<Erase>] member val class': string = undefined with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.width <- 16
        props.height <- 16
        props.x <- 0.
        props.y <- 0.
        props.cx <- 1.
        props.cy <- 1.
        props.cr <- 1.
        let id = createUniqueId()
        Svg.svg(class' = Lib.cn [|
            "pointer-events-none absolute inset-0 h-full w-full fill-neutral-400/80"
            props.class'
        |]) .spread props {
            Svg.defs() {
                Svg.pattern(
                    id = id,
                    width = !!props.width,
                    height = !!props.height,
                    patternUnits = "userSpaceOnUse",
                    x = !^props.x,
                    y = !^props.y
                ) {
                    Svg.circle(
                        id = "pattern-circle",
                        cx = !^props.cx,
                        cy = !^props.cy,
                        r = !^props.cr
                    )
                }
            }
            Svg.rect(
                    width = "100%",
                    strokeWidth = "0",
                    fill = $"url(#{id})",
                    height = "100%"
                )
        }
        
