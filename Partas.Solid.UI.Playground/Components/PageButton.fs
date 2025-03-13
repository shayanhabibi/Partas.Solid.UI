[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageButton

open Partas.Solid
open Partas.Solid.UI
open Fable.Core

[<Erase>]
type PageButton() =
    inherit VoidNode()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(class' = "flex gap-8 p-6") {
            For(each = [|
                button.variant.default', "Default"
                button.variant.destructive, "Destructive"
                button.variant.ghost, "Ghost"
                button.variant.link, "Link"
                button.variant.outline, "Outline"
                button.variant.secondary, "Secondary"
            |]) {
                yield fun (variant, variantName) index ->
                    div(class' = "flex flex-col gap-4") {
                        For(each = [|
                            button.size.default'
                            button.size.lg
                            button.size.sm
                            button.size.icon
                        |]) {
                            yield fun size index ->
                                Button(size =  size, variant = variant) {
                                    if size = button.size.icon then
                                        Lucide.Lucide.Atom()
                                    else
                                        variantName
                                }
                        }
                    }
            }
        }