[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageCombobox

open Partas.Solid
open Partas.Solid.UI
open Fable.Core
open Fable.Core.JsInterop
open Partas.Solid.Kobalte.Enums

type Food = {|
    Value: string
    Label: string
    Disabled: bool
|}
type Category = {|
    Label: string
    Options: Food[]
|}

let AllOptions = [|
    {|
        Label = "Fruits"
        Options = [|
            {| Value = "apple"
               Label = "Apple"
               Disabled = false |}
            {|
                Value = "banana"
                Label = "Banana"
                Disabled = false
            |}
            {|
                Value = "blueberry"
                Label = "Blueberry"
                Disabled = false
            |}
            {|
                Value = "grapes"
                Label = "Grapes"
                Disabled = true
            |}
            {|
                Value = "pineapple"
                Label = "Pineapple"
                Disabled = false
            |}
        |]
    |}
    {|
        Label = "Meat"
        Options = [|
            {|
                Value = "beef"
                Label = "Beef"
                Disabled = false
            |}
            {|
                Value = "chicken"
                Label = "Chicken"
                Disabled = false
            |}
            {|
                Value = "lamb"
                Label = "Lamb"
                Disabled = true
            |}
            {|
                Value = "pork"
                Label = "Pork"
                Disabled = false
            |}
        |]
    |}
|]

[<Erase>]
type ItemProps = {| item: {| rawValue: {| Label: string |} |} |}

[<Erase>]
type PageCombobox() =
    interface VoidNode
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(class' = "flex w-full p-6") {
            Combobox(options = !!AllOptions,
                     optionGroupChildren = "Options",
                     optionLabel = (fun opt -> opt?Label),
                     optionTextValue = (fun opt -> opt?Label),
                     optionValue = (fun item -> item?Value),
                     placeholder = unbox "Search a food...",
                     itemComponent = (
                            fun (itemProps) ->
                                ComboboxItem(item = itemProps.item) {
                                    ComboboxItemLabel() {
                                        (unbox<ItemProps> itemProps).item.rawValue.Label
                                    }
                                    ComboboxItemIndicator()
                                }
                         ),
                     sectionComponent = (
                            fun itemProps ->
                                ComboboxSection() { (unbox< {| section: {| rawValue: {| Label: string |} |} |} > itemProps).section.rawValue.Label }
                         )) {
                ComboboxControl().attr("aria-label", "Food") {
                    ComboboxInput()
                    ComboboxTrigger()
                }
                ComboboxContent()
            }
        }
