[<AutoOpen>]
module Partas.Solid.UI.Playground.PageAccordion

open Partas.Solid
open Partas.Solid.UI
open Partas.Solid.UI.Playground.Components
open Fable.Core

[<Erase>]
type BaseAccordion() =
    inherit Accordion()
    [<SolidTypeComponentAttribute>]
    member props.cons =
        Accordion(
            class' = "flex-1 border border-border rounded-lg px-4 max-h-min"
            ).spread props

[<Erase>]
type PageAccordion() =
    inherit VoidNode()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(class' = "size-full") {
            div(
                class' = "w-full flex gap-6"
            ) {
                BaseAccordion() {
                    AccordionItem(value = "accordion1") {
                        AccordionTrigger() { "Accordion Collapsible?" }
                        AccordionContent() { "Collapsible = false" }
                    }
                    AccordionItem(value = "accordion2")  {
                        AccordionTrigger() { "Accordion Multiple?" }
                        AccordionContent() { "Multiple = false" }
                    }
                    AccordionItem(value = "accordion3")  {
                        AccordionTrigger() { "Swag?" }
                        AccordionContent() { "No" }
                    }
                }
                BaseAccordion(collapsible = true) {
                    AccordionItem(value = "accordion4") {
                        AccordionTrigger() { "Accordion Collapsible?" }
                        AccordionContent() { "Collapsible = true" }
                    }
                    AccordionItem(value = "accordion5")  {
                        AccordionTrigger() { "Accordion Multiple?" }
                        AccordionContent() { "Multiple = false" }
                    }
                    AccordionItem(value = "accordion6")  {
                        AccordionTrigger() { "Swag?" }
                        AccordionContent() { "No" }
                    }
                }
                BaseAccordion(collapsible = true, multiple = true) {
                    AccordionItem(value = "accordion7") {
                        AccordionTrigger() { "Accordion Collapsible?" }
                        AccordionContent() { "Collapsible = true" }
                    }
                    AccordionItem(value = "accordion8")  {
                        AccordionTrigger() { "Accordion Multiple?" }
                        AccordionContent() { "Multiple = true" }
                    }
                    AccordionItem(value = "accordion9")  {
                        AccordionTrigger() { "Swag?" }
                        AccordionContent() { "No" }
                    }
                }
            }
            // Codeblock() {
            //     span() {"""{"[<Erase>]\n"}"""}
            //     span() {"""{"type BaseAccordion() =\n"}"""}
            //     span() {"""{"    inherit Accordion()\n"}"""}
            //     span() {"""{"    [<SolidTypeComponentAttribute>]\n"}"""}
            //     span() {"""{"    member props.cons =\n"}"""}
            //     span() {"""{"        Accordion(\n"}"""}
            //     span() {"""{"            class' = \"flex-1 border border-border rounded-lg px-4 max-h-min\"\n"}"""}
            //     span() {"""{"            ).spread props\n"}"""}
            //     span() {"""{"[<Erase>]\n"}"""}
            //     span() {"""{"type PageAccordion() =\n"}"""}
            //     span() {"""{"    inherit VoidNode()\n"}"""}
            //     span() {"""{"    [<SolidTypeComponentAttribute>]\n"}"""}
            //     span() {"""{"    member props.constructor =\n"}"""}
            //     span() {"""{"        div(\n"}"""}
            //     span() {"""{"            class' = \"w-full flex gap-6 h-full\"\n"}"""}
            //     span() {"""{"        ) {\n"}"""}
            //     span() {"""{"            BaseAccordion() {\n"}"""}
            //     span() {"""{"                AccordionItem(value = \"accordion1\") {\n"}"""}
            //     span() {"""{"                    AccordionTrigger() { \"Accordion Collapsible?\" }\n"}"""}
            //     span() {"""{"                    AccordionContent() { \"Collapsible = false\" }\n"}"""}
            //     span() {"""{"                }\n"}"""}
            //     span() {"""{"                AccordionItem(value = \"accordion2\")  {\n"}"""}
            //     span() {"""{"                    AccordionTrigger() { \"Accordion Multiple?\" }\n"}"""}
            //     span() {"""{"                    AccordionContent() { \"Multiple = false\" }\n"}"""}
            //     span() {"""{"                }\n"}"""}
            //     span() {"""{"                AccordionItem(value = \"accordion3\")  {\n"}"""}
            //     span() {"""{"                    AccordionTrigger() { \"Swag?\" }\n"}"""}
            //     span() {"""{"                    AccordionContent() { \"No\" }\n"}"""}
            //     span() {"""{"                }\n"}"""}
            //     span() {"""{"            }\n"}"""}
            //     span() {"""{"            BaseAccordion(collapsible = true) {\n"}"""}
            //     span() {"""{"                AccordionItem(value = \"accordion4\") {\n"}"""}
            //     span() {"""{"                    AccordionTrigger() { \"Accordion Collapsible?\" }\n"}"""}
            //     span() {"""{"                    AccordionContent() { \"Collapsible = true\" }\n"}"""}
            //     span() {"""{"                }\n"}"""}
            //     span() {"""{"                AccordionItem(value = \"accordion5\")  {\n"}"""}
            //     span() {"""{"                    AccordionTrigger() { \"Accordion Multiple?\" }\n"}"""}
            //     span() {"""{"                    AccordionContent() { \"Multiple = false\" }\n"}"""}
            //     span() {"""{"                }\n"}"""}
            //     span() {"""{"                AccordionItem(value = \"accordion6\")  {\n"}"""}
            //     span() {"""{"                    AccordionTrigger() { \"Swag?\" }\n"}"""}
            //     span() {"""{"                    AccordionContent() { \"No\" }\n"}"""}
            //     span() {"""{"                }\n"}"""}
            //     span() {"""{"            }\n"}"""}
            //     span() {"""{"            BaseAccordion(collapsible = true, multiple = true) {\n"}"""}
            //     span() {"""{"                AccordionItem(value = \"accordion7\") {\n"}"""}
            //     span() {"""{"                    AccordionTrigger() { \"Accordion Collapsible?\" }\n"}"""}
            //     span() {"""{"                    AccordionContent() { \"Collapsible = true\" }\n"}"""}
            //     span() {"""{"                }\n"}"""}
            //     span() {"""{"                AccordionItem(value = \"accordion8\")  {\n"}"""}
            //     span() {"""{"                    AccordionTrigger() { \"Accordion Multiple?\" }\n"}"""}
            //     span() {"""{"                    AccordionContent() { \"Multiple = true\" }\n"}"""}
            //     span() {"""{"                }\n"}"""}
            //     span() {"""{"                AccordionItem(value = \"accordion9\")  {\n"}"""}
            //     span() {"""{"                    AccordionTrigger() { \"Swag?\" }\n"}"""}
            //     span() {"""{"                    AccordionContent() { \"No\" }\n"}"""}
            //     span() {"""{"                }\n"}"""}
            //     span() {"""{"            }\n"}"""}
            //     span() {"""{"        }\n"}"""}
            //
            // } 
        }
