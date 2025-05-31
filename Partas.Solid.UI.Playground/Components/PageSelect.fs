[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageSelect

open Partas.Solid
open Partas.Solid.Kobalte
open Partas.Solid.UI
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type PageSelect() =
    interface VoidNode
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        let value,setValue = createSignal("")
        div(class' = "w-full items-center justify-center flex p-6") {
            div(class' = "flex flex-col") {
                Select<string>(
                    value = !!value(),
                    onChange = !!setValue,
                    options = [| "Apple"; "Banana" ; "Blueberry" ; "Grapes" ; "Pineapple" |],
                    placeholder = unbox "Select a fruit..",
                    itemComponent = (fun (itemProps) -> SelectItem(item = itemProps?item) { itemProps.item.rawValue })
                ) {
                    SelectTrigger(class' = "w-[180px]").attr("aria-label", "Fruit") {
                        SelectValue() { yield fun state -> state.selectedOption()}
                    }
                    SelectContent()
                }
                p(class' = "pt-2 text-sm text-gray-500") { "Your favorite fruit is:"; value() }
            }
        }
