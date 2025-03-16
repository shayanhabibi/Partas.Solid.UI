[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageCalendar

open Partas.Solid.ArkUI
open Partas.Solid.UI
open Partas.Solid
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type PageCalendar() =
    inherit VoidNode()
    [<SolidTypeComponent>]
    member props.constructor =
        DatePickerRoot(open' = true, class' = "max-w-min") {
            DatePickerContent(class' = "shadow-none") {
                DatePickerView(view = DateView.Day) {
                    DatePickerContext() {
                        yield fun api -> Fragment() {
                        DatePickerViewControl() {
                            DatePickerPrevTrigger()
                            DatePickerViewTrigger() {
                                DatePickerRangeText()
                            }
                            DatePickerNextTrigger()
                        }
                        DatePickerTable() {
                            DatePickerTableHead() {
                                DatePickerTableRow() {
                                    Index(each = api().weekDays) {
                                        yield fun item index ->
                                            DatePickerTableHeader() {
                                                item().short
                                            }
                                    }
                                }
                            }
                            DatePickerTableBody() {
                                Index(each = api().weeks) {
                                    yield fun item index ->
                                        DatePickerTableRow() {
                                            Index(each = item()) {
                                                yield fun day index ->
                                                    DatePickerTableCell(value = !!day()) {
                                                        DatePickerTableCellTrigger() {
                                                            unbox<string> (day()?day)
                                                        }
                                                    }
                                            }
                                        }
                                }
                            }
                        }
                        
                        }
                    }
                }
                DatePickerView(view = Month) {
                    DatePickerContext() {
                        yield fun api -> Fragment() {
                            DatePickerViewControl() {
                                DatePickerPrevTrigger()
                                DatePickerViewTrigger() { DatePickerRangeText() }
                                DatePickerNextTrigger()
                            }
                            DatePickerTable() {
                                DatePickerTableBody() {
                                    Index(each = api().getMonthsGrid(!!createObj [
                                        "columns" ==> unbox<obj> 4
                                        "format" ==> "short"
                                    ])) { yield fun (months) index ->
                                        DatePickerTableRow() {
                                            Index(each = months()) {
                                                yield fun month index ->
                                                    DatePickerTableCell(value = !!month().value) {
                                                        DatePickerTableCellTrigger() {
                                                            month().label
                                                        }
                                                    }
                                            }
                                        } }
                                }
                            }
                        }
                            
                    }
                }
                DatePickerView(view = Year) {
                    DatePickerContext() {
                        yield fun api -> Fragment() {
                            DatePickerViewControl() {
                                DatePickerPrevTrigger()
                                DatePickerViewTrigger() { DatePickerRangeText() }
                                DatePickerNextTrigger()
                            }
                            DatePickerTable() {
                                DatePickerTableBody() {
                                    Index(each = api().getYearsGrid(!!{| columns = 4 |})) {
                                        yield fun years index ->
                                            DatePickerTableRow() {
                                                Index(each = years()) {
                                                    yield fun year index ->
                                                        DatePickerTableCell(value = !!year().value) {
                                                            DatePickerTableCellTrigger() {
                                                                year().label
                                                            }
                                                        } 
                                                }
                                            }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }