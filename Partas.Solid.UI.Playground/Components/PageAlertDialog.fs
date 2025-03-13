[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageAlertDialog

open Partas.Solid
open Partas.Solid.UI
open Fable.Core

[<Erase>]
type PageAlertDialog() =
    inherit VoidNode()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(class' = "size-full") {
            AlertDialog() {
                AlertDialogTrigger() { "Click me" }
                AlertDialogContent() {
                    AlertDialogTitle() { "Alert Dialog Title" }
                    AlertDialogDescription() { "Alert Dialog text" }
                }
            }
        }
