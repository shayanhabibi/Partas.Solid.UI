module Partas.Solid.UI.Storybook.stories.Badge_stories

open Partas.Solid
open Partas.Solid.UI
open Partas.Solid.Storybook
open Fable.Core
open Fable.Core.JsInterop

[<Global>]
let badge = Badge()

[<ExportDefault>]
[<SolidComponent>]
let private meta: Meta<Badge> = Meta.make [
    Meta.component' !@Badge
    Meta.args [
        Args.make (nameof badge.variant) Badge.Variant.Default
        Args.make (nameof badge.round) false
        Args.make "children" "Badge"
    ]
    Meta.argTypes [
        ArgTypes.make (nameof badge.variant) <| ArgType(
            control = Control(
                ``type`` = ControlType.Select
                ,labels = createObj [
                    !!Badge.Variant.Default ==> "Badge.Variant.Default"
                    !!Badge.Variant.Error ==> "Badge.Variant.Error"
                    !!Badge.Variant.Outline ==> "Badge.Variant.Outline"
                    !!Badge.Variant.Secondary ==> "Badge.Variant.Secondary"
                    !!Badge.Variant.Success ==> "Badge.Variant.Success"
                    !!Badge.Variant.Warning ==> "Badge.Variant.Warning"    
                ]
                )
            ,options = [|
                Badge.Variant.Default
                Badge.Variant.Error
                Badge.Variant.Outline
                Badge.Variant.Secondary
                Badge.Variant.Success
                Badge.Variant.Warning
            |]
            ,table = ArgType.Table(
                ``type`` = ArgType.Table.Value(summary = "Badge.Variant")
                )
            )
        ArgTypes.make (nameof badge.children) <| ArgType(control = !!ControlType.Object)
    ]
]

let Default = meta.make [
    Story.tags [| "!dev" |]
    Story.args [
        Args.make (nameof badge.variant) Badge.Variant.Default
    ]
]

let Round = meta.make [
    Story.args [
        Args.make "round" true
    ]
]

let Error_Variant = meta.make [
    Story.args [ Args.make "variant" Badge.Variant.Error ]
]
let Outline_Variant = meta.make [
    Story.args [ Args.make "variant" Badge.Variant.Outline ]
]
let Secondary_Variant = meta.make [ 
    Story.args [ Args.make "variant" Badge.Variant.Secondary ] 
]
let Success_Variant = meta.make [ 
    Story.args [ Args.make "variant" Badge.Variant.Success ] 
]
let Warning_Variant = meta.make [ 
    Story.args [ Args.make "variant" Badge.Variant.Warning ] 
]
