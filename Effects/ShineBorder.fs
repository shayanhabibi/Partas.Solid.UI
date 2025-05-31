namespace Partas.Solid.UI

open Partas.Solid
open Fable.Core
open Fable.Core.JS
open Fable.Core.JsInterop
open System
open Partas.Solid.Experimental.U

[<Erase>]
type ShineBorder() =
    interface RegularNode
    [<Erase>] member val borderRadius: int = undefined with get,set
    [<Erase>] member val borderWidth: int = undefined with get,set
    [<Erase>] member val color: U2<string, string[]> = undefined with get,set
    [<Erase>] member val duration: int = undefined with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.borderRadius <- 8
        props.borderWidth <- 2
        props.color <- "#000000"
        props.duration <- 14
        
        div(
            class' = Lib.cn [|
                "relative rounded-(--border-radius)"
                props.class'
            |]
        ).style' [ "--border-radius" ==> $"{props.borderRadius}px" ] {
            div(
                class' = "pointer-events-none before:absolute before:inset-0 before:size-full before:rounded-(--border-radius) before:p-(--border-width) before:will-change-[background-position] before:content-[''] before:![-webkit-mask-composite:xor] before:![mask-composite:exclude] before:[background-image:var(--background-radial-gradient)] before:[background-size:300%_300%] before:[mask:var(--mask-linear-gradient)] motion-safe:before:animate-shineborder"
            ).style' [
                "--border-width" ==> $"{props.borderWidth}px"
                "--border-radius" ==> $"{props.borderRadius}px"
                "--duration" ==> $"{props.duration}s"
                "--mask-linear-gradient" ==> "linear-gradient(#fff 0 0) content-box, linear-gradient(#fff 0 0)"
                "--background-radial-gradient" ==> $"""radial-gradient(transparent, transparent, {props.color |> function U2.Case2 arr -> arr |> String.concat "," | U2.Case1 value -> value}, transparent, transparent)"""
            ] {
                props.children
            }
        }
