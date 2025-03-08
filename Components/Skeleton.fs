namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Kobalte
open Fable.Core

[<Erase>]
type Skeleton() =
    inherit Kobalte.Skeleton()
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.Skeleton(
            class' = Lib.cn [| "bg-primary/10 data-[animate='true']:animate-pulse"
                               props.class' |] )
            .spread props