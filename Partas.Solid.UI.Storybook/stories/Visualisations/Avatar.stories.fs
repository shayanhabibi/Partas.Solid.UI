module Partas.Solid.UI.Storybook.stories.Avatar_stories

open Partas.Solid
open Partas.Solid.UI
open Partas.Solid.Storybook
open Fable.Core
open Fable.Core.JsInterop

[<Global>]
let avatar = Avatar()

[<ExportDefault>]
[<SolidComponent>]
let private meta: Meta<Avatar> = Meta.make [
    // Meta.title "Visualisations/Avatar"
    Meta.component' !@Avatar
    Meta.render (fun props ->
        let other,avatar = splitProps(props, [| "src"; "children" |])
        Avatar().spread avatar {
            AvatarImage(src = other?src)
            AvatarFallback() { other?children }
        }
        )
    Meta.args [
        Args.make (nameof avatar.fallbackDelay) 2000
        Args.make (nameof avatar.onLoadingStatusChange) (Storybook.action "LoadingStatusChanged")
        Args.make "children" "SH"
        Args.make "src" "https://avatars.githubusercontent.com/u/57953499?v=4"
    ]
    Meta.argTypes [
        ArgTypes.make (nameof avatar.fallbackDelay) <| ArgType(
            control = Control(
                ``type`` = ControlType.Number,
                min = 0
                )
            ,table = ArgType.Table(
                category = nameof Avatar
                )
            ,description = "Time to wait in ms before showing the fallback"
            )
        ArgTypes.make (nameof avatar.onLoadingStatusChange) <| ArgType(
            control = !!false
            ,table = ArgType.Table(
                category = nameof Avatar
                ,``type`` = ArgType.Table.Value(
                    summary = "LoadingStatus -> unit"
                    ,detail = $"LoadingStatus = StringEnum of values: {nameof Kobalte.Enums.LoadingStatus.Error} | {nameof Kobalte.Enums.LoadingStatus.Idle} | {nameof Kobalte.Enums.LoadingStatus.Loaded} | {nameof Kobalte.Enums.LoadingStatus.Loading}"
                    )
                )
            )
        ArgTypes.make "src" <| ArgType(
            table = ArgType.Table(
                category = nameof AvatarImage
                )
            )
        ArgTypes.make "children" <| ArgType(
            table = ArgType.Table(
                category = nameof AvatarFallback
                ),
            control = !!ControlType.Object
            )
    ]
]

let Default = meta.make [
    Story.tags [||]
]

let Error_Example_No_Delay = meta.make [
    Story.args [
        Args.make "src" "somefakesource"
        Args.make "fallbackDelay" 0
    ]
]

let Error_Example_With_Delay = meta.make [
    Story.args [
        Args.make "src" "fsdfa"
    ]
]
