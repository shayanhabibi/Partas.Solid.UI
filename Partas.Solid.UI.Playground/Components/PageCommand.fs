[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageCommand

open Partas.Solid
open Partas.Solid.UI
open Fable.Core

[<Erase>]
type PageCommand() =
    inherit VoidNode()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(class'= "w-full flex p-6") {
            Command(class' = "rounded-lg border shadow-md") {
                CommandInputs(placeholder = "Type a command or search...")
                CommandLists() {
                    CommandEmptys() { "No results found." }
                    CommandGroups(heading = unbox "Suggestions" ) {
                        CommandItems() {
                            Lucide.Lucide.Calendar(class' = "mr-2 size-4")
                            span() { "Calendar" }
                        }
                        CommandItems() {
                            Lucide.Lucide.Smile(class' = "mr-2 size-4")
                            span() { "Search Emoji" }
                        }
                        CommandItems() {
                            Lucide.Lucide.Rocket(class' = "mr-2 size-4")
                            span() { "Launch" }
                        }
                    }
                    CommandSeparators()
                    CommandGroups(heading = unbox "Settings") {
                        CommandItems() {
                            Lucide.Lucide.User(class' = "mr-2 size-4")
                            span() { "Profile" }
                            CommandShortcuts() { "Alt P" }
                        }
                        CommandItems() {
                            Lucide.Lucide.Mail(class' = "mr-2 size-4")
                            span() { "Mail" }
                            CommandShortcuts() { "Alt B" }
                        }
                        CommandItems() {
                            Lucide.Lucide.Settings(class' = "mr-2 size-4")
                            span() { "Settings" }
                            CommandShortcuts() { "Alt S" }
                        }
                    }
                }
            }
        }