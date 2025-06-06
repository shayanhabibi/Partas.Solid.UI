module Partas.Solid.UI.Storybook.MyButton

open Partas.Solid
open Partas.Solid.UI
open Partas.Solid.Storybook
open Fable.Core
open Fable.Core.JsInterop
open Partas.Solid.Experimental.U

[<SolidComponent>]
[<ExportDefault>]
let private meta: Meta<Button> = Meta.make [
    // Meta.title "Buttons/Button"
    Meta.component' !@Button
    Meta.args [
        Args.make "children" "Button"
        Args.make "variant" Button.Variant.Default
        Args.make "size" Button.Size.Default
    ]
    Meta.parameters [
        Parameters.layout StorybookLayout.Centered
    ]
    Meta.argTypes [
        ArgTypes.make "onClick" <| ArgType(control = !!ControlType.DoNotRender)
        ArgTypes.make "variant" <| ArgType(
            control = Control(
                ``type`` = ControlType.Select,
                labels = createObj [
                    !!Button.Variant.Default ==> nameof Button.Variant.Default
                    !!Button.Variant.Destructive ==> nameof Button.Variant.Destructive
                    !!Button.Variant.Ghost ==> nameof Button.Variant.Ghost
                    !!Button.Variant.Link ==> nameof Button.Variant.Link
                    !!Button.Variant.Outline ==> nameof Button.Variant.Outline
                    !!Button.Variant.Secondary ==> nameof Button.Variant.Secondary
                ]
                ),
            table = ArgType.Table(
                category = "variants",
                defaultValue = ArgType.Table.Value(summary = nameof Button.Variant.Default),
                ``type`` = ArgType.Table.Value(summary = "Button.Variant")
                ),
            options = [|
                Button.Variant.Default
                Button.Variant.Destructive
                Button.Variant.Ghost
                Button.Variant.Link
                Button.Variant.Outline
                Button.Variant.Secondary
            |]
            )
        ArgTypes.make "size" <| ArgType(
            control = Control(``type`` = ControlType.Select),
            options = [|
                Button.Size.Default
                Button.Size.Small
                Button.Size.Large
                Button.Size.Icon
            |],
            ``type`` = !^SBEnumType(false,"size","size",ResizeArray([||]))
            ,table = ArgType.Table(
                category = "variants",
                ``type`` = ArgType.Table.Value(summary = "Button.Size"),
                defaultValue = ArgType.Table.Value(summary = nameof Button.Size.Default)
                )
            )
    ]
    Meta.tags [| "autodocs" |]
]


let Default = meta.make [
    Story.args [
        Args.make "variant" Button.Variant.Default
    ]
]

let Secondary = meta.make [
    Story.args [
        Args.make "variant" Button.Variant.Secondary
    ]
]

let Ghost = meta.make [
    Story.args [
        Args.make "variant" Button.Variant.Ghost
    ]
]

let Outline = meta.make [
    Story.args [
        Args.make "variant" Button.Variant.Outline
    ]
]

let Link = meta.make [
    Story.args [
        Args.make "variant" Button.Variant.Link
    ]
]

let Destructive = meta.make [
    Story.args [
        Args.make "variant" Button.Variant.Destructive
    ]
]


