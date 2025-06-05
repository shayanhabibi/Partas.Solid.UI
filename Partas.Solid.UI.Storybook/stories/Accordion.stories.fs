module Partas.Solid.UI.Storybook.stories.Accordion_stories

open Partas.Solid
open Partas.Solid.UI
open Partas.Solid.Storybook
open Fable.Core
open Fable.Core.JsInterop

[<Global>]
let accordion = Accordion()
[<SolidComponent; ExportDefault>]
let private meta: Meta<Accordion> = Meta.make [
    Meta.component' !@Accordion
    Meta.title "Collapsibles/Accordion"
    Meta.args [
        Args.make "multiple" false
        Args.make (nameof accordion.collapsible) false
        Args.make (nameof accordion.shouldFocusWrap) false
        Args.make "onChange" (Storybook.action(""))
    ]
    Meta.argTypes [
        ArgTypes.make "multiple" <| ArgType(
            control = !!ControlType.Boolean,
            table = ArgType.Table(defaultValue = ArgType.Table.Value(summary = "false")),
            description = "Determines whether you can have multiple items open."
            )
        ArgTypes.make "collapsible" <| ArgType(
            control = !!ControlType.Boolean,
            table = ArgType.Table(defaultValue = ArgType.Table.Value(summary = "false", detail = "multiple ? true : false")),
            description = "Determines whether you can close an open item."
            )
        ArgTypes.make "shouldFocusWrap" <| ArgType(
            control = !!ControlType.Boolean,
            table = ArgType.Table(defaultValue = ArgType.Table.Value(summary = "false")),
            description = "What does this do?"
            )
        
        ArgTypes.make "defaultValue" <| ArgType(
            control = !!false,
            table = ArgType.Table(disable = true)
            )
    ]
    Meta.render (fun props ->
        Accordion().spread props {
            AccordionItem(value = "trigger-1") {
                AccordionTrigger(onClick = Storybook.action("Trigger 1")) {
                    "Trigger 1"
                }
                AccordionContent() {
                    "Some content"
                }
            }
            AccordionItem(value = "trigger-2") {
                AccordionTrigger(onClick = Storybook.action("Trigger 2")) {
                    "Trigger 2"
                }
                AccordionContent() {
                    "Some other content"
                }
            }
        }
        )
]

let Default = meta.make [
    Story.args [
    ]
    Story.tags [| "!dev"; "autodocs" |]
]

let Collapsible = meta.make [
    Story.args [
        Args.make "collapsible" true
    ]
]

let Multiple = meta.make [
    Story.args [
        Args.make "multiple" true
    ]
]

let DefaultValue = meta.make [
    Story.args [
        Args.make (nameof accordion.defaultValue) [| "trigger-2" |]
    ]
    Story.argTypes [
        ArgTypes.make (nameof accordion.defaultValue) <| ArgType(description = "Accepts string or string array")
    ]
]
