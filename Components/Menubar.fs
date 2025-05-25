namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Kobalte
open Fable.Core

[<Erase>]
type MenubarGroup() =
    inherit Menubar.Group()
    [<SolidTypeComponent>]
    member props.constructor = Menubar.Group().spread props
    
[<Erase>]
type MenubarPortal() =
    inherit Menubar.Portal()
    [<SolidTypeComponent>]
    member props.constructor = Menubar.Portal().spread props
    
[<Erase>]
type MenubarSub() =
    inherit Menubar.Sub()
    [<SolidTypeComponent>]
    member props.constructor = Menubar.Sub().spread props
    
[<Erase>]
type MenubarRadioGroup() =
    inherit Menubar.RadioGroup()
    [<SolidTypeComponent>]
    member props.constructor = Menubar.RadioGroup().spread props
    
[<Erase>]
type Menubar() =
    inherit Kobalte.Menubar()
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.Menubar(class'= Lib.cn [|
            "flex h-10 items-center space-x-1 rounded-md border bg-background p-1"
            props.class'
        |]).spread props

[<Erase>]
type MenubarMenu() =
    inherit Kobalte.Menubar.Menu()
    [<SolidTypeComponent>]
    member props.constructor = Menubar.Menu(gutter = 8).spread props

[<Erase>]
type MenubarTrigger() =
    inherit Menubar.Trigger()
    [<SolidTypeComponent>]
    member props.constructor =
        Menubar.Trigger(class' = Lib.cn [|
            "flex cursor-default select-none items-center rounded-sm px-3 py-1.5 text-sm font-medium
            outline-none focus:bg-accent focus:text-accent-foreground data-[state=open]:bg-accent
            data-[state=open]:text-accent-foreground"
            props.class'
        |]).spread props
[<Erase>]
type MenubarContent() =
    inherit Menubar.Content()
    [<SolidTypeComponent>]
    member props.constructor =
        MenubarPortal() {
            Menubar.Content(class' = Lib.cn [|
                "z-50 min-w-48 origin-[var(--kb-menu-content-transform-origin)] animate-content-hide
                overflow-hidden rounded-md border bg-popover
                p-1 text-popover-foreground shadow-md data-[expanded]:animate-content-show"
                props.class'
            |]).spread props
        }
[<Erase>]
type MenubarSubTrigger() =
    inherit Menubar.SubTrigger()
    member val inset: bool = jsNative with get,set
    [<SolidTypeComponent>]
    member props.constructor =
        Menubar.SubTrigger(class'=Lib.cn [|
            "flex cursor-default select-none items-center rounded-sm px-2 py-1.5
            text-sm outline-none focus:bg-accent focus:text-accent-foreground
            data-[state=open]:bg-accent data-[state=open]:text-accent-foreground"
            props.inset &&= "pl-8"
            props.class'
        |]).spread(props) {
            props.children
            Lucide.Lucide.ChevronRight(class' = "ml-auto size-4", strokeWidth = 2)
        }
[<Erase>]
type MenubarSubContent() =
    inherit Menubar.SubContent()
    [<SolidTypeComponent>]
    member props.constructor =
        MenubarPortal() {
            Menubar.SubContent(class' = Lib.cn [|
                "z-50 min-w-32 origin-[var(--kb-menu-content-transform-origin)]
                overflow-hidden rounded-md border bg-popover p-1
                text-popover-foreground shadow-md animate-in"
                props.class'
            |]).spread(props)
        }
[<Erase>]
type MenubarItem() =
    inherit Menubar.Item()
    member val inset: bool = jsNative with get,set
    [<SolidTypeComponent>]
    member props.constructor =
        Menubar.Item(
            class' = Lib.cn [|
                "relative flex cursor-default select-none items-center rounded-sm
                px-2 py-1.5 text-sm outline-none focus:bg-accent
                focus:text-accent-foreground data-[disabled]:pointer-events-none
                data-[disabled]:opacity-50"
                props.inset &&= "pl-8"
                props.class'
            |]).spread(props)
[<Erase>]
type MenubarCheckboxItem() =
    inherit Menubar.CheckboxItem()
    [<SolidTypeComponent>]
    member props.constructor =
        Menubar.CheckboxItem(class'= Lib.cn [|
            "relative flex cursor-default select-none items-center rounded-sm
            py-1.5 pl-8 pr-2 text-sm outline-none focus:bg-accent
            focus:text-accent-foreground data-[disabled]:pointer-events-none
            data-[disabled]:opacity-50"
            props.class'
        |]).spread(props) {
            span(class'="absolute left-2 flex size-3.5 items-center justify-center") {
                Menubar.ItemIndicator() {
                    Lucide.Lucide.Check(class'="size-4",strokeWidth = 2)
                }
            }
            props.children
        }
[<Erase>]
type MenubarRadioItem() =
    inherit Menubar.RadioItem()
    [<SolidTypeComponent>]
    member props.constructor =
        Menubar.RadioItem(class' = Lib.cn [|
            "relative flex cursor-default select-none items-center rounded-sm
            py-1.5 pl-8 pr-2 text-sm outline-none focus:bg-accent
            focus:text-accent-foreground data-[disabled]:pointer-events-none
            data-[disabled]:opacity-50"
            props.class'
        |]).spread(props) {
            span(class'="absolute left-2 flex size-3.5 items-center justify-center") {
                Lucide.Lucide.Circle(class'="size-2 fill-current", strokeWidth=2)
            }
            props.children
        }
[<Erase>]
type MenubarItemLabel() =
    inherit Menubar.ItemLabel()
    member val inset: bool = jsNative with get,set
    [<SolidTypeComponent>]
    member props.constructor =
        Menubar.ItemLabel(class'=Lib.cn [|
            "px-2 py-1.5 text-sm font-semibold"
            props.inset &&= "pl-8"
            props.class'
        |]).spread(props)
[<Erase>]
type MenubarGroupLabel() =
    inherit Menubar.GroupLabel()
    member val inset: bool = jsNative with get,set
    [<SolidTypeComponent>]
    member props.constructor =
        Menubar.GroupLabel(class' = Lib.cn [|
            "px-2 py-1.5 text-sm font-semibold"
            props.inset &&= "pl-8"
            props.class'
        |]).spread(props)
[<Erase>]
type MenubarSeparator() =
    inherit Menubar.Separator()
    [<SolidTypeComponent>]
    member props.constructor =
        Menubar.Separator(class'=Lib.cn [|"-mx-1 my-1 h-px bg-muted"; props.class'|]).spread(props)
[<Erase>]
type MenubarShortcut() =
    inherit span()
    [<SolidTypeComponent>]
    member props.constructor =
        span(class' = Lib.cn [|
            "ml-auto text-xs tracking-widest text-muted-foreground"
            props.class'
        |]).spread props

