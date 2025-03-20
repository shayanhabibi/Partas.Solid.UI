namespace Partas.Solid.UI

open Partas.Solid
open Fable.Core
open Fable.Core.JsInterop


[<StringEnum; RequireQualifiedAccess>]
type Cols =
    | [<CompiledValue(0)>] _0
    | [<CompiledValue(1)>] _1
    | [<CompiledValue(2)>] _2
    | [<CompiledValue(3)>] _3
    | [<CompiledValue(4)>] _4
    | [<CompiledValue(5)>] _5
    | [<CompiledValue(6)>] _6
    | [<CompiledValue(7)>] _7
    | [<CompiledValue(8)>] _8
    | [<CompiledValue(9)>] _9
    | [<CompiledValue(10)>] _10
    | [<CompiledValue(11)>] _11
    | [<CompiledValue(12)>] _12

[<StringEnum; RequireQualifiedAccess>]
type Span =
    | [<CompiledValue(1)>] _1
    | [<CompiledValue(2)>] _2
    | [<CompiledValue(3)>] _3
    | [<CompiledValue(4)>] _4
    | [<CompiledValue(5)>] _5
    | [<CompiledValue(6)>] _6
    | [<CompiledValue(7)>] _7
    | [<CompiledValue(8)>] _8
    | [<CompiledValue(9)>] _9
    | [<CompiledValue(10)>] _10
    | [<CompiledValue(11)>] _11
    | [<CompiledValue(12)>] _12
    | [<CompiledValue(13)>] _13
    
[<AutoOpen; Erase>]
module private Classes =
    let gridCols: Map<Cols, string> = Map<Cols, string>(seq {
            Cols._0, "grid-cols-none"
            Cols._1, "grid-cols-1"
            Cols._2, "grid-cols-2"
            Cols._3, "grid-cols-3"
            Cols._4, "grid-cols-4"
            Cols._5, "grid-cols-5"
            Cols._6, "grid-cols-6"
            Cols._7, "grid-cols-7"
            Cols._8, "grid-cols-8"
            Cols._9, "grid-cols-9"
            Cols._10, "grid-cols-10"
            Cols._11, "grid-cols-11"
            Cols._12, "grid-cols-12"
        })
    let gridColsSm: Map<Cols, string> = Map<Cols, string>(seq {
            Cols._0, "sm:grid-cols-none"
            Cols._1, "sm:grid-cols-1"
            Cols._2, "sm:grid-cols-2"
            Cols._3, "sm:grid-cols-3"
            Cols._4, "sm:grid-cols-4"
            Cols._5, "sm:grid-cols-5"
            Cols._6, "sm:grid-cols-6"
            Cols._7, "sm:grid-cols-7"
            Cols._8, "sm:grid-cols-8"
            Cols._9, "sm:grid-cols-9"
            Cols._10, "sm:grid-cols-10"
            Cols._11, "sm:grid-cols-11"
            Cols._12, "sm:grid-cols-12"
        })
    let gridColsMd: Map<Cols, string> = Map<Cols, string>(seq {
            Cols._0, "md:grid-cols-none"
            Cols._1, "md:grid-cols-1"
            Cols._2, "md:grid-cols-2"
            Cols._3, "md:grid-cols-3"
            Cols._4, "md:grid-cols-4"
            Cols._5, "md:grid-cols-5"
            Cols._6, "md:grid-cols-6"
            Cols._7, "md:grid-cols-7"
            Cols._8, "md:grid-cols-8"
            Cols._9, "md:grid-cols-9"
            Cols._10, "md:grid-cols-10"
            Cols._11, "md:grid-cols-11"
            Cols._12, "md:grid-cols-12"
        })
    let gridColsLg: Map<Cols, string> = Map<Cols, string>(seq {
            Cols._0, "lg:grid-cols-none"
            Cols._1, "lg:grid-cols-1"
            Cols._2, "lg:grid-cols-2"
            Cols._3, "lg:grid-cols-3"
            Cols._4, "lg:grid-cols-4"
            Cols._5, "lg:grid-cols-5"
            Cols._6, "lg:grid-cols-6"
            Cols._7, "lg:grid-cols-7"
            Cols._8, "lg:grid-cols-8"
            Cols._9, "lg:grid-cols-9"
            Cols._10, "lg:grid-cols-10"
            Cols._11, "lg:grid-cols-11"
            Cols._12, "lg:grid-cols-12"
        })
         
    let colSpan: Map<Span, string> = Map<Span, string>(seq {
            Span._1, "col-span-1"
            Span._2, "col-span-2"
            Span._3, "col-span-3"
            Span._4, "col-span-4"
            Span._5, "col-span-5"
            Span._6, "col-span-6"
            Span._7, "col-span-7"
            Span._8, "col-span-8"
            Span._9, "col-span-9"
            Span._10, "col-span-10"
            Span._11, "col-span-11"
            Span._12, "col-span-12"
            Span._13, "col-span-13"
        })
    let colSpanSm: Map<Span, string> = Map<Span, string>(seq {
            Span._1, "sm:col-span-1"
            Span._2, "sm:col-span-2"
            Span._3, "sm:col-span-3"
            Span._4, "sm:col-span-4"
            Span._5, "sm:col-span-5"
            Span._6, "sm:col-span-6"
            Span._7, "sm:col-span-7"
            Span._8, "sm:col-span-8"
            Span._9, "sm:col-span-9"
            Span._10, "sm:col-span-10"
            Span._11, "sm:col-span-11"
            Span._12, "sm:col-span-12"
            Span._13, "sm:col-span-13"
        })
    let colSpanMd: Map<Span, string> = Map<Span, string>(seq {
            Span._1, "md:col-span-1"
            Span._2, "md:col-span-2"
            Span._3, "md:col-span-3"
            Span._4, "md:col-span-4"
            Span._5, "md:col-span-5"
            Span._6, "md:col-span-6"
            Span._7, "md:col-span-7"
            Span._8, "md:col-span-8"
            Span._9, "md:col-span-9"
            Span._10, "md:col-span-10"
            Span._11, "md:col-span-11"
            Span._12, "md:col-span-12"
            Span._13, "md:col-span-13"
        })
    let colSpanLg: Map<Span, string> = Map<Span, string>(seq {
            Span._1, "lg:col-span-1"
            Span._2, "lg:col-span-2"
            Span._3, "lg:col-span-3"
            Span._4, "lg:col-span-4"
            Span._5, "lg:col-span-5"
            Span._6, "lg:col-span-6"
            Span._7, "lg:col-span-7"
            Span._8, "lg:col-span-8"
            Span._9, "lg:col-span-9"
            Span._10, "lg:col-span-10"
            Span._11, "lg:col-span-11"
            Span._12, "lg:col-span-12"
            Span._13, "lg:col-span-13"
        })

[<Erase>]
type Grid() =
    inherit div()
    [<Erase>] member val cols: Cols = unbox null with get,set
    [<Erase>] member val colsSm: Cols = unbox null with get,set
    [<Erase>] member val colsMd: Cols = unbox null with get,set
    [<Erase>] member val colsLg: Cols = unbox null with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.cols <- Cols._1
        div(
            class' = Lib.cn [|
                "grid"
                gridCols[props.cols]
                props.colsSm &&= gridColsSm[props.colsSm]
                props.colsMd &&= gridColsMd[props.colsMd]
                props.colsLg &&= gridColsLg[props.colsLg]
                props.class'
            |]
        ).spread props
        
[<Erase>]
type Col() =
    inherit div()
    [<Erase>] member val span: Span = unbox null with get,set
    [<Erase>] member val spanSm: Span = unbox null with get,set
    [<Erase>] member val spanMd: Span = unbox null with get,set
    [<Erase>] member val spanLg: Span = unbox null with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.span <- Span._1
        div(
            class' = Lib.cn [|
                "grid"
                colSpan[props.span]
                props.spanSm &&= colSpanSm[props.spanSm]
                props.spanMd &&= colSpanMd[props.spanMd]
                props.spanLg &&= colSpanLg[props.spanLg]
                props.class'
            |]
        ).spread props
