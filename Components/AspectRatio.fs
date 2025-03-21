namespace Partas.Solid.UI

open Fable.Core
open Partas.Solid

[<Erase>]
type AspectRatio() =
    inherit div()
    [<Erase>] member val ratio: float = unbox null with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.ratio <- 1./1.
        div().style' {| position = "relative"; width = "100%"; ``padding-bottom`` = $"{100. / props.ratio}%%" |} {
            div()
                .style'({|
                    position = "absolute"
                    top = 0
                    right = 0
                    bottom = 0
                    left = 0
                |})
                .spread props
        }