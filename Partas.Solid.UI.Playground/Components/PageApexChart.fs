[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageApexChart

open Partas.Solid
open Partas.Solid.ApexCharts
open Fable.Core.JsInterop
open Fable.Core
open Partas.Solid.ApexCharts.ApexCharts
open Partas.Solid.ApexCharts.ApexTheme

[<Erase>]
type PageApexChart() =
    inherit VoidNode()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        let options,setOptions = createSignal(jsOptions<ApexOptions>( fun o ->
            o.theme <- jsOptions<ApexTheme>( fun theme ->
                theme.monochrome <- monochrome(enabled = true, color = "#1e293b", shadeTo = !!"light"))
            o.tooltip <- jsOptions<ApexTooltip>( fun tooltip ->
                tooltip.followCursor <- true)
            o.xaxis <- jsOptions<ApexXAxis>( fun o -> o.categories <-
                                                                         [|
                                                                         1991
                                                                         1992
                                                                         1993
                                                                         1994
                                                                         1995
                                                                         1996
                                                                         1997
                                                                         1998 |])))
        let series,setSeries = createSignal<ChartSeries>(unbox<ChartSeries> [|ApexAxisChartSeries(name = "series-1", data = !![| 30; 40; 35; 50; 49; 60; 70; 91 |])|])
        div(class' = "flex w-full items-center justify-center p-8 gap-8") {
            SolidApexCharts(
                    width = "500",
                    type' = ChartType.bar,
                    options = options(),
                    series = series()
                )
            SolidApexCharts(
                    width = "500",
                    type' = ChartType.line,
                    options = options(),
                    series = series()
                )
        }
