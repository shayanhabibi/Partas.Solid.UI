namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Lucide
open Partas.Solid.Kobalte
open Fable.Core

[<Erase>]
type RadioGroup() =
    inherit Kobalte.RadioGroup()
    [<SolidTypeComponent>]
    member props.constructor = Kobalte.RadioGroup(class' = Lib.cn [|"grid gap-2"; props.class'|]).spread(props)
    
[<Erase>]
type RadioGroupItem() =
    inherit RadioGroup.Item()
    [<SolidTypeComponent>]
    member props.constructor =
        RadioGroup.Item(class' = Lib.cn [|
            "flex items-center space-x-2"
            props.class'
        |]).spread(props) {
            RadioGroup.ItemInput()
            RadioGroup.ItemControl(class' = "aspect-square size-4 rounded-full border border-primary text-primary ring-offset-background focus:outline-none focus-visible:ring-2 focus-visible:ring-ring focus-visible:ring-offset-2 disabled:cursor-not-allowed disabled:opacity-50") {
                RadioGroup.ItemIndicator(class' = "flex h-full items-center justify-center") {
                    Circle(class' = "size-2.5 fill-current text-current")
                }
            }
            props.children
        }
[<Erase>]
type RadioGroupItemLabel() =
    inherit RadioGroup.ItemLabel()
    [<SolidTypeComponent>]
    member props.constructor =
        RadioGroup.ItemLabel(class' = Lib.cn [|
            "text-sm font-medium leading-none peer-disabled:cursor-not-allowed peer-disabled:opacity-70"
            props.class'
        |]).spread(props)


