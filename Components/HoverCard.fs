namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Kobalte
open Fable.Core

[<Erase>]
type HoverCardTrigger() =
    inherit HoverCard.Trigger()
    [<SolidTypeComponent>]
    member props.constructor = HoverCard.Trigger().spread props
    
[<Erase>]
type HoverCard() =
    inherit Kobalte.HoverCard()
    [<SolidTypeComponent>]
    member props.constructor = Kobalte.HoverCard(gutter = 4).spread props

[<Erase>]
type HoverCardContent() =
    inherit HoverCard.Content()
    [<SolidTypeComponent>]
    member props.constructor =
        HoverCard.Portal() {
            HoverCard.Content(class' = Lib.cn [|
                "z-50 w-64 rounded-md border bg-popover p-4 text-popover-foreground
                shadow-md outline-none data-[state=open]:animate-in data-[state=closed]:animate-out
                data-[state=closed]:fade-out-0 data-[state=open]:fade-in-0
                data-[state=closed]:zoom-out-95 data-[state=open]:zoom-in-95
                data-[side=bottom]:slide-in-from-top-2 data-[side=left]:slide-in-from-right-2
                data-[side=right]:slide-in-from-left-2 data-[side=top]:slide-in-from-bottom-2"
                props.class'
            |]).spread(props)
        }
