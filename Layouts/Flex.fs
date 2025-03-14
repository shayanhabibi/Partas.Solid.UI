namespace Partas.Solid.UI

open Partas.Solid
open Fable.Core

[<Erase>]
module flex =
    [<StringEnum>]
    type JustifyContent =
        | Start
        | End
        | Center
        | Between
        | Around
        | Evenly
    
    [<StringEnum>]
    type AlignItems =
        | Start
        | End
        | Center
        | Baseline
        | Stretch
    
    [<StringEnum>]
    type FlexDirection =
        | Row
        | Column
        | ReverseRow
        | ReverseColumn

open flex

[<Erase>]
type Flex() =
    inherit div()
    [<Erase>] member val flexDirection: FlexDirection = unbox null with get,set
    [<Erase>] member val justifyContent: JustifyContent = unbox null with get,set
    [<Erase>] member val alignItems: AlignItems = unbox null with get,set
    static member private justifyContentClassNames = dict <| seq {
            JustifyContent.Start, "justify-start"
            JustifyContent.End, "justify-end"
            JustifyContent.Center, "justify-center"
            JustifyContent.Between, "justify-between"
            JustifyContent.Around, "justify-around"
            JustifyContent.Evenly, "justify-evenly"
        }
    static member private alignItemsClassNames = dict <| seq {
            AlignItems.Start, "items-start"
            AlignItems.End, "items-end"
            AlignItems.Center, "items-center"
            AlignItems.Baseline, "items-baseline"
            AlignItems.Stretch, "items-stretch"
        }
    static member private flexDirectionClassNames = dict <| seq {
            FlexDirection.Row, "flex-row"
            FlexDirection.Column, "flex-col"
            FlexDirection.ReverseRow, "flex-row-reverse"
            FlexDirection.ReverseColumn, "flex-coll-reverse"
        }
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.flexDirection <- Row
        props.justifyContent <- Between
        props.alignItems <- Center
        div(class' = Lib.cn [|
            "flex w-full"
            Flex.flexDirectionClassNames[props.flexDirection]
            Flex.justifyContentClassNames[props.justifyContent]
            Flex.alignItemsClassNames[props.alignItems]
            props.class'
        |]).spread props