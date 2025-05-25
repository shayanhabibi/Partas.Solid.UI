namespace Partas.Solid.UI

open Partas.Solid
open Fable.Core

[<Erase>]
type Table() =
    inherit table()
    [<SolidTypeComponent>]
    member props.constructor =
        div(class' = "relative w-full overflow-auto") {
            table(class' = Lib.cn [| "w-full caption-bottom text-sm"; props.class' |])
                .spread props
        }

[<Erase>]
type TableHeader() =
    inherit thead()
    [<SolidTypeComponent>]
    member props.constructor =
        thead(class' = Lib.cn [| "[&_tr]:border-b"
                                 props.class' |])
            .spread props

[<Erase>]
type TableBody() =
    inherit tbody()
    [<SolidTypeComponent>]
    member props.constructor =
        tbody(class' = Lib.cn [|
            "[&_tr:last-child]:border-0"
            props.class'
        |]).spread props

[<Erase>]
type TableFooter() =
    inherit tfoot()
    [<SolidTypeComponent>]
    member props.constructor =
        tfoot(class' = Lib.cn [|
            "bg-primary font-medium text-primary-foreground"
            props.class'
        |]).spread props

[<Erase>]
type TableRow() =
    inherit tr()
    [<SolidTypeComponent>]
    member props.constructor =
        tr(
            class' = Lib.cn [|
                "border-b transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted"
                props.class'
            |]
        ).spread props

[<Erase>]
type TableHead() =
    inherit th()
    [<SolidTypeComponent>]
    member props.constructor =
        th(
            class' = Lib.cn [|
                "h-10 px-2 text-left align-middle font-medium
                text-muted-foreground [&:has([role=checkbox])]:pr-0"
                props.class'
            |]
        ).spread props

[<Erase>]
type TableCell() =
    inherit td()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        td(class' = Lib.cn [| "p-2 align-middle [&:has([role=checkbox])]:pr-0"; props.class' |]).spread props
        
[<Erase>]
type TableCaption() =
    inherit caption()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        caption(class' = Lib.cn [| "mt-4 text-sm text-muted-foreground"; props.class' |]).spread props
        