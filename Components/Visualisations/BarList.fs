namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Aria
open Partas.Solid.UI
open Partas.Solid.Polymorphism
open Fable.Core
open Fable.Core.JsInterop

[<Import("Dynamic", "solid-js/web")>]
type Dynamic() =
    inherit RegularNode()
    [<Erase>] member val component': HtmlTag = unbox null with get,set

[<JS.Pojo>]
type Bar
    (
        value: int,
        name: string,
        ?icon: obj -> HtmlTag,
        ?href: string,
        ?target: string
    ) =
    member val value: int
    member val name: string
    member val icon: obj -> HtmlTag
    member val href: string
    member val target: string
    new () = Bar()

[<Erase>]
module barList =
    [<StringEnum>]
    type SortOrder =
        | Ascending
        | Descending
        | None
    
    [<Erase>]
    type ValueFormatter = int -> string
    
    let defaultValueFormatter: ValueFormatter = _.ToString()
    
open barList

[<Erase>]
type BarList() =
    inherit div()
    [<Erase>] member val data: Bar[] = unbox null with get,set
    [<Erase>] member val valueFormatter: ValueFormatter = unbox null with get,set
    [<Erase>] member val sortOrder: SortOrder = unbox null with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.valueFormatter <- defaultValueFormatter
        props.sortOrder <- Descending
        let sortedData = fun () ->
            match props.sortOrder with
            | Ascending ->
                props.data
                |> Array.sortBy (fun bar -> bar.value)
            | Descending ->
                props.data
                |> Array.sortByDescending (fun bar -> bar.value)
            | None -> props.data
        let widths = fun () ->
            let values = sortedData() |> Array.map (_.value >> float)
            let maxValue = JS.Math.max values
            sortedData()
            |> Array.map (fun item ->
                if item.value = 0 then 0.
                else
                    JS.Math.max(
                        (float item.value / maxValue) * 100.,
                        2.
                        )
                    )
                
        div(class' = Lib.cn [|
            "flex flex-col space-y-1.5"
            props.class'
        |], ariaSort = !!props.sortOrder).spread(props) {
            For(each = sortedData()) {
                yield fun item index ->
                    div(class' = "row flex w-full justify-between space-x-6") {
                        div(class' = "grow") {
                            div(class' = Lib.cn [|
                                "flex h-8 items-center rounded-md bg-secondary px-2"
                            |]).style'([ Style.width $"{widths()[index()]}%%" ]) {
                                if !!item.icon then Dynamic(component' = item.icon(), class' = "mr-2 size-5 flex-none")
                                if !!item.href then
                                    a(href = item.href,
                                      target = (item.target ??= "_blank"),
                                      rel = "noreferrer",
                                      class' = "hover:underline") { item.name }
                                else p() { item.name }
                            }
                        }
                        div(class' = "flex items-center") {
                            props.valueFormatter(item.value)
                        }
                    }
            }
        }
