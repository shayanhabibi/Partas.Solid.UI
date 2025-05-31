[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageContextMenu

open Partas.Solid
open Partas.Solid.UI
open Fable.Core

[<Erase>]
type PageContextMenu() =
    interface VoidNode
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        let showGitLog,setShowGitLog = createSignal(false)
        let showHistory,setShowHistory = createSignal(false)
        let branch,setBranch = createSignal("main")
        div(class' = "w-full flex p-6") {
            ContextMenu() {
                ContextMenuTrigger(class' = "flex h-[150px] w-[300px] items-center justify-center rounded-md border border-dashed text-sm") {
                    "Right Click Here"
                }
                ContextMenuPortal() {
                    ContextMenuContent(class' = "w-48") {
                        ContextMenuItem() {
                            span() { "Commit" }
                            ContextMenuShortcut() { "Alt+K" }
                        }
                        ContextMenuItem() {
                            span() { "Push" }
                            ContextMenuShortcut() { "Shift+Alt+K" }
                        }
                        ContextMenuItem().bool("disabled", true) {
                            span() { "Update Project" }
                            ContextMenuShortcut() { "Alt+T" }
                        }
                        ContextMenuSub(overlap = true) {
                            ContextMenuSubTrigger() { "GitHub" }
                            ContextMenuPortal() {
                                ContextMenuSubContent() {
                                    ContextMenuItem() { "Create Pull Request" }
                                    ContextMenuItem() { "View Pull Requests" }
                                    ContextMenuItem() { "Sync Fork" }
                                    ContextMenuSeparator()
                                    ContextMenuItem() { "Open on GitHub" }
                                }
                            }
                        }
                        ContextMenuSeparator()
                        ContextMenuCheckboxItem(checked' = showGitLog(), onChange = setShowGitLog) {
                            "Show Git Log"
                        }
                        ContextMenuCheckboxItem(checked' = showHistory(), onChange = setShowHistory) {
                            "Show History"
                        }
                        ContextMenuSeparator()
                        ContextMenuGroup() {
                            ContextMenuGroupLabel() { "Branches" }
                            ContextMenuRadioGroup(
                                value = branch(),
                                onChange = setBranch
                            ) {
                                ContextMenuRadioItem(value = "main") { "main" }
                                ContextMenuRadioItem(value = "develop") { "develop" }
                            }
                        }
                    }
                }
            }
        }
