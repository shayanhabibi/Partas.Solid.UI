namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Kobalte
open Fable.Core


[<Erase>]
type DropdownMenuTrigger() =
    inherit DropdownMenu.Trigger()
    [<SolidTypeComponent>]
    member props.constructor = DropdownMenu.Trigger().spread props
    
[<Erase>]
type DropdownMenuPortal() =
    inherit DropdownMenu.Portal()
    [<SolidTypeComponent>]
    member props.constructor = DropdownMenu.Portal().spread props
    
[<Erase>]
type DropdownMenuSub() =
    inherit DropdownMenu.Sub()
    [<SolidTypeComponent>]
    member props.constructor = DropdownMenu.Sub().spread props
    
[<Erase>]
type DropdownMenuGroup() =
    inherit DropdownMenu.Group()
    [<SolidTypeComponent>]
    member props.constructor = DropdownMenu.Group().spread props
    
[<Erase>]
type DropdownMenuRadioGroup() =
    inherit DropdownMenu.RadioGroup()
    [<SolidTypeComponent>]
    member props.constructor = DropdownMenu.RadioGroup().spread props
    
[<Erase>]
type DropdownMenu() =
    inherit Kobalte.DropdownMenu()
    [<SolidTypeComponent>]
    member props.constructor = Kobalte.DropdownMenu(gutter = 4).spread props
    
[<Erase>]
type DropdownMenuContent() =
    inherit DropdownMenu.Content()
    [<SolidTypeComponent>]
    member props.constructor =
        DropdownMenuPortal() {
            DropdownMenu.Content(class' = Lib.cn [|
                "z-50 min-w-32 origin-[var(--kb-menu-content-transform-origin)] animate-content-hide
                overflow-hidden rounded-md border bg-popover p-1 text-popover-foreground shadow-md
                data-[expanded]:animate-content-show"
                props.class'
            |]).spread(props)
        }
[<Erase>]
type DropdownMenuItem() =
    inherit DropdownMenu.Item()
    [<SolidTypeComponent>]
    member props.constructor =
        DropdownMenu.Item(class'= Lib.cn [|
            "relative flex cursor-default select-none items-center
            gap-2 rounded-sm px-2 py-1.5 text-sm outline-none transition-colors
            focus:bg-accent focus:text-accent-foreground data-[disabled]:pointer-events-none
            data-[disabled]:opacity-50"
            props.class'
        |]).spread(props)
[<Erase>]
type DropdownMenuShortcut() =
    inherit span()
    [<SolidTypeComponent>]
    member props.constructor =
        span(class'= Lib.cn [| "ml-auto text-xs tracking-widest opacity-60"; props.class' |]).spread(props)
[<Erase>]
type DropdownMenuLabel() =
    inherit div()
    member val inset : bool = jsNative with get,set
    [<SolidTypeComponent>]
    member props.constructor =
        div(class'= Lib.cn [|
            "px-2 py-1.5 text-sm font-semibold"
            props.inset &&= "pl-8"
        |]).spread(props)
[<Erase>]
type DropdownMenuSeparator() =
    inherit DropdownMenu.Separator()
    [<SolidTypeComponent>]
    member props.constructor =
        DropdownMenu.Separator(class'= Lib.cn [|
            "-mx-1 my-1 h-px bg-muted"
            props.class'
        |]).spread(props)

