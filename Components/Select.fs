namespace Partas.Solid.UI

open Browser.Types
open Partas.Solid
open Partas.Solid.Lucide
open Partas.Solid.Kobalte
open Partas.Solid.Polymorphism
open Fable.Core

[<Erase>]
type Select<'T>() =
    inherit Kobalte.Select<'T>()
    [<SolidTypeComponent>]
    member props.constructor = Kobalte.Select().spread props

[<Erase>]
type SelectValue<'T>() =
    inherit Select.Value<'T>()
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
            "flex h-10 w-full items-center justify-between rounded-md border border-input bg-transparent px-3 py-2 text-sm ring-offset-background placeholder:text-muted-foreground focus:outline-none focus:ring-2 focus:ring-ring focus:ring-offset-2 disabled:cursor-not-allowed disabled:opacity-50"
            props.class'
        |]).spread(props) {
            props.children
            Select.Icon().as'(ChevronsUpDown(class' = "size-4 opacity-50"))
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
                Select.Listbox(class' = "m-0 p-1")
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
            Select.ItemLabel() { props.children }
        }

[<Erase>]
module selectLabel =
    let variants =
        Lib.cva
            "text-sm font-medium leading-none peer-disabled:cursor-not-allowed peer-disabled:opacity-70"
                {|
                variants= {|
                    variant= {|
                        label = "data-[invalid]:text-destructive"
                        description = "font-normal text-muted-foreground"
                        error = "text-xs text-destructive"
                    |}
                |}
                defaultVariants= {|
                        variant = "label"
                    |}
                |}

open selectLabel

[<Erase>]
type SelectLabel() =
    inherit Select.Label()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        Select.Label(class' = Lib.cn [|
            variants()
            props.class'
        |]).spread props

[<Erase>]
type SelectDescription() =
    inherit Select.Description()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        Select.Description(class' = Lib.cn [|
            variants({| variant = "description" |})
            props.class'
        |]).spread props

[<Erase>]
type SelectErrorMessage() =
    inherit Select.ErrorMessage()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        Select.ErrorMessage(class' = Lib.cn [|
            variants({| variant = "error" |})
            props.class'
        |]).spread props

[<AutoOpen; Erase>]
module SelectModularForms =
    [<Erase; RequireQualifiedAccess>]
    module ModularForms =
        type private DV = DefaultValueAttribute
        
        open Fable.Core.JsInterop

        [<Erase>]
        type SelectForm<'T when 'T: equality>() =
            inherit Select<'T>()
            [<DV>] val mutable label: string
            [<DV>] val mutable error: string
            [<DV>] val mutable private ref: Element
            [<DV>] val mutable onInput: (InputEvent -> unit)
            [<DV>] val mutable onBlur: (FocusEvent -> unit)
            [<DV>] val mutable mapOptionValue: ('T -> obj)
            [<DV>] val mutable mapOptionText: ('T -> string)
            [<SolidTypeComponent>]
            member props.constructor =
                let getValue, setValue = createSignal<'T>(Unchecked.defaultof<'T>)
                createEffect(fun () ->
                    setValue(props.options |> Array.tryFind( fun opt -> props.value = opt) |> unbox)
                )
                let rootProps, selectProps = splitProps(props, [|
                    "name"
                    "placeholder"
                    "options"
                    "required"
                    "disabled"
                |], [|
                    "onInput"
                    "onChange"
                    "onBlur"
                    "ref"
                    "placeholder"
                |])
                
                Select<'T>(
                    multiple = false
                    ,value = getValue()
                    ,onChange = setValue
                    ,optionValue = !!props.mapOptionValue
                    ,optionTextValue = !!props.mapOptionText
                    ,validationState = if !!props.error then ValidationState.Invalid else ValidationState.Valid
                    ,itemComponent = (fun comp ->
                        SelectItem(item = comp.item) { comp.item.textValue })
                ).spread(rootProps) {
                    Show(when' = !!props.label) {
                        SelectLabel() { props.label }
                    }
                    SelectHiddenSelect().spread selectProps
                    SelectTrigger() {
                        SelectValue<'T>() {
                            yield fun state ->
                                if isNullOrUndefined props.mapOptionText then
                                    state.selectedOption() |> unbox<HtmlElement>
                                else
                                    state.selectedOption() |> props.mapOptionText |> unbox<HtmlElement>
                        }
                    }
                    SelectContent()
                    SelectErrorMessage() { props.error }
                }