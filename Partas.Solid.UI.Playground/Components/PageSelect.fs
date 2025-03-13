[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageSelect

open Partas.Solid
open Partas.Solid.UI
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type PageSelect() =
    inherit VoidNode()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        let value,setValue = createSignal("")
        div(class' = "w-full items-center justify-center flex p-6") {
            div(class' = "flex flex-col") {
                Select(
                    value = unbox (value()),
                    onChange = unbox setValue,
                    options = [| "Apple"; "Banana" ; "Blueberry" ; "Grapes" ; "Pineapple" |],
                    placeholder = unbox "Select a fruit..",
                    itemComponent = (fun itemProps -> SelectItem(item = itemProps?item) { props?item?rawValue })
                ) {
                    SelectTrigger(class' = "w-[180px]").attr("aria-label", "Fruit") {
                        SelectValue() { unbox<HtmlElement> (fun state -> state?selectedOption())}
                    }
                    SelectContent()
                }
                p(class' = "pt-2 text-sm text-gray-500") { "Your favorite fruit is:"; value() }
            }
        }