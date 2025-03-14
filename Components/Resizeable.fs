namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Lucide
open Partas.Solid.Corvu
open Fable.Core

[<Erase>]
type Resizeable() =
    inherit Corvu.Resizable()
    [<SolidTypeComponent>]
    member props.constructor =
        Corvu.Resizable(class' = Lib.cn [|
            "flex size-full data-[orientation=vertical]:flex-col"
            props.class'
        |]).spread(props)
[<Erase>]
type ResizeablePanel() =
    inherit Resizable.Panel()
    [<SolidTypeComponentAttribute>]
    member props.constructor = Resizable.Panel().spread props

[<Erase>]
type ResizeableHandle() =
    inherit Resizable.Handle()
    [<Erase>]
    member val withHandle: bool = jsNative with get,set
    [<SolidTypeComponent>]
    member props.constructor =
        Corvu.Resizable.Handle(class' = Lib.cn [|
            "relative flex w-px shrink-0 items-center justify-center
            bg-border after:absolute after:inset-y-0 after:left-1/2 after:w-1
            after:-translate-x-1/2 focus-visible:outline-none
            focus-visible:ring-1 focus-visible:ring-ring focus-visible:ring-offset-1
            data-[orientation=vertical]:h-px data-[orientation=vertical]:w-full
            data-[orientation=vertical]:after:left-0 data-[orientation=vertical]:after:h-1
            data-[orientation=vertical]:after:w-full data-[orientation=vertical]:after:-translate-y-1/2
            data-[orientation=vertical]:after:translate-x-0 [&[data-orientation=vertical]>div]:rotate-90"
            props.class'
        |]).spread(props) {
            Show(when'= props.withHandle) {
                div(class'= "z-10 flex h-4 w-3 items-center justify-center rounded-sm border bg-border") {
                    GripVertical(class'="size-2.5", strokeWidth = 2)
                }
            }
        } 

