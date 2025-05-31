namespace Partas.Solid.UI

open Fable.Core
open Partas.Solid
open Partas.Solid.Style

[<Erase>]
type AspectRatio() =
    inherit div()
    [<Erase>] member val ratio: float = unbox null with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.ratio <- 1./1.
        div().style'([
            Style.position Position.Relative
            Style.width "100%"
            Style.paddingBottom $"{100. / props.ratio}%%"
        ]) {
            div().style'([
                Style.position Position.Absolute
                Style.top "0"
                Style.right "0"
                Style.bottom "0"
                Style.left "0"
            ])
                .spread props
        }
