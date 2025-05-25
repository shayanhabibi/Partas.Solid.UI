namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Kobalte
open Fable.Core

[<Erase>]
type ContextMenu() =
    inherit Kobalte.ContextMenu()
    [<SolidTypeComponent>]
    member props.constructor = Kobalte.ContextMenu(gutter = 4).spread props
    
[<Erase>]
type ContextMenuTrigger() =
    inherit ContextMenu.Trigger()
    [<SolidTypeComponent>]
    member props.constructor = ContextMenu.Trigger().spread props
[<Erase>]
type ContextMenuPortal() =
    inherit ContextMenu.Portal()
    [<SolidTypeComponent>]
    member props.constructor = ContextMenu.Portal().spread props
    
[<Erase>]
type ContextMenuSub() =
    inherit ContextMenu.Sub()
    [<SolidTypeComponent>]
    member props.constructor = ContextMenu.Sub().spread props
    
[<Erase>]
type ContextMenuGroup() =
    inherit ContextMenu.Group()
    [<SolidTypeComponent>]
    member props.constructor = ContextMenu.Group().spread props
    
[<Erase>]
type ContextMenuRadioGroup() =
    inherit ContextMenu.RadioGroup()
    [<SolidTypeComponent>]
    member props.constructor = ContextMenu.RadioGroup().spread props
    
[<Erase>]
type ContextMenuContent() =
    inherit ContextMenu.Content()
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.ContextMenu.Portal() {
            Kobalte.ContextMenu.Content(class'= Lib.cn [|
                "z-50 min-w-32 origin-[var(--kb-menu-content-transform-origin)]
                overflow-hidden rounded-md border bg-popover p-1
                text-popover-foreground shadow-md animate-in"
                props.class'
            |]).spread(props)
            }
[<Erase>]
type ContextMenuItem() =
    inherit ContextMenu.Item()
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.ContextMenu.Item(
            class' = Lib.cn [|
                "relative flex cursor-default select-none items-center
                rounded-sm px-2 py-1.5 text-sm outline-none transition-colors
                focus:bg-accent focus:text-accent-foreground
                data-[disabled]:pointer-events-none data-[disabled]:opacity-50"
                props.class'
            |]).spread(props)
[<Erase>]
type ContextMenuShortcut() =
    inherit span()
    [<SolidTypeComponent>]
    member props.constructor =
        span(class'= Lib.cn [| "ml-auto text-xs tracking-widest opacity-60"; props.class' |]).spread(props)
[<Erase>]
type ContextMenuSeparator() =
    inherit ContextMenu.Separator()
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.ContextMenu.Separator(
            class' = Lib.cn [|
                "-mx-1 my-1 h-px bg-muted"
                props.class'
            |]
        ).spread(props)
[<Erase>]
type ContextMenuSubTrigger() =
    inherit ContextMenu.SubTrigger()
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.ContextMenu.SubTrigger(class'= Lib.cn [|
            "flex cursor-default select-none items-center
            rounded-sm px-2 py-1.5 text-sm outline-none
            focus:bg-accent data-[state=open]:bg-accent"
            props.class'
        |]).spread(props) {
            props.children
            Lucide.Lucide.ChevronRight(class'="ml-auto size-4", strokeWidth = 2)
        }
[<Erase>]
type ContextMenuSubContent() =
    inherit ContextMenu.SubContent()
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.ContextMenu.SubContent(class'= Lib.cn [|
            "z-50 min-w-32 origin-[var(--kb-menu-content-transform-origin)]
            overflow-hidden rounded-md border bg-popover
            p-1 text-popover-foreground shadow-md animate-in"
            props.class'
        |]).spread(props)
[<Erase>]
type ContextMenuCheckboxItem() =
    inherit ContextMenu.CheckboxItem()
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.ContextMenu.CheckboxItem(class'= Lib.cn [|
            "relative flex cursor-default select-none items-center
            rounded-sm py-1.5 pl-8 pr-2 text-sm outline-none
            transition-colors focus:bg-accent focus:text-accent-foreground
            data-[disabled]:pointer-events-none data-[disabled]:opacity-50"
            props.class'
        |]).spread(props) {
            span(class'= "absolute left-2 flex size-3.5 items-center justify-center") {
                Kobalte.ContextMenu.ItemIndicator() {
                    Lucide.Lucide.Check(class'="size-4", strokeWidth = 2)
                }
            }
            props.children
        }
[<Erase>]
type ContextMenuGroupLabel() =
    inherit ContextMenu.GroupLabel()
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.ContextMenu.GroupLabel(class' = Lib.cn [|"px-2 py-1.5 text-sm font-semibold"; props.class'|]).spread(props)
[<Erase>]
type ContextMenuRadioItem() =
    inherit ContextMenu.RadioItem()
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.ContextMenu.RadioItem(class'= Lib.cn [|
            "relative flex cursor-default select-none items-center
            rounded-sm py-1.5 pl-8 pr-2 text-sm outline-none
            transition-colors focus:bg-accent focus:text-accent-foreground
            data-[disabled]:opacity-50"
            props.class'
        |]).spread(props) {
            span(class'="absolute left-2 flex size-3.5 items-center justify-center") {
                Kobalte.ContextMenu.ItemIndicator() {
                    Lucide.Lucide.Circle(class'="size-2 fill-current", strokeWidth = 2)
                }
            }
            props.children
        }


