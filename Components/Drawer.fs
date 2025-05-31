namespace Partas.Solid.UI

open Partas.Solid.Polymorphism
open Partas.Solid
open Partas.Solid.Style
open Partas.Solid.Corvu
open Fable.Core
open Fable.Core.JsInterop

[<RequireQualifiedAccess>]
module Drawer =
    [<Import("useContext", "@corvu/drawer")>]
    let useContext (): obj = jsNative
    
[<Erase>]
type Drawer() =
    inherit Corvu.Drawer()
    [<SolidTypeComponent>]
    member props.constructor = Corvu.Drawer().spread props
    
[<Erase>]
type DrawerTrigger() =
    inherit Drawer.Trigger()
    interface Polymorph
    [<SolidTypeComponent>]
    member props.constructor = Drawer.Trigger().spread props
    
[<Erase>]
type DrawerPortal() =
    inherit Drawer.Portal()
    [<SolidTypeComponent>]
    member props.constructor = Drawer.Portal().spread props
    
[<Erase>]
type DrawerClose() =
    inherit Drawer.Close()
    interface Polymorph
    [<SolidTypeComponent>]
    member props.constructor = Drawer.Close().spread props
    
[<Erase>]
type DrawerOverlay() =
    inherit Drawer.Overlay()
    [<SolidTypeComponent>]
    member props.constructor =
        let drawerContext = Drawer.useContext()
        Corvu.Drawer.Overlay(class'= Lib.cn [|
            "fixed inset-0 z-50 data-[transitioning]:transition-colors data-[transitioning]:duration-300"
            props.class'
        |]).spread(props).style'([
            Style.backgroundColor $"rgb(0 0 0 / {0.8 * drawerContext?openPercentage()})"
        ])
[<Erase>]
type DrawerContent() =
    inherit Drawer.Content()
    [<SolidTypeComponent>]
    member props.constructor =
        DrawerPortal() {
            DrawerOverlay()
            Corvu.Drawer.Content(class'= Lib.cn [|
                "fixed inset-x-0 bottom-0 z-50 mt-24 flex h-auto
                flex-col rounded-t-[10px] border bg-background
                after:absolute after:inset-x-0 after:top-full
                after:h-1/2 after:bg-inherit data-[transitioning]:transition-transform
                data-[transitioning]:duration-300 md:select-none"
                props.class'
            |]).spread(props) {
                div(class'="mx-auto mt-4 h-2 w-[100px] rounded-full bg-muted")
                props.children
            }
        }
[<Erase>]
type DrawerHeader() =
    inherit div()
    [<SolidTypeComponent>]
    member props.constructor =
        div(class'= Lib.cn [|
            "grid gap-1.5 p-4 text-center sm:text-left"
            props.class'
        |]).spread(props)   
[<Erase>]
type DrawerFooter() =
    inherit div()
    [<SolidTypeComponent>]
    member props.constructor =
        div(class'= Lib.cn [|
            "t-auto flex flex-col gap-2 p-4"
            props.class'
        |]).spread(props)
[<Erase>]
type DrawerTitle() =
    inherit Drawer.Label()
    [<SolidTypeComponent>]
    member props.constructor =
        Corvu.Drawer.Label(class'= Lib.cn [|
            "text-lg font-semibold leading-none tracking-tight"
            props.class'
        |]).spread(props)
[<Erase>]
type DrawerDescription() =
    inherit Drawer.Description()
    [<SolidTypeComponent>]
    member props.constructor =
        Corvu.Drawer.Description(class'=Lib.cn [|"text-sm text-muted-foreground"; props.class'|]).spread(props)


