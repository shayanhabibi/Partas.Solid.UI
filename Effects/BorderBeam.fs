namespace Partas.Solid.UI

open Partas.Solid
open Fable.Core

/// <summary>
/// Ensure you have the following added to your tailwind configuration: <code>
///export default {
///  "theme": {
///    "extend": {
///      "animation": {
///        "border-beam": "border-beam var(--duration) infinite linear"
///      },
///      "keyframes": {
///        "border-beam": {
///          "100%": {
///            "offsetDistance": "100%"
///          }
///        }
///      }
///    }
///  }
///}
/// </code>
/// </summary>
[<Erase>]
type BorderBeam() =
    inherit VoidNode()
    [<Erase>] member val anchor: int = unbox null with get,set
    [<Erase>] member val borderWidth: float = unbox null with get,set
    [<Erase>] member val colorFrom: string = unbox null with get,set
    [<Erase>] member val colorTo: string = unbox null with get,set
    [<Erase>] member val delay: int = unbox null with get,set
    [<Erase>] member val duration: int = unbox null with get,set
    [<Erase>] member val size: int = unbox null with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.anchor <- 90
        props.borderWidth <- 1.5
        props.colorFrom <- "#ffaa40"
        props.colorTo <- "#9c40ff"
        props.delay <- 0
        props.duration <- 15
        props.size <- 200
        
        let style = JsInterop.createObj [
                "--size", $"{props.size}px"
                "--duration", $"{props.duration}s"
                "--anchor", $"{props.anchor}%%"
                "--border-width", $"{props.borderWidth}px"
                "--color-from", props.colorFrom
                "--color-to", props.colorTo
                "--delay", $"-{props.delay}s"
        ]
        div(
            class' = Lib.cn [|
                "pointer-events-none absolute inset-0 rounded-[inherit] [border:var(--border-width)_solid_transparent]"                
                // mask styles
                "![mask-clip:padding-box,border-box] ![mask-composite:intersect] [mask:linear-gradient(transparent,transparent),linear-gradient(white,white)]"                
                // pseudo styles
                "after:absolute after:aspect-square after:w-[var(--size)] after:animate-border-beam after:[animation-delay:var(--delay)] after:[background:linear-gradient(to_left,var(--color-from),var(--color-to),transparent)] after:[offset-anchor:var(--anchor)_50%] after:[offset-path:rect(0_auto_auto_0_round_var(--size))]"
                props.class'
            |]
        )   .style'(style)