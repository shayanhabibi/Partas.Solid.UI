namespace Partas.Solid.UI

open Partas.Solid
open Fable.Core

[<Erase>]
module Callout =
    [<StringEnum; RequireQualifiedAccess>]
    type Variant =
        | Default
        | Success
        | Warning
        | Error
        
[<Erase>]
type Callout() =
    inherit div()
    static member variants(?variant: Callout.Variant): string =
        let variant = defaultArg variant Callout.Variant.Default
        "rounded-md border-l-4 p-2 pl-4 " +
        match variant with
        | Callout.Variant.Default -> "border-info-foreground bg-info text-info-foreground"
        | Callout.Variant.Success -> "border-success-foreground bg-success text-success-foreground"
        | Callout.Variant.Warning -> "border-warning-foreground bg-warning text-warning-foreground"
        | Callout.Variant.Error -> "border-error-foreground bg-error text-error-foreground"
    [<Erase>]
    member val variant: Callout.Variant = unbox null with get,set
    
    [<SolidTypeComponent>]
    member props.callout =
        div(
            class' = Lib.cn [|
                Callout.variants(props.variant)
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
