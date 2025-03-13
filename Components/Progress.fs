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