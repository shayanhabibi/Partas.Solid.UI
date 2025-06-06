namespace Partas.Solid.UI

open Partas.Solid
open Fable.Core

[<Erase>]
module Badge =
    [<RequireQualifiedAccess; StringEnum>]
    type Variant =
        | Default
        | Secondary
        | Outline
        | Success
        | Warning
        | Error
        
open Badge

[<Erase>]
type Badge() =
    inherit div()
    static member variants(?variant: Badge.Variant): string =
        let variant = defaultArg variant Badge.Variant.Default
        "inline-flex items-center rounded-md border px-2.5 py-0.5
        text-xs font-semibold transition-colors focus:outline-none
        focus:ring-2 focus:ring-ring focus:ring-offset-2 " +
        match variant with
        | Variant.Default -> "border-transparent bg-primary text-primary-foreground"
        | Variant.Secondary -> "border-transparent bg-secondary text-secondary-foreground"
        | Variant.Outline -> "text-foreground"
        | Variant.Success -> "border-success-foreground bg-success text-success-foreground"
        | Variant.Warning -> "border-warning-foreground bg-warning text-warning-foreground"
        | Variant.Error -> "border-error-foreground bg-error text-error-foreground"
    [<Erase>]
    member val variant: Variant = unbox null with get, set
    [<Erase>]
    member val round: bool = unbox null with get, set

    [<SolidTypeComponent>]
    member props.__ =
        div(
            class' =
                Lib.cn
                    [| Badge.variants(props.variant)
                       if props.round then "rounded-full" else ""
                       props.class' |]
        )
            .spread
            props

[<Erase>]
module BadgeDelta =
    [<RequireQualifiedAccess>]
    [<StringEnum>]
    type Type =
        | Increase
        | ModerateIncrease
        | Unchanged
        | ModerateDecrease
        | Decrease
    
[<Erase>]
[<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
module badgeDelta =
    let variants =
        Lib.cva "" {|
        variants = {|
            variant = {|
                success="bg-success text-success-foreground hover:bg-success"
                warning="bg-warning text-warning-foreground hover:bg-warning"
                error="bg-error text-error-foreground hover:bg-error"
            |}
        |}             
    |}    
    type Type = BadgeDelta.Type

open BadgeDelta

[<Erase>]
type BadgeDelta() =
    inherit Badge()
    [<Erase>]
    member val deltaType: badgeDelta.Type = unbox null with get,set
    [<SolidTypeComponent>]
    member props.__ =
        let typeClass () =
            match props.deltaType with
            | Type.ModerateIncrease
            | Type.Increase -> badgeDelta.variants({| variant = "success" |})
            | Type.Unchanged -> badgeDelta.variants({| variant = "warning" |})
            | Type.ModerateDecrease
            | Type.Decrease -> badgeDelta.variants( {| variant = "error" |} )
        let typeIcon iconClass: HtmlElement =
            match props.deltaType with
            | Type.Increase -> Lucide.Lucide.ArrowUp(class'=iconClass)
            | Type.ModerateIncrease -> Lucide.Lucide.ArrowUpRight(class'=iconClass)
            | Type.Unchanged -> Lucide.Lucide.ArrowRight(class'=iconClass)
            | Type.ModerateDecrease -> Lucide.Lucide.ArrowDownRight(class'=iconClass)
            | Type.Decrease -> Lucide.Lucide.ArrowDown(class'=iconClass)
        let icon () = typeIcon "size-4"
        
        Badge( class' = Lib.cn [|
            typeClass ()
            props.class'
        |]).spread(props) {
            span(class' = "flex gap-1") {
                icon ()
                props.children
            }
        }
