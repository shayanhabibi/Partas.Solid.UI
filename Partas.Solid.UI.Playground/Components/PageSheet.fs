[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageSheet

open Partas.Solid
open Partas.Solid.Kobalte
open Partas.Solid.UI
open Partas.Solid.Polymorphism
open Fable.Core

let sheetPositions = [|
    Enums.KobaltePlacement.Top
    KobaltePlacement.Right
    KobaltePlacement.Bottom
    KobaltePlacement.Left
|]

[<Erase>]
type PageSheet() =
    inherit VoidNode()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(class' = "w-full flex p-6 items-center justify-center") {
            div(class' = "grid grid-cols-2 gap-2") {
                For(each = sheetPositions) {
                    yield fun item index ->
                        Sheet() {
                            SheetTrigger().as'(Button(variant = Button.Variant.Outline)) { unbox<string> item }
                            SheetContent(position = item) {
                                SheetHeader() {
                                    SheetTitle() { "Edit Profile" }
                                    SheetDescription() {
                                        "Make changes to your profile here. Click save when you're done."
                                    }
                                }
                                div(class' = "grid gap-4 py-4") {
                                    TextField(class' = "grid grid-cols-4 items-center gap-4") {
                                        TextFieldLabel(class' = "text-right") { "Name" }
                                        TextFieldInput(class' = "col-span-3", type' = textFieldInput.Text, value = "Shayan Habibi")
                                    }
                                    TextField(class' = "grid grid-cols-4 items-center gap-4") {
                                        TextFieldLabel(class' = "text-right") { "Username" }
                                        TextFieldInput(class' = "col-span-3", type' = textFieldInput.Text, value = "@shayanhabibi")
                                    }
                                }
                                SheetFooter() {
                                    Button(type' = "submit") { "Save changes" }
                                }
                            }
                        }
                }
            }
        }