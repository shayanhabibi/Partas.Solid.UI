[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageCard

open Partas.Solid
open Partas.Solid.UI
open Fable.Core

[<Erase>]
type PageCard() =
    interface VoidNode
    [<SolidTypeComponentAttribute>]
    member props.constructor  =
        let notifications = [|
            "Your call has been confirmed.", "1 hour ago"
            "You have a new message!", "1 hour ago"
            "Your subscription is expiring soon!", "2 hour ago"
        |]
        div(class' = "flex w-full p-6 gap-8") {
            Card(class' = "w-[380px]") {
                CardHeader() {
                    CardTitle() { "Notifications" }
                    CardDescription() { "You have 3 unread messages." }
                }
                CardContent(class' = "grid gap-4") {
                    div(class' = "flex items-center space-x-4 rounded-md border p-4") {
                        Lucide.Lucide.Bell(class' = "size-6")
                        div(class' = "flex-1 space-y-1") {
                            p(class' = "text-sm font-medium leading-none") { "Push notifications" }
                            p(class' = "text-sm text-muted-foreground") { "Send notifications to device." }
                        }
                        Switch() { SwitchControl() { SwitchThumb() } }
                    }
                    div() {
                        For(each = notifications) {
                            yield fun (title,description) index ->
                                div(class' = "mb-4 grid grid-cols-[25px_1fr] items-start pb-4 last:mb-0 last:pb-0") {
                                    span(class' = "flex size-2 translate-y-1 rounded-full bg-sky-500")
                                    div(class' = "space-y-1") {
                                        p(class' = "text-sm font-medium leading-none") {title}
                                        p(class' = "text-sm text-muted-foreground") { description }
                                    }
                                }
                        }
                    }
                }
                CardFooter() {
                    Button(class' = "w-full") {
                        Lucide.Lucide.Check(class' = "size-4")
                        "Mark all as read"
                        
                    }
                }
            }
        }
