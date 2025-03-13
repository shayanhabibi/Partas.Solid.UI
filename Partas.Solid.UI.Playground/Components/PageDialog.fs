[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageDialog

open Partas.Solid
open Partas.Solid.Polymorphism
open Partas.Solid.UI
open Fable.Core

[<Erase>]
type PageDialog() =
    inherit VoidNode()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(class'  = "p-6 w-full") {
            Dialog() {
                DialogTrigger().as'(!@Button) { "Edit Profile" }
                DialogContent(class' = "sm:max-w-[425px]") {
                    DialogHeader() {
                        DialogTitle() { "Edit Profile" }
                        DialogDescription() { "Make changes to your profile here. Click save when you're done." }
                    }
                    div(class' = "grid gap-4 py-4") {
                        TextField(class' = "grid grid-cols-4 items-center gap-4") {
                            TextFieldLabel(class' = "text-right") { "Name" }
                            TextFieldInput(class' = "col-span-3", value = "Shayan Habibi", type' = textFieldInput.Text)
                        }
                        TextField(class' = "grid grid-cols-4 items-center gap-4") {
                            TextFieldLabel(class' = "text-right") { "Username" }
                            TextFieldInput(class' = "col-span-3", value = "@shayanhabibi", type' = textFieldInput.Text)
                        }
                    }
                    DialogFooter() {
                        Button(type' = "submit") { "Save changes" }
                    }
                }
            }
        }
