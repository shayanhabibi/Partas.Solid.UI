namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Kobalte
open Fable.Core

[<Erase>]
type TooltipTrigger() =
    inherit Tooltip.Trigger()
    [<SolidTypeComponentAttribute>]
    member props.constructor = Tooltip.Trigger().spread props

[<Erase>]
type Tooltip() =
    inherit Kobalte.Tooltip()
    [<SolidTypeComponentAttribute>]
    member props.constructor = Kobalte.Tooltip(gutter = 4).spread props

[<Erase>]
type TooltipContent() =
    inherit Tooltip.Content()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        Tooltip.Portal() {
            Tooltip.Content(
                class' =
                    Lib.cn [|
                        "z-50 origin-[var(--kb-popover-content-transform-origin)] overflow-hidden rounded-md border bg-popover px-3 py-1.5 text-sm text-popover-foreground shadow-md animate-in fade-in-0 zoom-in-95"
                        props.class'
                    |]
                ).spread props
        }