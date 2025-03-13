namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Kobalte
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
module alert =
    let variants =
        Lib.cva
            "relative w-full rounded-lg border p-4 [&>svg+div]:translate-y-[-3px] [&>svg]:absolute [&>svg]:left-4 [&>svg]:top-4 [&>svg]:text-foreground [&>svg~*]:pl-7"
            {| variants =
                {| variant =
                    {| ``default`` = "bg-background text-foreground"
                       destructive =
                        "border-destructive/50 text-destructive dark:border-destructive [&>svg]:text-destructive" |} |}
               defaultVariants = {| variant = "default" |} |}
    
    type [<Erase>] variant =
        static member inline ``default``: variant = !!"default"
        static member inline destructive: variant = !!"destructive"

[<Erase>]
type Alert() =
    inherit Kobalte.Alert()
    [<Erase>]
    member val variant: alert.variant = jsNative with get,set
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.Alert(class' = Lib.cn [|
            alert.variants({|variant = props.variant|})
            props.class'
        |]).spread props

[<Erase>]
type AlertTitle() =
    inherit h5()
    [<SolidTypeComponent>]
    member props.constructor =
        h5(class' = Lib.cn [|
            "mb-1 font-medium leading-none tracking-tight"
            props.class'
        |]).spread props

[<Erase>]
type AlertDescription() =
    inherit div()
    [<SolidTypeComponent>]
    member props.constructor =
        div(class' = Lib.cn [|
            "text-sm [&_p]:leading-relaxed"
            props.class'
        |]).spread props

