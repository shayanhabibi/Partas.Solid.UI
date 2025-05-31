[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageApexChart

open Partas.Solid
open Partas.Solid.ApexCharts
open Fable.Core.JsInterop
open Fable.Core
open Partas.Solid.Experimental.U

[<Erase>]
type PageApexChart() =
    interface VoidNode
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        let options,setOptions = createSignal(Options(
            theme = Theme(
                    monochrome = Theme.Monochrome(enabled = true, color = "#1e293b", shadeTo = Enums.Theme.Monochrome.ShadeTo.Light)
                )
            ,tooltip = Tooltip(followCursor = true)
            ,xaxis = XAxis(categories = [| 1991..1998 |])
        ))
        let chartseries = AxisChartSeries(name = "series-1", data = !^[| 30;40;35;50;49;60;70;91 |])
        let series,setSeries = createSignal([|chartseries|])
        div(class' = "flex w-full items-center justify-center p-8 gap-8") {
            SolidApexCharts(
                    width = "500",
                    type' = Chart.Type.Bar,
                    options = options(),
                    series = series()
                )
            SolidApexCharts(
                    width = "500",
                    type' = Chart.Type.Line,
                    options = options(),
                    series = series()
                )
        }
