namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Lucide
open Partas.Solid.Kobalte
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
module Portal =
    [<RequireQualifiedAccess; StringEnum>]
    type Position =
        | Top
        | Bottom
        | Left
        | Right
        static member variants (?position: Position): string =
            let position = defaultArg position Position.Right
            "fixed inset-0 z-50 flex " +
            match position with
            | Top -> "items-start"
            | Bottom -> "items-end"
            | Left -> "justify-start"
            | Right -> "justify-end"

module [<Erase>] sheet =
    let variants =
        Lib.cva
            "fixed z-50 gap-4 bg-background p-6 shadow-lg transition ease-in-out
            data-[closed=]:duration-300 data-[expanded=]:duration-500
            data-[expanded=]:animate-in data-[closed=]:animate-out"
              {|
                variants= {|
                  position= {|
                    top= "inset-x-0 top-0 border-b data-[closed=]:slide-out-to-top
                    data-[expanded=]:slide-in-from-top"
                    bottom=
                      "inset-x-0 bottom-0 border-t data-[closed=]:slide-out-to-bottom
                      data-[expanded=]:slide-in-from-bottom"
                    left= "inset-y-0 left-0 h-full w-3/4 border-r data-[closed=]:slide-out-to-left
                    data-[expanded=]:slide-in-from-left sm:max-w-sm"
                    right= "inset-y-0 right-0 h-full w-3/4 border-l data-[closed=]:slide-out-to-right
                    data-[expanded=]:slide-in-from-right sm:max-w-sm"

                  |}
                |}
                defaultVariants= {|
                  position= "right"
                |}
              |}

[<Erase>]
type Sheet() =
    inherit Kobalte.Dialog()
    [<SolidTypeComponent>]
    member props.constructor = Kobalte.Dialog().spread props
    
[<Erase>]
type SheetTrigger() =
    inherit Dialog.Trigger()
    [<SolidTypeComponent>]
    member props.constructor = Dialog.Trigger().spread props
    
[<Erase>]
type SheetClose() =
    inherit Dialog.CloseButton()
    [<SolidTypeComponent>]
    member props.constructor = Dialog.CloseButton().spread props
    
[<Erase>]
type SheetPortal() =
    inherit Dialog.Portal()
    member val position: Kobalte.Enums.KobaltePlacement = jsNative with get,set
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.Dialog.Portal().spread(props) {
            div(class' = Portal.Position.variants(!!props.position)) {
                props.children
            }
        }
[<Erase>]
type SheetOverlay() =
    inherit Dialog.Overlay()
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.Dialog.Overlay(class' = Lib.cn [|
            "fixed inset-0 z-50 bg-black/80 data-[expanded=]:animate-in data-[closed=]:animate-out
            data-[closed=]:fade-out-0 data-[expanded=]:fade-in-0"
            props.class'
        |]).spread(props)
[<Erase>]
type SheetContent() =
    inherit Dialog.Content()
    member val position: Kobalte.Enums.KobaltePlacement = jsNative with get,set
    [<SolidTypeComponent>]
    member props.constructor =
        SheetPortal(position= props.position) {
            SheetOverlay()
            Kobalte.Dialog.Content(class' = Lib.cn [|
                sheet.variants({| position = props.position |})
                props.class'
                "max-h-screen overflow-y-auto"
            |]).spread(props) {
                props.children
                Kobalte.Dialog.CloseButton(
                    class' = "absolute right-4 top-4 rounded-sm
                    opacity-70 ring-offset-background transition-opacity
                    hover:opacity-100 focus:outline-none focus:ring-2
                    focus:ring-ring focus:ring-offset-2 disabled:pointer-events-none
                    data-[state=open]:bg-secondary") {
                    Lucide.Lucide.X(class'="size-4", strokeWidth = 2)
                }
            }
        }
[<Erase>]
type SheetHeader() =
    inherit div()
    [<SolidTypeComponent>]
    member props.constructor =
        div(class' = Lib.cn [|"flex flex-col space-y-2 text-center sm:text-left"; props.class'|])
            .spread(props)
[<Erase>]
type SheetFooter() =
    inherit div()
    [<SolidTypeComponent>]
    member props.constructor =
        div(class' = Lib.cn [|"flex flex-col-reverse sm:flex-row sm:justify-end sm:space-x-2"; props.class'|])
            .spread(props)
[<Erase>]
type SheetTitle() =
    inherit Dialog.Title()
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.Dialog.Title(class' = Lib.cn [|
            "text-lg font-semibold text-foreground"
            props.class'
        |]).spread(props)
[<Erase>]
type SheetDescription() =
    inherit Dialog.Description()
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.Dialog.Description(class' = Lib.cn [|
            "text-sm text-muted-foreground"
            props.class'
        |]).spread(props)