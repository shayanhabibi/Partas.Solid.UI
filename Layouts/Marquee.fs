namespace Partas.Solid.UI

open Partas.Solid
open Fable.Core
open Fable.Core.JS
open Fable.Core.JsInterop
open System

[<Erase>]
type Marquee() =
    inherit div()
    [<Erase>] member val pauseOnHover: bool = undefined with get,set
    [<Erase>] member val repeat: int = undefined with get,set
    [<Erase>] member val reverse: bool = undefined with get,set
    [<Erase>] member val vertical: bool = undefined with get,set
    [<Erase>] member val duration: int = undefined with get,set
    [<Erase>] member val gap: string = undefined with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.reverse <- false
        props.pauseOnHover <- false
        props.vertical <- false
        props.repeat <- 4
        props.duration <- 40
        props.gap <- "1rem"
        div(
        class' = Lib.cn [|
            "group flex overflow-hidden p-2 [gap:var(--gap)]"
            if props.vertical then "flex-col" else "flex-row"
            props.class'
        |]
        ).style'({| ``--duration`` = $"{props.duration}s"; ``--gap`` = props.gap |}) {
            For(each = Array.create props.repeat 0) {
                yield fun _ _ ->
                    div(
                        class' = Lib.cn [|
                            "flex shrink-0 justify-around [gap:var(--gap)]"
                            if not props.vertical then "animate-marquee flex-row"
                            else "animate-marquee-vertical flex-col"
                            if props.pauseOnHover then "group-hover:[animation-play-state:paused]"
                            if props.reverse then "[animation-direction:reverse]"
                        |]
                    ) { props.children }
            }
        }