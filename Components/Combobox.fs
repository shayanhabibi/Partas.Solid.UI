namespace Partas.Solid.UI
open Partas.Solid
open Partas.Solid.Kobalte
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type Combobox() =
    inherit Kobalte.Combobox()
    // member val options: 'T[] = jsNative with get,set
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.Combobox().spread props
[<Erase>]
type ComboboxItemLabel() =
    inherit Combobox.ItemLabel()
    [<SolidTypeComponent>]
    member props.constructor =
        Combobox.ItemLabel().spread props
[<Erase>]
type ComboboxHiddenSelect() =
    inherit Combobox.HiddenSelect()
    [<SolidTypeComponent>]
    member props.constructor =
        Combobox.HiddenSelect().spread props
[<Erase>]
type ComboboxItem() =
    inherit Combobox.Item()
    [<SolidTypeComponent>]
    member props.constructor =
        Combobox.Item(class' = Lib.cn [|
            "relative flex cursor-default select-none items-center
            justify-between rounded-sm px-2 py-1.5 text-sm outline-none
            data-[disabled]:pointer-events-none data-[highlighted]:bg-accent
            data-[highlighted]:text-accent-foreground data-[disabled]:opacity-50"
            props.class'
        |]).spread(props)
[<Erase>]
type ComboboxItemIndicator() =
    inherit Combobox.ItemIndicator()
    [<SolidTypeComponent>]
    member props.constructor =
        Combobox.ItemIndicator().spread(props) {
             props.children &&= Lucide.Lucide.Check(class' = "size-4", strokeWidth = 2) 
        }
[<Erase>]
type ComboboxSection() =
    inherit Combobox.Section()
    [<SolidTypeComponent>]
    member props.constructor =
        Combobox.Section(class'= Lib.cn [|
            "overflow-hidden p-1 px-2 py-1.5 text-xs font-medium text-muted-foreground"
            props.class'
        |]).spread(props)
[<Erase>]
type ComboboxControl() =
    inherit Combobox.Control()
    [<SolidTypeComponent>]
    member props.constructor =
        Combobox.Control(class' = Lib.cn [|
            "flex h-10 items-center rounded-md border px-3"
            props.class'
        |]).spread(props)
[<Erase>]
type ComboboxInput() =
    inherit Combobox.Input()
    [<SolidTypeComponent>]
    member props.constructor =
        Combobox.Input(class' = Lib.cn [|
            "flex size-full rounded-md bg-transparent py-3
            text-sm outline-none placeholder:text-muted-foreground
            disabled:cursor-not-allowed disabled:opacity-50"
            props.class'
        |]).spread(props)
    
[<Erase>]
type ComboboxTrigger() =
    inherit Combobox.Trigger()
    [<SolidTypeComponent>]
    member props.constructor =
        Combobox.Trigger(class' = Lib.cn [| "size-4 opacity-50" ; props.class' |]).spread(props) {
            Combobox.Icon() {
                props.children ??= unbox (Lucide.Lucide.ArrowUpDown(class'="size-4"))
            }
        }
    
[<Erase>]
type ComboboxContent() =
    inherit Combobox.Content()
    [<SolidTypeComponent>]
    member props.constructor =
        Combobox.Portal() {
            Combobox.Content(class' = Lib.cn [|
                "relative z-50 min-w-32 overflow-hidden
                rounded-md border bg-popover
                text-popover-foreground shadow-md animate-in fade-in-80"
                props.class'
            |]).spread(props) {
                Combobox.Listbox(class'="m-0 p-1")
            }
        }