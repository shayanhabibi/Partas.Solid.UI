namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Lucide
open Partas.Solid.Kobalte
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type Checkbox() =
    inherit Kobalte.Checkbox()
    [<SolidTypeComponent>]
    member props.checkbox =
        Kobalte.Checkbox(
            indeterminate = props.indeterminate,
            class' = Lib.cn [| "items-top group relative flex space-x-2"; props.class' |]
            ).spread(props) {
            Checkbox.Input(class'="peer")
            Checkbox.Control(class' = "size-4 shrink-0 rounded-sm border border-primary ring-offset-background disabled:cursor-not-allowed disabled:opacity-50 peer-focus-visible:outline-none peer-focus-visible:ring-2 peer-focus-visible:ring-ring peer-focus-visible:ring-offset-2 data-[checked]:border-none data-[indeterminate]:border-none data-[checked]:bg-primary data-[indeterminate]:bg-primary data-[checked]:text-primary-foreground data-[indeterminate]:text-primary-foreground") {
                Checkbox.Indicator() {
                    if props.indeterminate then
                        Minus(class' = "size-4", strokeWidth = 2)
                    else
                        Check(class' = "size-4", strokeWidth = 2)
                }
            }
        }