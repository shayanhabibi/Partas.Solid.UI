[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageBarList

open Partas.Solid
open Partas.Solid.UI
open Fable.Core

[<JS.Pojo>]
type barData (name: string, value: int) =
    inherit Bar()

let data: Bar[] = [|
    barData("Instagram", 234)
    barData("X", 174)
    barData("Youtube", 1237)
|]

[<Erase>]
type PageBarList() =
    interface VoidNode
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(class' = "w-full flex items-center justify-center p-6") {
            BarList(data = data, class' = "w-full")
        }
