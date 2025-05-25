namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Kobalte
open Partas.Solid.Polymorphism
open Fable.Core

[<Erase>]
type Slider() =
    inherit Kobalte.Slider()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        Kobalte.Slider(
            class' = Lib.cn [|
                "relative flex w-full touch-none select-none flex-col items-center"
                props.class'
            |]
            ).spread props

[<Erase>]
type SliderTrack() =
    inherit Slider.Track()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        Slider.Track(class' = Lib.cn [| "relative h-2 w-full grow rounded-full bg-secondary"
                                        props.class' |]
        )   .spread props

[<Erase>]
type SliderThumb() =
    inherit Slider.Thumb()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        Slider.Thumb(
            class' = Lib.cn [|
                "top-[-6px] block size-5 rounded-full border-2 border-primary
                bg-background ring-offset-background transition-colors focus-visible:outline-none
                focus-visible:ring-2 focus-visible:ring-ring focus-visible:ring-offset-2
                disabled:pointer-events-none disabled:opacity-50"
                props.class'
            |]
        ).spread props { Slider.Input() }

[<Erase>]
type SliderFill() =
    inherit Slider.Fill()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        Slider.Fill(class' = Lib.cn [|
            "absolute h-full rounded-full bg-primary"
            props.class'
        |]).spread(props)

[<Erase>]
type SliderLabel() =
    inherit Slider.Label()
    [<SolidTypeComponentAttribute>]
    member props.constructor = Slider.Label().as'(!@Label).spread props

[<Erase>]
type SliderValueLabel() =
    inherit Slider.ValueLabel()
    [<SolidTypeComponentAttribute>]
    member props.constructor = Slider.ValueLabel().as'(!@Label).spread props