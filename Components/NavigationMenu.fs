namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Kobalte
open Partas.Solid.Aria
open Fable.Core


[<Erase>]
type NavigationMenuItem() =
    inherit NavigationMenu.Menu()
    [<SolidTypeComponent>]
    member props.constructor = NavigationMenu.Menu().spread props

[<Erase>]
type NavigationMenuViewport() =
    inherit NavigationMenu.Viewport()
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.NavigationMenu.Viewport(
            class' = Lib.cn [|
                // base settings
                "pointer-events-none z-[1000] flex h-[var(--kb-navigation-menu-viewport-height)]
                w-[var(--kb-navigation-menu-viewport-width)] origin-[var(--kb-menu-content-transform-origin)]
                items-center justify-center overflow-x-clip overflow-y-visible
                rounded-md border bg-popover opacity-0 shadow-lg
                data-[expanded]:pointer-events-auto data-[orientation=vertical]:overflow-y-clip
                data-[orientation=vertical]:overflow-x-visible data-[expanded]:rounded-md"
                // animation
                "animate-content-hide transition-[width,height]
                duration-200 ease-in data-[expanded]:animate-content-show
                data-[expanded]:opacity-100 data-[expanded]:ease-out"
                props.class'
            |]).spread props
        
[<Erase>]
type NavigationMenu() =
    inherit Kobalte.NavigationMenu()
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.NavigationMenu(gutter=6, class'= Lib.cn [|
            "group/menu flex w-max flex-1 list-none items-center
            justify-center data-[orientation=vertical]:flex-col [&>li]:w-full"
            props.class'
        |]).spread(props) {
            props.children
            NavigationMenuViewport()
        }
    
[<Erase>]
type NavigationMenuTrigger() =
    inherit NavigationMenu.Trigger()
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.NavigationMenu.Trigger(class'= Lib.cn [|
            "group/trigger inline-flex h-10 w-full items-center justify-center whitespace-nowrap
            rounded-md bg-background px-4 py-2 text-sm font-medium transition-colors hover:bg-accent
            hover:text-accent-foreground focus:bg-accent focus:text-accent-foreground
            focus:outline-none disabled:pointer-events-none disabled:opacity-50 data-[active]:bg-accent/50
            data-[expanded]:bg-accent/50"
            props.class'
        |]).spread props

[<Erase>]
type NavigationMenuIcon() =
    inherit NavigationMenu.Icon()
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.NavigationMenu.Icon(ariaHidden=true) {
            Lucide.Lucide.ChevronDown(
                class' = "relative top-px ml-1 size-3 transition duration-200
                group-data-[expanded]/trigger:rotate-180 group-data-[orientation=vertical]/menu:-rotate-90
                group-data-[orientation=vertical]/menu:group-data-[expanded]/trigger:rotate-90"
                , strokeWidth = 2
            )
        }

[<Erase>]
type NavigationMenuContent() =
    inherit NavigationMenu.Content()
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.NavigationMenu.Portal() {
            Kobalte.NavigationMenu.Content(class' = Lib.cn [|
                // base settings
                "pointer-events-none absolute left-0 top-0 box-border p-4
                focus:outline-none data-[expanded]:pointer-events-auto"
                // base animation settings
                "data-[motion^=from-]:animate-in data-[motion^=to-]:animate-out
                data-[motion^=from-]:fade-in data-[motion^=to-]:fade-out"
                // left to right
                "data-[orientation=horizontal]:data-[motion=from-start]:slide-in-from-left-52
                data-[orientation=horizontal]:data-[motion=to-end]:slide-out-to-right-52"
                // right to left
                "data-[orientation=horizontal]:data-[motion=from-end]:slide-in-from-right-52
                data-[orientation=horizontal]:data-[motion=to-start]:slide-out-to-left-52"
                // top to bottom
                "data-[orientation=vertical]:data-[motion=from-start]:slide-in-from-top-52
                data-[orientation=vertical]:data-[motion=to-end]:slide-out-to-bottom-52"
                //bottom to top
                "data-[orientation=vertical]:data-[motion=from-end]:slide-in-from-bottom-52
                data-[orientation=vertical]:data-[motion=to-start]:slide-out-to-bottom-52"
                props.class'
            |]).spread(props)
        }

[<Erase>]
type NavigationMenuLink() =
    inherit NavigationMenu.Item()
    [<Erase>] member val href: string = unbox null with get,set
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.NavigationMenu.Item(class' = Lib.cn [|
            "block select-none space-y-1 rounded-md p-3 leading-none no-underline
            outline-none transition-colors  hover:text-accent-foreground
            focus:bg-accent focus:text-accent-foreground"
            props.class'
        |]).spread(props)

[<Erase>]
type NavigationMenuLabel() =
    inherit NavigationMenu.ItemLabel()
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.NavigationMenu.ItemLabel( class' = Lib.cn [|
            "text-sm font-medium leading-none"
            props.class'
        |]).spread(props)

[<Erase>]
type NavigationMenuDescription() =
    inherit NavigationMenu.ItemDescription()
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.NavigationMenu.ItemDescription(class'= Lib.cn [|
            "text-sm leading-snug text-muted-foreground"
            props.class'
        |]).spread props


