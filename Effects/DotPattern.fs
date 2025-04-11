namespace Partas.Solid.UI

open Fable.Core
open Fable.Core.JS
open Fable.Core.JsInterop
open Partas.Solid
open Partas.Solid.Aria

[<Erase>]
type DotPattern() =
    inherit Svg.svg()
    [<Erase>] member val width: int = undefined with get,set
    [<Erase>] member val height: int = undefined with get,set
    [<Erase>] member val x: int = undefined with get,set
    [<Erase>] member val y: int = undefined with get,set
    [<Erase>] member val cx: int = undefined with get,set
    [<Erase>] member val cy: int = undefined with get,set
    [<Erase>] member val cr: int = undefined with get,set
    [<Erase>] member val class': string = undefined with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.width <- 16
        props.height <- 16
        props.x <- 0
        props.y <- 0
        props.cx <- 1
        props.cy <- 1
        props.cr <- 1
        let id = createUniqueId()
        Svg.svg(class' = Lib.cn [|
            "pointer-events-none absolute inset-0 h-full w-full fill-neutral-400/80"
            props.class'
        |]) .attr("aria-hidden", !!true)
            .spread props {
            Svg.defs() {
                Svg.pattern(
                    id = id,
                    width = !!props.width,
                    height = !!props.height,
                    patternUnits = "userSpaceOnUse",
                    x = !!props.x,
                    y = !!props.y
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
                    height = "100%"
                )   .attr("stroke-width", !!0)
                    .attr("fill", $"url(#{id})")
        }
    
