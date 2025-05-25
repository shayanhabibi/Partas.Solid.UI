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
                Button.Variant.Default, "Default"
                Button.Variant.Destructive, "Destructive"
                Button.Variant.Ghost, "Ghost"
                Button.Variant.Link, "Link"
                Button.Variant.Outline, "Outline"
                Button.Variant.Secondary, "Secondary"
            |]) {
                yield fun (variant, variantName) index ->
                    div(class' = "flex flex-col gap-4") {
                        For(each = [|
                            Button.Size.Default
                            Button.Size.Large
                            Button.Size.Small
                            Button.Size.Icon
                        |]) {
                            yield fun size index ->
                                Button(size =  size, variant = variant) {
                                    if size = Button.Size.Icon then
                                        Lucide.Lucide.Atom()
                                    else
                                        variantName
                                }
                        }
                    }
            }
        }