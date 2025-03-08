namespace Partas.Solid.UI

open Partas.Solid
open Fable.Core
open Partas.Solid.Kobalte
open Partas.Solid.Lucide


[<Erase>]
type AccordionItem() =
    inherit Accordion.Item()
    [<SolidTypeComponent>]
    member props.constructor =
        Accordion.Item(class' = Lib.cn [| "border-b"; props.class' |])
            .spread props

[<Erase>]
type AccordionTrigger() =
    inherit Accordion.Trigger()
    [<SolidTypeComponent>]
    member props.constructor =
        Accordion.Header(class' = Lib.cn [|
            "flex flex-1 items-center justify-between py-4 font-medium transition-all hover:underline [&[data-expanded]>svg]:rotate-180"
            props.class'
        |]).spread props {
            props.children
            Lucide.ChevronDown(strokeWidth = 2, class' = "size-4 shrink-0 transition-transform duration-300")
            div(class' = props.class')
        }

[<Erase>]
type AccordionContent() =
    inherit Accordion.Content()
    [<SolidTypeComponent>]
    member props.constructor =
        Accordion.Content(class' = Lib.cn [|
            "animate-accordion-up overflow-hidden text-sm transition-all data-[expanded]:animate-accordion-down"
            props.class'
        |]).spread props {
            div(class' = "pb-4 pt-0") {
                props.children
            }
        }

[<Erase>]
type Accordion() =
    inherit Kobalte.Accordion()
    [<SolidTypeComponent>]
    member props.constructor =
        Accordion().spread props