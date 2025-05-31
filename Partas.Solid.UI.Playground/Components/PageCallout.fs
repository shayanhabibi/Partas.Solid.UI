[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageCallout

open Partas.Solid
open Partas.Solid.UI
open Fable.Core

[<Erase>]
type PageCallout() =
    interface VoidNode
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        let variants = [|
            "Default", Callout.Variant.Default
            "Error", Callout.Variant.Error
            "Success", Callout.Variant.Success
            "Warning", Callout.Variant.Warning
        |]
        div(class' = "w-full p-6 flex flex-col gap-4") {
            For(each = variants) {
                yield fun (name,variant) index ->
                    Callout(variant = variant) {
                        CalloutTitle() { name }
                        CalloutContent() {
                            "Content"
                        }
                    }
            }
        }
