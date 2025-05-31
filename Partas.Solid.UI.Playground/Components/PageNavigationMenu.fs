[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageNavigationMenu

open Partas.Solid
open Partas.Solid.UI
open Fable.Core

[<Erase>]
type PageNavigationMenu() =
    interface VoidNode
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        let orientation,setOrientation = createSignal("horizontal")
        div(class' = "w-full flex p-6") {
            div(class' = "flex flex-col items-center space-y-4") {
                NavigationMenu().attr("orientation", orientation()) {
                    NavigationMenuItem() {
                        NavigationMenuTrigger() { "Getting started"; NavigationMenuIcon() }
                        NavigationMenuContent(class' = "grid w-[90vw] grid-rows-3 gap-3 sm:w-[500px] sm:grid-cols-2 md:w-[500px] lg:w-[500px] lg:grid-cols-[.75fr_1fr] [&>li:first-child]:row-span-3") {
                            NavigationMenuLink(class' = "box-border flex size-full select-none flex-col justify-end rounded-md bg-gradient-to-b from-muted/50 to-muted p-6 no-underline focus:shadow-md"
                                               // ) {
                                               ,href = "https://github.com/shayanhabibi/Partas.Solid") {
                                Lucide.Lucide.Anvil(class' = "size-6")
                                NavigationMenuLabel(class' = "mb-2 mt-4 text-lg font-medium") { "Partas.Solid.UI" }
                                NavigationMenuDescription(class' = "text-sm leading-tight text-muted-foreground") {
                                    "Beautifully designed components. Built with Kobalte & Corvu. Styled with Tailwind CSS. Written in F# using Fable & Partas.Solid"
                                }
                            }
                            NavigationMenuLink(href = "")
                                { NavigationMenuLabel() { "Introduction" }
                                  NavigationMenuDescription() { "Re-usable components. Built with Kobalte & Corvu. Styled with Tailwind CSS. Written in F# using Fable & Partas.Solid" } }
                            NavigationMenuLink(href = "")
                                { NavigationMenuLabel() { "Installation" }
                                  NavigationMenuDescription() { "How to install dependencies and structure your app." } }
                        }
                    }
                    NavigationMenuItem() {
                        NavigationMenuTrigger() { "Getting started #2"; NavigationMenuIcon() }
                        NavigationMenuContent(class' = "grid w-[90vw] grid-rows-3 gap-3 sm:w-[500px] sm:grid-cols-2 md:w-[500px] lg:w-[500px] lg:grid-cols-[.75fr_1fr] [&>li:first-child]:row-span-3") {
                            NavigationMenuLink(class' = "box-border flex size-full select-none flex-col justify-end rounded-md bg-gradient-to-b from-muted/50 to-muted p-6 no-underline focus:shadow-md"
                                               // ) {
                                               ,href = "https://github.com/shayanhabibi/Partas.Solid") {
                                Lucide.Lucide.Anvil(class' = "size-6")
                                NavigationMenuLabel(class' = "mb-2 mt-4 text-lg font-medium") { "Partas.Solid.UI" }
                                NavigationMenuDescription(class' = "text-sm leading-tight text-muted-foreground") {
                                    "Beautifully designed components. Built with Kobalte & Corvu. Styled with Tailwind CSS. Written in F# using Fable & Partas.Solid"
                                }
                            }
                            NavigationMenuLink(href = "")
                                { NavigationMenuLabel() { "Introduction" }
                                  NavigationMenuDescription() { "Re-usable components. Built with Kobalte & Corvu. Styled with Tailwind CSS. Written in F# using Fable & Partas.Solid" } }
                            NavigationMenuLink(href = "")
                                { NavigationMenuLabel() { "Installation" }
                                  NavigationMenuDescription() { "How to install dependencies and structure your app." } }
                        }
                    }
                }
            }
        }
