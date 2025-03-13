[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageLabel

open Partas.Solid
open Partas.Solid.UI
open Fable.Core

[<Erase>]
type PageLabel() =
    inherit VoidNode()
    [<SolidTypeComponent>]
    member props.constructor =
        div(class' = "w-full flex p-6") {
            div(class'  = "flex items-start space-x-2") {
                Checkbox(id = "terms1")
                div(class' = "grid gap-1.5 leading-none") {
                    Label(for' = "terms1-input") { "Accept terms and conditions" }
                    p(class' = "text-sm text-muted-foreground") {
                        "You agree to our Terms of Service and Privacy Policy"
                    }
                }
            }
        }
