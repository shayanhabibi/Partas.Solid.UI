module Partas.Solid.UI.Storybook.stories.Notifications.BadgeDelta_stories

open Partas.Solid
open Partas.Solid.UI
open Partas.Solid.Storybook
open Fable.Core
open Fable.Core.JsInterop

[<Global>]
let badge = BadgeDelta()

[<ExportDefault>]
[<SolidComponent>]
let private meta: Meta<BadgeDelta> = Meta.make [
    Meta.component' !@BadgeDelta
    Meta.args [
        Args.make (nameof badge.deltaType) BadgeDelta.Type.Unchanged
        Args.make (nameof badge.round) false
        Args.make "children" "Delta Badge"
    ]
    Meta.argTypes [
        ArgTypes.make (nameof badge.deltaType) <| ArgType(
            control = Control(
                ``type`` = ControlType.Select
                ,labels = createObj [
                    !!BadgeDelta.Type.Unchanged ==> "Unchanged" 
                    !!BadgeDelta.Type.ModerateDecrease ==> "ModerateDecrease" 
                    !!BadgeDelta.Type.Decrease ==> "Decrease" 
                    !!BadgeDelta.Type.ModerateIncrease ==> "ModerateIncrease" 
                    !!BadgeDelta.Type.Increase ==> "Increase" 
                ]
                )
            ,options = [|
                BadgeDelta.Type.Unchanged
                BadgeDelta.Type.ModerateDecrease
                BadgeDelta.Type.Decrease
                BadgeDelta.Type.ModerateIncrease
                BadgeDelta.Type.Increase
            |]
            ,table = ArgType.Table(
                ``type`` = ArgType.Table.Value(summary = "BadgeDelta.Type")
                )
            )
        ArgTypes.make (nameof badge.children) <| ArgType(control = !!ControlType.Object)
    ]
]

let Default = meta.make [
    Story.tags [| "!dev" |]
    Story.args [
    ]
]

let Round = meta.make [
    Story.args [
        Args.make "round" true
    ]
]

let ModerateDecrease = meta.make [
    Story.args [
        Args.make "deltaType" BadgeDelta.Type.ModerateDecrease
    ]
]
let Decrease = meta.make [
    Story.args [
        Args.make "deltaType" BadgeDelta.Type.Decrease
    ]
]
let ModerateIncrease = meta.make [
    Story.args [
        Args.make "deltaType" BadgeDelta.Type.ModerateIncrease
    ]
]
let Increase = meta.make [
    Story.args [
        Args.make "deltaType" BadgeDelta.Type.Increase
    ]
]
