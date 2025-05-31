[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageMenubar

open Partas.Solid
open Partas.Solid.UI
open Fable.Core

[<Erase>]
type PageMenubar() =
    interface VoidNode
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        Menubar() {
            MenubarMenu() {
                MenubarTrigger() { "File" }
                MenubarContent() {
                    MenubarItem() {
                        "New Tab "
                        MenubarShortcut() { "Alt T" }
                    }
                    MenubarItem() {
                        "New Window "
                        MenubarShortcut() { "Alt N" }
                    }
                    MenubarItem(disabled = true) {
                        "New Incognito Window"
                    }
                    MenubarSeparator()
                    MenubarSub(overlap = true) {
                        MenubarSubTrigger() {  "Share" }
                        MenubarSubContent() {
                            MenubarItem() { "Email Link" }
                            MenubarItem() { "Messages" }
                            MenubarItem() { "Notes" }
                        }
                    }
                    MenubarSeparator()
                    MenubarItem() {
                        "Print..."
                        MenubarShortcut() { "Alt P" }
                    }
                }
            }
            MenubarMenu() {
                MenubarTrigger() { "Edit" }
                MenubarContent() {
                    MenubarItem() {
                        "Undo"
                        MenubarShortcut() { "Alt Z" }
                    }
                    MenubarItem() {
                        "Redo"
                        MenubarShortcut() { "Shift Alt Z" }
                    }
                    MenubarSeparator()
                    MenubarSub(overlap = true) {
                        MenubarSubTrigger() { "Find" }
                        MenubarSubContent() {
                            MenubarItem() { "Search the web" }
                            MenubarSeparator()
                            MenubarItem() { "Find..." }
                            MenubarItem() { "Find Next" }
                            MenubarItem() { "Find Previous" }
                        }
                    }
                    MenubarSeparator()
                    MenubarItem() { "Cut" }
                    MenubarItem() { "Copy" }
                    MenubarItem() { "Paste" }
                }
            }
        }
