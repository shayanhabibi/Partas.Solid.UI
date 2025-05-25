namespace Partas.Solid.UI

open System
open Partas.Solid
open Partas.Solid.Kobalte
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
module Alert =
    [<RequireQualifiedAccess; StringEnum>]
    type Variant =
        | Default
        | Destructive



[<Erase>]
type Alert() =
    inherit Kobalte.Alert()
    static member variants (?variant: Alert.Variant): string =
        let variant = defaultArg variant Alert.Variant.Default
        "relative w-full rounded-lg border p-4
        [&>svg+div]:translate-y-[-3px]
        [&>svg]:absolute [&>svg]:left-4
        [&>svg]:top-4 [&>svg]:text-foreground
        [&>svg~*]:pl-7 " +
        match variant with
        | Alert.Variant.Default -> "bg-background text-foreground"
        | Alert.Variant.Destructive -> "border-destructive/50 text-destructive dark:border-destructive [&>svg]:text-destructive"
    [<Erase>]
    member val variant: Alert.Variant = jsNative with get,set
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.Alert(class' = Lib.cn [|
            Alert.variants(props.variant)
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

[<Erase>]
module alert =
    [<Obsolete("Use Alert.variants with Alert.Variant instead")>]
    let variants =
        Lib.cva
            "relative w-full rounded-lg border p-4 [&>svg+div]:translate-y-[-3px]
            [&>svg]:absolute [&>svg]:left-4 [&>svg]:top-4
            [&>svg]:text-foreground [&>svg~*]:pl-7"
            {| variants =
                {| variant =
                    {| ``default`` = "bg-background text-foreground"
                       destructive =
                        "border-destructive/50 text-destructive dark:border-destructive [&>svg]:text-destructive" |} |}
               defaultVariants = {| variant = "default" |} |}
    
    type [<Erase>] variant =
        static member inline ``default``: Alert.Variant = Alert.Variant.Default
        static member inline destructive: Alert.Variant = Alert.Variant.Destructive
