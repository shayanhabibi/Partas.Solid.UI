module Partas.Solid.UI.Storybook.stories.Alert_stories

open Partas.Solid
open Partas.Solid.Lucide
open Partas.Solid.UI
open Partas.Solid.Storybook
open Fable.Core
open Fable.Core.JsInterop

[<Global>]
let alert = Alert()
[<ExportDefault>]
[<SolidComponent>]
let private meta: Meta<Alert> = Meta.make [
    // Meta.title "Notifications/Alert"
    Meta.component' !@Alert
    Meta.render (fun props ->
        Alert().spread props {
            AlertTitle() { "Alert Title" }
            AlertDescription() { "Description of an alert" }
        }
        )
    Meta.argTypes [
        ArgTypes.make (nameof alert.variant) <| ArgType(
            control = Control(
                ``type`` = ControlType.Select,
                labels = createObj [
                    !!Alert.Variant.Default ==> "Alert.Variant.Default"
                    !!Alert.Variant.Destructive ==> "Alert.Variant.Destructive"
                ]
                ),
            options = [|
                Alert.Variant.Default
                Alert.Variant.Destructive
            |],
            table = ArgType.Table(
                defaultValue = ArgType.Table.Value(summary = "Default"),
                ``type`` = ArgType.Table.Value(summary = "Alert.Variant")
                )
            )
    ]
]

let Default = meta.make [
    Story.tags [| "!dev" |]
    
]

let Destructive = meta.make [
    Story.tags [| "!dev" |]
    Story.args [
        Args.make (nameof alert.variant) Alert.Variant.Destructive
    ]
]

[<SolidComponent>]
let WithIcon = meta.make [
    Story.render (fun props ->
        Alert().spread props {
            Lucide.Ghost()
            AlertTitle() { "Alert Title" }
            AlertDescription() { "Description of an alert" }
        }
        )
]
