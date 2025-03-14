namespace Partas.Solid.UI

open Partas.Solid
open Fable.Core
open Partas.Solid.Kobalte
open Partas.Solid.Polymorphism

[<Erase>]
type Progress() =
    inherit Kobalte.Progress()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        Kobalte.Progress().spread(props) {
            props.children
            Progress.Track(class' = "relative h-2 w-full overflow-hidden rounded-full bg-secondary") {
                Progress.Fill(class' = "h-full w-[var(--kb-progress-fill-width)] flex-1 bg-primary transition-all")
            }
            
        }

[<Erase>]
type ProgressLabel() =
    inherit Progress.Label()
    [<SolidTypeComponentAttribute>]
    member props.constructor = Progress.Label().as'(!@Label).spread(props)

[<Erase>]
type ProgressValueLabel() =
    inherit Progress.ValueLabel()
    [<SolidTypeComponentAttribute>]
    member props.constructor = Progress.ValueLabel().as'(!@Label).spread props

// [<Erase>] // TODO - needs SVGs
// module progressCircle =
//     [<StringEnum>]
//     type Size =
//         | Xs
//         | Sm
//         | Md
//         | Lg
//         | Xl
//     
//     let sizes = function
//         | Xs -> {| radius = 15 ; strokeWidth = 3 |}
//         | Sm -> {| radius = 19 ; strokeWidth = 4 |}
//         | Md -> {| radius = 32 ; strokeWidth = 6 |}
//         | Lg -> {| radius = 52 ; strokeWidth = 8 |}
//         | Xl -> {| radius = 80; strokeWidth = 10 |}
//
// open progressCircle
//
// [<Erase>]
// type ProgressCircle() =
//     inherit div()
//     [<Erase>] member val value: int = unbox null with get,set
//     [<Erase>] member val size: Size = unbox null with get,set
//     [<Erase>] member val radius: int = unbox null with get,set
//     [<Erase>] member val strokeWidth: int = unbox null with get,set
//     [<Erase>] member val showAnimation: bool = unbox null with get,set
//     static member getLimitedValue (input: int) =
//         if input = JS.undefined then 0
//         elif input > 100 then 100
//         else input
//     [<SolidTypeComponent>]
//     member props.constructor =
//         