namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Cmdk
open Fable.Core


[<Erase>]
type Command() =
    inherit Cmdk.Command()
    [<SolidTypeComponent>]
    member props.constructor =
        Cmdk.Command(
            class'= Lib.cn [|
            "flex size-full flex-col overflow-hidden rounded-md bg-popover text-popover-foreground blur-none"
            props.class'
        |]
        ).spread(props)

[<Erase>]
type CommandDialog() =
    inherit Kobalte.Dialog()
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.Dialog().spread(props) {
            DialogContent(class'="overflow-hidden p-0") {
                Command(class' = "[&_[cmdk-group-heading]]:px-2 [&_[cmdk-group-heading]]:font-medium [&_[cmdk-group-heading]]:text-muted-foreground [&_[cmdk-group]:not([hidden])_~[cmdk-group]]:pt-0 [&_[cmdk-input-wrapper]_svg]:size-5 [&_[cmdk-input]]:h-12 [&_[cmdk-item]]:px-2 [&_[cmdk-item]]:py-3 [&_[cmdk-item]_svg]:size-5") {
                    props.children
                }
            }
        }

[<Erase>]
type CommandInput() =
    inherit Command.Input()
    [<SolidTypeComponent>]
    member props.constructor =
        div(class'="flex items-center border-b px-3").attr("cmdk-input-wrapper", "") {
            Lucide.Lucide.Search(class'="mr-2 size-4 shrink-0 opacity-50", strokeWidth = 2)
            Cmdk.Command.Input(class'= Lib.cn [|
                "flex h-10 w-full rounded-md bg-transparent py-3 text-sm outline-none placeholder:text-muted-foreground disabled:cursor-not-allowed disabled:opacity-50"
                props.class'
            |]).spread(props)
        }

[<Erase>]
type CommandList() =
    inherit Command.List()
    [<SolidTypeComponent>]
    member props.constructor =
        Cmdk.Command.List(class'= Lib.cn [|
            "max-h-[300px] overflow-y-auto overflow-x-hidden"
            props.class'
        |]).spread(props)

[<Erase>]
type CommandEmpty() =
    inherit Command.Empty()
    [<SolidTypeComponent>]
    member props.constructor =
        Cmdk.Command.Empty(class' = Lib.cn [|"py-6 text-center text-sm"; props.class'|]
        ).spread(props)
    
[<Erase>]
type CommandGroup() =
    inherit Command.Group()
    [<SolidTypeComponent>]
    member props.constructor =
        Cmdk.Command.Group(class'= Lib.cn [|
            "overflow-hidden p-1 text-foreground [&_[cmdk-group-heading]]:px-2 [&_[cmdk-group-heading]]:py-1.5 [&_[cmdk-group-heading]]:text-xs [&_[cmdk-group-heading]]:font-medium [&_[cmdk-group-heading]]:text-muted-foreground"
            props.class'
        |]).spread(props)

[<Erase>]
type CommandSeparator() =
    inherit Command.Separator()
    [<SolidTypeComponent>]
    member props.constructor =
        Cmdk.Command.Separator(class' = Lib.cn [|
            "h-px bg-border"
            props.class'
        |]).spread(props)
    
[<Erase>]
type CommandItem() =
    inherit Command.Item()
    [<SolidTypeComponent>]
    member props.constructor =
        Cmdk.Command.Item(class' = Lib.cn [|
            "relative flex cursor-default select-none items-center rounded-sm px-2 py-1.5 text-sm outline-none aria-selected:bg-accent aria-selected:text-accent-foreground data-[disabled=true]:pointer-events-none data-[disabled=true]:opacity-50"
            props.class'
        |]).spread(props)
    
[<Erase>]
type CommandShortcut() =
    inherit span()
    [<SolidTypeComponent>]
    member props.constructor =
        span( class' = Lib.cn [| "ml-auto text-xs tracking-widest text-muted-foreground"; props.class' |]).spread(props)