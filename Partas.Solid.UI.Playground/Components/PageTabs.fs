[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageTabs

open Partas.Solid
open Partas.Solid.UI
open Fable.Core

[<Erase>]
type PageTabs() =
    interface VoidNode
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(class' = "w-full flex items-center justify-center p-6") {
            Tabs(
                defaultValue = "account",
                class' = "w-[400px]"
            ) {
                TabsList(class' = "grid w-full grid-cols-2") {
                    TabsTrigger(value = "account") { "Account" }
                    TabsTrigger(value = "password") { "Password" }
                }
                TabsContent(value = "account") {
                    Card() {
                        CardHeader() {
                            CardTitle() { "Account" }
                            CardDescription() { "Make changes to your account here. Click save when you are done." }
                        }
                        CardContent(class' = "space-y-2") {
                            TextField(class' = "space-y-1") {
                                TextFieldLabel() { "Name" }
                                TextFieldInput(value = "Shayan Habibi", type' = textFieldInput.Text)
                            }
                            TextField(class' = "space-y-1") {
                                TextFieldLabel() { "Username" }
                                TextFieldInput(value = "@shayanhabibi", type' = textFieldInput.Text)
                            }
                        }
                        CardFooter() { Button() { "Save Changes" } }
                    }
                }
                TabsContent(value = "password") {
                    Card() {
                        CardHeader() {
                            CardTitle() { "Password" }
                            CardDescription() { "Change your password here. After saving, you'll be logged out" }
                        }
                        CardContent(class' = "space-y-2") {
                            TextField(class' = "space-y-1") {
                                TextFieldLabel() { "Current Password" }
                                TextFieldInput(type' = textFieldInput.Password)
                            }
                            TextField(class' = "space-y-1") {
                                TextFieldLabel() { "New Password" }
                                TextFieldInput(type' = textFieldInput.Password)
                            }
                        }
                        CardFooter() { Button() { "Save Password" } }
                    }
                }
            }
            
        }
