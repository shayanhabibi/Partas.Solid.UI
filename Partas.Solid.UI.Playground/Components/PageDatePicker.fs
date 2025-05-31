[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageDatePicker

open System
open Fable.Core.JS
open Partas.Solid.ArkUI
open Partas.Solid.UI
open Glutinum.ZagJs
open Glutinum.Internationalised
open Fable.Core
open Fable.Core.JsInterop
open Partas.Solid

[<PartasImport("Portal", "solid-js/web")>]
type Portal = Partas.Solid.Bindings.Portal

[<Erase>]
type PageDatePicker() =
    interface VoidNode
    
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        let eventHandler: DateValue * LocaleDetails -> string =
            fun event ->
                let date,locale = event
                let parsedDate = Constructors.Date.Create(Constructors.Date.parse(event.ToString()))
                parsedDate.ToShortDateString()
        DatePickerRoot(
        startOfWeek = int DayOfWeek.Monday,
        format = eventHandler
        ) {
            DatePickerControl() {
                DatePickerInput(placeholder = "Pick a date")
                DatePickerTrigger()
            }
            Portal() {
                DatePickerPositioner() {
                    DatePickerContent() {
                        DatePickerDayView()
                        DatePickerMonthView()
                        DatePickerYearView()
                    }
                }
            }
        }
