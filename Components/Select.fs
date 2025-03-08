﻿namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Lucide
open Partas.Solid.Kobalte
open Fable.Core

[<Erase>]
type Select() =
    inherit Kobalte.Select()
    [<SolidTypeComponent>]
    member props.constructor = Kobalte.Select().spread props
    
[<Erase>]
type SelectValue() =
    inherit Select.Value()
    [<SolidTypeComponent>]
    member props.constructor = Select.Value().spread props
    
[<Erase>]
type SelectHiddenSelect() =
    inherit Select.HiddenSelect()
    [<SolidTypeComponent>]
    member props.constructor = Select.HiddenSelect().spread props
    
[<Erase>]
type SelectTrigger() =
    inherit Select.Trigger()
    [<SolidTypeComponent>]
    member props.constructor =
        Select.Trigger(class'= Lib.cn [|
            "flex h-10 w-full items-center justify-between rounded-md border border-input bg-transparent px-3 py-2 text-sm ring-offset-background
            placeholder:text-muted-foreground focus:outline-none focus:ring-2 focus:ring-ring focus:ring-offset-2
            disabled:cursor-not-allowed disabled:opacity-50"
            props.class'
        |]).spread(props) {
            props.children
            Select.Icon(class'="size-4") {
                ChevronsUpDown(class' = "size-4 opacity-50")
            }
        }
[<Erase>]
type SelectContent() =
    inherit Select.Content()
    [<SolidTypeComponent>]
    member props.constructor =
        Select.Portal() {
            Select.Content(class' = Lib.cn [|
                "relative z-50 min-w-32 overflow-hidden rounded-md border bg-popover text-popover-foreground shadow-md animate-in fade-in-80"
                props.class'
            |]).spread(props) {
                Select.ListBox(class' = "m-0 p-1")
            }
        }
[<Erase>]
type SelectItem() =
    inherit Select.Item()
    [<SolidTypeComponent>]
    member props.constructor =
        Select.Item(class' = Lib.cn [|
            "relative mt-0 flex w-full cursor-default select-none items-center rounded-sm py-1.5 pl-2 pr-8 text-sm outline-none focus:bg-accent focus:text-accent-foreground data-[disabled]:pointer-events-none data-[disabled]:opacity-50"
            props.class'
        |]).spread(props) {
            Select.ItemIndicator(class' = "absolute right-2 flex size-3.5 items-center justify-center") {
                Check(class'="size-4", strokeWidth = 2)
            }
        }

