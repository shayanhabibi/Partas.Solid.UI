namespace Partas.Solid.UI

open Partas.Solid
open Fable.Core

[<Erase>]
module callout =
    let variants = 
        Lib.cva
            "rounded-md border-l-4 p-2 pl-4"
            {| variants =
                {| variant =
                    {| ``default`` = "border-info-foreground bg-info text-info-foreground"
                       success = "border-success-foreground bg-success text-success-foreground"
                       warning = "border-warning-foreground bg-warning text-warning-foreground"
                       error = "border-error-foreground bg-error text-error-foreground" |} |}
               defaultVariants = {| variant = "default" |} |}
    
    [<StringEnum>]
    type variant =
        | Default
        | Success
        | Warning
        | Error
        
[<Erase>]
type Callout() =
    inherit div()
    [<Erase>]
    member val variant: callout.variant = unbox null with get,set
    
    [<SolidTypeComponent>]
    member props.callout =
        div(
            class' = Lib.cn [|
                callout.variants({| variant = props.variant |})
                props.class'
            |]
            ).spread props

[<Erase>]
type CalloutTitle() =
    inherit h3()
    [<SolidTypeComponent>]
    member props.callout =
        h3(class' = Lib.cn [| "font-semibold"; props.class' |]).spread props
[<Erase>]
type CalloutContent() =
    inherit div()
    [<SolidTypeComponent>]
    member props.callout =
        div(class' = Lib.cn [| "mt-2" ; props.class' |]).spread props
