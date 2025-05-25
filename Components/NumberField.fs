namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Kobalte
open Fable.Core

[<Erase>]
type NumberField() =
    inherit Kobalte.NumberField()
    [<SolidTypeComponent>]
    member props.constructor = Kobalte.NumberField().spread props
    
[<Erase>]
type NumberFieldGroup() =
    inherit div()
    [<SolidTypeComponent>]
    member props.constructor =
        div(class' = Lib.cn [|
            "relative rounded-md focus-within:ring-2
            focus-within:ring-ring focus-within:ring-offset-2"
            props.class'
        |]).spread props
[<Erase>]
type NumberFieldLabel() =
    inherit NumberField.Label()
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.NumberField.Label(class'= Lib.cn [|
            "text-sm font-medium leading-none
            peer-disabled:cursor-not-allowed peer-disabled:opacity-70"
            props.class'
        |]).spread(props)
[<Erase>]
type NumberFieldInput() =
    inherit NumberField.Input()
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.NumberField.Input(class' = Lib.cn [|
            "flex h-10 w-full rounded-md border border-input bg-transparent
            px-3 py-2 text-sm ring-offset-background file:border-0 file:bg-transparent
            file:text-sm file:font-medium placeholder:text-muted-foreground
            focus-visible:outline-none disabled:cursor-not-allowed disabled:opacity-50
            data-[invalid]:border-error-foreground data-[invalid]:text-error-foreground"
            props.class'
        |]).spread props
[<Erase>]
type NumberFieldIncrementTrigger() =
    inherit NumberField.IncrementTrigger()
    [<SolidTypeComponent>]
    member props.constructor =
        let children,hasChildren = Lib.createChildrenResolver(props.children)
        Kobalte.NumberField.IncrementTrigger(class' = Lib.cn [|
            "absolute right-1 top-1 inline-flex size-4 items-center justify-center"
            props.class'
        |]).spread(props) {
            if hasChildren() then children() else Lucide.Lucide.ChevronUp(class'="size-4")
        }
[<Erase>]
type NumberFieldDecrementTrigger() =
    inherit NumberField.DecrementTrigger()
    [<SolidTypeComponent>]
    member props.constructor =
        let children, hasChildren = Lib.createChildrenResolver(props.children)
        Kobalte.NumberField.DecrementTrigger(class' = Lib.cn [|
            "absolute bottom-1 right-1 inline-flex size-4 items-center justify-center"
            props.class'
        |]).spread(props) {
            if hasChildren() then children() else Lucide.Lucide.ChevronDown(class' = "size-4")
        }
[<Erase>]
type NumberFieldDescription() =
    inherit NumberField.Description()
    [<SolidTypeComponent>]
    member props.constructor =
        NumberField.Description(class'= Lib.cn [|"text-sm text-muted-foreground"; props.class'|]).spread props
[<Erase>]
type NumberFieldErrorMessage() =
    inherit NumberField.ErrorMessage()
    [<SolidTypeComponent>]
    member props.constructor =
        NumberField.ErrorMessage(class' = Lib.cn [|
            "text-sm text-error-foreground"
            props.class'
        |]).spread(props)

