[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageTimeline

open Partas.Solid
open Partas.Solid.UI
open Fable.Core
open Fable.Core.JsInterop


[<Erase>]
type PageTimeline() =
    inherit VoidNode()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(class' = "w-full flex items-center justify-center p-6") {
            Timeline(items = [|
                Timeline.Item(title =  !!"Event #1",
                              description =  !!"This is the first event of the timeline.")
                Timeline.Item(title =  !!"Event #2",
                              description =  !!"This is the second event of the timeline.")
                Timeline.Item(title =  !!"Event #3",
                              description =  !!"This is the third event of the timeline.")
            |], activeItem = 1)
        }
