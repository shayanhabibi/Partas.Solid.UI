module Partas.Solid.UI.Storybook.Checkbox

open Partas.Solid.UI
open Partas.Solid
open Fable.Core
open Fable.Core.JsInterop
open Partas.Solid.Storybook

[<ExportDefault; SolidComponent>]
let private meta: Meta<Checkbox> = Meta.make [
    Meta.component' !@Checkbox
    // Meta.title "Buttons/Checkbox"
    Meta.argTypes [
        ArgTypes.make "onChange" <| ArgType(
                control = !!false
            )
        ArgTypes.make "disabled" <| ArgType(control = !!ControlType.Boolean)
    ]
    Meta.render !!(fun args ->
        let uid = createUniqueId()
        div(class' = "flex gap-2") {
            Label(for' = $"{uid}-input") { "Click me!" }
            Checkbox(id = uid).spread args
        })
    Meta.parameters [
        Parameters.layout StorybookLayout.Centered
    ]
]

let Default = meta.make  []

let Disabled = meta.make [
    Story.tags [| "Issues" |]
    Story.args [
        Args.make "disabled" true
        Args.make "checked" true
    ]
]

let Indeterminate = meta.make [
    Story.args [
        Args.make "indeterminate" true
    ]
]
