module Partas.Solid.UI.Storybook.stories.AlertDialog_stories

open Partas.Solid
open Partas.Solid.UI
open Fable.Core
open Partas.Solid.Storybook
open Fable.Core.JsInterop

[<Global>]
let alertDialog = AlertDialog()
[<Global>]
let alertContent = AlertDialogContent()

[<SolidComponent>]
[<ExportDefault>]
let private meta: Meta<AlertDialog> = Meta.make [
    // Meta.title "Notifications/AlertDialog"
    Meta.component' !@AlertDialog
    Meta.render (fun props ->
        let content,dialog = splitProps(props, [|
            "onOpenAutoFocus"
            "onCloseAutoFocus"
            "onEscapeKeyDown"
            "onPointerDownOutside"
            "onFocusOutside"
            "onInteractOutside"
            "children"
        |])
        AlertDialog().spread dialog {
            AlertDialogTrigger().as'(Button()) {
                "Click me!"
            }
            AlertDialogContent().spread content {
                AlertDialogTitle() { "Alert Dialog Title" }
                AlertDialogDescription() {
                    content?children
                }
            
            }
        }
        )
    Meta.args [
        Args.make (nameof alertDialog.preventScroll) false
        Args.make (nameof alertDialog.modal) false
        Args.make (nameof alertDialog.defaultOpen) false
        Args.make "children" "Alert Dialog description text"
    ]
    Meta.argTypes [
        ArgTypes.make (nameof alertDialog.defaultOpen) <| ArgType(
            table = ArgType.Table(
                category = nameof AlertDialog
                )
            )
        ArgTypes.make (nameof alertDialog.modal) <| ArgType(
            description = "Determines whether focus can leave the Dialog scope",
            table = ArgType.Table(
                category = nameof AlertDialog
                )
            )
        ArgTypes.make (nameof alertDialog.preventScroll) <| ArgType(
            description = "Determines whether you can scroll outside the Dialog scope",
            control = Control(
                ``type`` = ControlType.Boolean
                ),
            table = ArgType.Table(
                category = nameof AlertDialog
                )
            )
        ArgTypes.make (nameof alertDialog.onOpenChange) <| ArgType(
            control = !!false,
            table = ArgType.Table(
                category = nameof AlertDialog,
                ``type`` = ArgType.Table.Value(
                    summary = "bool -> unit"
                    )
                )
            )
        ArgTypes.make (nameof alertContent.onCloseAutoFocus) <| ArgType(
            control = !!false,
            table = ArgType.Table(
                category = nameof AlertDialogContent
                ,``type`` = ArgType.Table.Value(
                    summary = "Event -> unit"
                    )
                )
            )
        ArgTypes.make (nameof alertContent.onEscapeKeyDown) <| ArgType(
            control = !!false,
            table = ArgType.Table(
                category = nameof AlertDialogContent
                ,``type`` = ArgType.Table.Value(
                    summary = "KeyboardEvent -> unit"
                    )
                )
            )
        ArgTypes.make (nameof alertContent.onFocusOutside) <| ArgType(
            control = !!false,
            table = ArgType.Table(
                category = nameof AlertDialogContent
                ,``type`` = ArgType.Table.Value(
                    summary = "FocusEvent -> unit"
                    )
                )
            )
        ArgTypes.make (nameof alertContent.onInteractOutside) <| ArgType(
            control = !!false,
            table = ArgType.Table(
                category = nameof AlertDialogContent
                ,``type`` = ArgType.Table.Value(
                    summary = "Event -> unit"
                    )
                )
            )
        ArgTypes.make (nameof alertContent.onOpenAutoFocus) <| ArgType(
            control = !!false,
            table = ArgType.Table(
                category = nameof AlertDialogContent
                ,``type`` = ArgType.Table.Value(
                    summary = "Event -> unit"
                    )
                )
            )
        ArgTypes.make (nameof alertContent.onPointerDownOutside) <| ArgType(
            control = !!false,
            table = ArgType.Table(
                category = nameof AlertDialogContent
                ,``type`` = ArgType.Table.Value(
                    summary = "PointerEvent -> unit"
                    )
                )
            )
        ArgTypes.make "children" <| ArgType(
            control = !!Object,
            table = ArgType.Table(
                category = nameof AlertDialogDescription
                ,``type`` = ArgType.Table.Value(
                    summary = "HtmlElement"
                    )
                )
            )
    ]
]

let Default = meta.make [
    Story.tags [|  |]
]
