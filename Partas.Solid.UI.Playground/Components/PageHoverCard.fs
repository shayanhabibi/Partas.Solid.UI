[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageHoverCard

open Partas.Solid
open Partas.Solid.UI
open Partas.Solid.Polymorphism
open Fable.Core

[<Erase>]
type PageHoverCard() =
    inherit VoidNode()
    [<SolidTypeComponent>]
    member props.coonstructor =
        HoverCard() {
            HoverCardTrigger().as'(Button(variant = button.variant.link)) {
                "@partas.solid"
            }
            HoverCardContent(class' = "w-80") {
                div(class' = "flex justify-between space-x-4") {
                    Avatar() {
                        AvatarImage(src = "https://github.com/shayanhabibi.png")
                        AvatarFallback() { "SH" }
                    }
                    div(class' = "space-y-1") {
                        h4(class' = "text-sm font-semibold") { "@partas.solid" }
                        p(class' = "text-sm") { "Feature full DSL plugin for Fable, binding Solid-js" }
                        div(class' = "flex items-center pt-2") {
                            Lucide.Lucide.Calendar(class' = "mr-2 size-4 opacity-70")
                            " "
                            span(class' = "text-xs text-muted-foreground") { "Developed February 2025" }
                        }
                    }
                }
            }
        }