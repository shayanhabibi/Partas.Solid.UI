[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageDrawer

open Partas.Solid.Polymorphism
open Partas.Solid
open Partas.Solid.UI
open Fable.Core

[<Erase>]
type PageDrawer() =
    inherit VoidNode()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        let goal,setGoal = createSignal(250)
        let onClick = fun change -> setGoal(goal() + change)
        Drawer() {
            DrawerTrigger().as'(Button(variant = Button.Variant.Outline)) {
                "Open Drawer"
            }
            DrawerContent() {
                div(class' = "mx-auto w-full max-w-sm") {
                    DrawerHeader() {
                        DrawerTitle() { "Move Goal" }
                        DrawerDescription() { "Set your daily activity goal." }
                    }
                    div(class' = "p-4 pb-0") {
                        div(class' = "flex items-center justify-center space-x-2") {
                            Button(variant = Button.Variant.Outline, size = Button.Size.Icon, class' = "size-8 shrink-0 rounded-full",
                                   onClick = (fun _ -> onClick(-10)), disabled = (goal() <= 200))
                                   { Lucide.Lucide.Minus(class' = "size-4")
                                     SrSpan() { "Decrease" } }
                            div(class' = "flex-1 text-center") {
                                div(class' = "text-7xl font-bold tracking-tighter") { goal() }
                                div(class' = "text-[0.70rem] uppercase text-muted-foreground") { "Calories/day" }
                            }
                            Button(variant = Button.Variant.Outline,
                                   size= Button.Size.Icon,
                                   class' = "size-8 shrink-0 rounded-full",
                                   onClick = (fun _ -> onClick(10)),
                                   disabled = (goal() >= 400)) {
                                Lucide.Lucide.Plus(class' = "size-4")
                                SrSpan() { "Increase" }
                            }
                        }
                    }
                    DrawerFooter() {
                        Button() { "Submit" }
                        DrawerClose().as'(Button(variant = Button.Variant.Outline)) { "Cancel" }
                    }
                }
            }
        }
