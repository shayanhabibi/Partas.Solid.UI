namespace Partas.Solid.UI

open Partas.Solid
open Fable.Core
open Fable.Core.JS
open Fable.Core.JsInterop
open System

[<Erase>]
type ShineBorder() =
    inherit RegularNode()
    [<Erase>] member val borderRadius: int = undefined with get,set
    [<Erase>] member val borderWidth: int = undefined with get,set
    [<Erase>] member val color: string = undefined with get,set
    [<Erase>] member val duration: int = undefined with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.borderRadius <- 8
        props.borderWidth <- 2
        props.color <- "#000000"
        props.duration <- 14
        
        div(
            class' = Lib.cn [|
                "relative rounded-(var(--border-radius))"
                props.class'
            |]
        ).style'({| ``--border-radius`` = $"{props.borderRadius}px" |}) {
            div(
                class' = "pointer-events-none before:absolute before:inset-0 before:size-full before:rounded-[var(--border-radius)] before:p-[var(--border-width)] before:will-change-[background-position] before:content-[''] before:![-webkit-mask-composite:xor] before:![mask-composite:exclude] before:[background-image:var(--background-radial-gradient)] before:[background-size:300%_300%] before:[mask:var(--mask-linear-gradient)] motion-safe:before:animate-shineborder"
            ).style'(
                {|
                    ``--border-width`` = $"{props.borderWidth}px"
                    ``--border-radius`` = $"{props.borderRadius}px"
                    ``--duration`` = $"{props.duration}s"
                    ``--mask-linear-gradient`` = "linear-gradient(#fff 0 0) content-box, linear-gradient(#fff 0 0)"
                    ``--background-radial-gradient`` = $"""radial-gradient(transparent, transparent, {if Constructors.Array.isArray props.color then props.color |> unbox<string array> |> String.concat "," else props.color }, transparent, transparent)"""
                |}
                
            ) {
                props.children
            }
        }