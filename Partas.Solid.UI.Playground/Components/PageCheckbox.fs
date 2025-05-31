[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageCheckbox

open Partas.Solid
open Partas.Solid.UI
open Fable.Core

[<Erase>]
type PageCheckbox() =
    interface VoidNode
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(class' = "flex w-full p-6 items-start space-x-2") {
            Checkbox(id= "terms1")
            div(class' = "grid gap-1.5 leading-none") {
                Label(for' = "terms1-input") {
                    "Accept terms and conditions"
                }
                p(class' = "text-sm text-muted-foreground") {
                    "You agree to our Terms and Service and Privacy Policy"
                }
            }
            
        }
