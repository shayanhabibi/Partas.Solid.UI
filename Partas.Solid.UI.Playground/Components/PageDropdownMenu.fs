[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageDropdownMenu

open Partas.Solid
open Partas.Solid.UI
open Partas.Solid.Polymorphism
open Fable.Core

[<Erase>]
type PageDropdownMenu() =
    interface VoidNode
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        let showGitLog,setShowGitLog = createSignal(false)
        let showHistory,setShowHistory = createSignal(false)
        let branch,setBranch = createSignal("develop")
        div(class' = "w-full flex p-6") {
            div(class' = "flex-col flex") {
                DropdownMenu() {
                    DropdownMenuTrigger().as'(!@Button) { "Git Settings" }
                    DropdownMenuContent(class' = "w-48") {
                        DropdownMenuItem() {
                            span() { "Commit" }
                            DropdownMenuShortcut() { "Alt+K" }
                        }
                        DropdownMenuItem() {
                            span() { "Push" }
                            DropdownMenuShortcut() { "Shift+Alt+K" }
                        }
                        DropdownMenuItem() {
                            span() { "Update Project" }
                            DropdownMenuShortcut() { "Alt+T" }
                        }
                        DropdownMenuSub(overlap = true) {
                            DropdownMenuSubTrigger() { "GitHub" }
                            DropdownMenuPortal() {
                                DropdownMenuSubContent() {
                                    DropdownMenuItem() { "Create Pull Request..." }
                                    DropdownMenuItem() { "View Pull Requests" }
                                    DropdownMenuItem() { "Sync Fork" }
                                    DropdownMenuSeparator()
                                    DropdownMenuItem() { "Open on GitHub" }
                                }
                            }
                        }
                        DropdownMenuSeparator()
                        DropdownMenuLabel() { "TODO finish dropdown" }
                    }
                }
            }
        }
