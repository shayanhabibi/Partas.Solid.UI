namespace Partas.Solid.UI

open Partas.Solid
open Glutinum.Internationalised
open Glutinum.ZagJs
open Partas.Solid.ArkUI
open Fable.Core
open Fable.Core.JsInterop

[<Erase; AutoOpen>]
module private Imports =
    [<Import("children", "solid-js")>]
    let inline magicChildren (children: 'T): Accessor<'T> = jsNative
    
[<Erase>]
type DatePickerRoot() =
    inherit DatePicker.Root()
    [<SolidTypeComponent>]
    member props.constructor = DatePicker.Root().spread props
[<Erase>]
type DatePickerLabel() =
    inherit DatePicker.Label()
    [<SolidTypeComponent>]
    member props.constructor = DatePicker.Label().spread props
[<Erase>]
type DatePickerContext() =
    inherit DatePicker.Context()
    [<SolidTypeComponent>]
    member props.constructor = DatePicker.Context().spread props
[<Erase>]
type DatePickerTableHead() =
    inherit DatePicker.TableHead()
    [<SolidTypeComponent>]
    member props.constructor = DatePicker.TableHead().spread props
[<Erase>]
type DatePickerTableBody() =
    inherit DatePicker.TableBody()
    [<SolidTypeComponent>]
    member props.constructor = DatePicker.TableBody().spread props
[<Erase>]
type DatePickerYearSelect() =
    inherit DatePicker.YearSelect()
    [<SolidTypeComponent>]
    member props.constructor = DatePicker.YearSelect().spread props
[<Erase>]
type DatePickerMonthSelect() =
    inherit DatePicker.MonthSelect()
    [<SolidTypeComponent>]
    member props.constructor = DatePicker.MonthSelect().spread props
[<Erase>]
type DatePickerPositioner() =
    inherit DatePicker.Positioner()
    [<SolidTypeComponent>]
    member props.constructor = DatePicker.Positioner().spread props
    
[<Erase>]
type DatePickerControl() =
    inherit DatePicker.Control()
    [<SolidTypeComponent>]
    member props.constructor =
        DatePicker.Control(
            class' = Lib.cn [|
                "inline-flex items-center gap-1"
                props.class'
            |]
        ).spread props

[<Erase>]
type DatePickerInput() =
    inherit DatePicker.Input()
    [<SolidTypeComponent>]
    member props.constructor =
        DatePicker.Input(
            class' = Lib.cn [|
                "h-9 w-full rounded-md border border-border bg-background px-3 py-1 text-sm shadow-sm transition-shadow placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-[1.5px] focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50"
                props.class'
            |]
        ).spread props
    
[<Erase>]
type DatePickerTrigger() =
    inherit DatePicker.Trigger()
    [<SolidTypeComponent>]
    member props.constructor =
        let resolvedChildren = magicChildren(props.children)
        let hasChildren = fun _ -> resolvedChildren |> JS.Constructors.Array.from |> _.Length <> 0
        DatePicker.Trigger(
            class' = Lib.cn [|
                "flex min-h-9 min-w-9 items-center justify-center rounded-md border border-border bg-background transition-[box-shadow,background-color] hover:bg-accent/50 focus-visible:outline-none focus-visible:ring-[1.5px] focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50 [&>svg]:size-4"
                props.class'
            |]
        ).spread props {
            if hasChildren() then resolvedChildren() else Lucide.Lucide.Calendar(class' = "size-4", title = "Calendar")
        }

[<Erase>]
type DatePickerContent() =
    inherit DatePicker.Content()
    [<SolidTypeComponent>]
    member props.constructor =
        DatePicker.Content(
            class' = Lib.cn [|
                "z-50 rounded-md border bg-popover p-3 text-popover-foreground shadow-md outline-none data-[state=open]:animate-in data-[state=closed]:animate-out data-[state=closed]:fade-out-0 data-[state=open]:fade-in-0 data-[state=closed]:zoom-out-95 data-[state=open]:zoom-in-95"
                props.class'
            |]
        ).spread props { props.children }

[<Erase>]
type DatePickerView() =
    inherit DatePicker.View()
    [<SolidTypeComponent>]
    member props.constructor =
        DatePicker.View(class' = Lib.cn [| "space-y-4"; props.class' |]).spread props

[<Erase>]
type DatePickerViewControl() =
    inherit DatePicker.ViewControl()
    [<SolidTypeComponent>]
    member props.constructor =
        DatePicker.ViewControl(
            class' = Lib.cn [|
                "flex items-center justify-between gap-4"
                props.class'
            |]
        ).spread props

[<Erase>]
type DatePickerPrevTrigger() =
    inherit DatePicker.PrevTrigger()
    [<SolidTypeComponent>]
    member props.constructor =
        let resolvedChildren = magicChildren(props.children)
        let hasChildren = fun _ -> resolvedChildren |> JS.Constructors.Array.from |> _.Length <> 0
        DatePicker.PrevTrigger(
            class' = Lib.cn [|
                button.variants({| variant = "outline" |})
                "size-7 bg-transparent p-0 opacity-50 hover:opacity-100"
                props.class'
            |]
        ).spread props {
            if hasChildren() then resolvedChildren() else Lucide.Lucide.ChevronLeft(title = "Previous", class' = "size-4")
        }

[<Erase>]
type DatePickerNextTrigger() =
    inherit DatePicker.NextTrigger()
    [<SolidTypeComponent>]
    member props.constructor =
        let resolvedChildren = magicChildren(props.children)
        let hasChildren = fun _ -> resolvedChildren |> JS.Constructors.Array.from |> _.Length <> 0
        DatePicker.NextTrigger(
            class' = Lib.cn [|
                button.variants({| variant = "outline" |})
                "size-7 bg-transparent p-0 opacity-50 hover:opacity-100"
                props.class'
            |]
        ).spread props {
            if hasChildren() then resolvedChildren() else Lucide.Lucide.ChevronRight(title = "Next", class' = "size-4")
        }

[<Erase>]
type DatePickerViewTrigger() =
    inherit DatePicker.ViewTrigger()
    [<SolidTypeComponent>]
    member props.constructor =
        DatePicker.ViewTrigger(
            class' = Lib.cn [|
                button.variants({| variant = "ghost" |})
                "h-7"
                props.class'
            |]
        ).spread props

[<Erase>]
type DatePickerRangeText() =
    inherit DatePicker.RangeText()
    [<SolidTypeComponent>]
    member props.constructor =
        DatePicker.RangeText(class' = Lib.cn [| "text-sm font-medium"; props.class' |]).spread props

[<Erase>]
type DatePickerTable() =
    inherit DatePicker.Table()
    [<SolidTypeComponent>]
    member props.constructor =
        DatePicker.Table(
            class' = Lib.cn [|
                "w-full border-collapse space-y-1"
                props.class'
            |]
        ).spread props
        
[<Erase>]
type DatePickerTableRow() =
    inherit DatePicker.TableRow()
    [<SolidTypeComponent>]
    member props.constructor =
        DatePicker.TableRow(class' = Lib.cn [| "mt-2 flex w-full"; props.class' |]).spread props

[<Erase>]
type DatePickerTableHeader() =
    inherit DatePicker.TableHeader()
    [<SolidTypeComponent>]
    member props.constructor =
        DatePicker.TableHeader(
            class' = Lib.cn [|
                "w-8 flex-1 text-[0.8rem] font-normal text-muted-foreground"
                props.class'
            |]
        ).spread props

[<Erase>]
type DatePickerTableCell() =
    inherit DatePicker.TableCell()
    [<SolidTypeComponent>]
    member props.constructor =
        DatePicker.TableCell(
            class' = Lib.cn [|
                "flex-1 p-0 text-center text-sm has-[[data-range-end]]:rounded-r-md has-[[data-range-start]]:rounded-l-md has-[[data-in-range]]:bg-accent has-[[data-outside-range][data-in-range]]:bg-accent/50 has-[[data-in-range]]:first-of-type:rounded-l-md has-[[data-in-range]]:last-of-type:rounded-r-md"
                props.class'
            |]
        ).spread props

[<Erase>]
type DatePickerTableCellTrigger() =
    inherit DatePicker.TableCellTrigger()
    [<SolidTypeComponent>]
    member props.constructor =
        DatePicker.TableCellTrigger(
            class' = Lib.cn [|
                button.variants({| variant = "ghost" |})
                "size-8 w-full p-0 font-normal data-[selected]:opacity-100"
                "data-[today]:bg-accent data-[today]:text-accent-foreground"
                "[&:is([data-today][data-selected])]:bg-primary [&:is([data-today][data-selected])]:text-primary-foreground"
                "data-[selected]:bg-primary data-[selected]:text-primary-foreground data-[selected]:hover:bg-primary data-[selected]:hover:text-primary-foreground"
                "data-[disabled]:text-muted-foreground data-[disabled]:opacity-50"
                "data-[outside-range]:text-muted-foreground data-[outside-range]:opacity-50"
                "[&:is([data-outside-range][data-in-range])]:bg-accent/50 [&:is([data-outside-range][data-in-range])]:text-muted-foreground [&:is([data-outside-range][data-in-range])]:opacity-30"
                props.class'
            |]
        ).spread props

[<Erase>]
type DatePickerDayView() =
    inherit DatePickerTableCellTrigger()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        DatePickerView(view = Day) {
            DatePickerContext() {
                yield fun api -> Fragment() {
                    DatePickerViewControl() {
                        DatePickerPrevTrigger()
                        DatePickerViewTrigger() { DatePickerRangeText() }
                        DatePickerNextTrigger()
                    }
                    DatePickerTable() {
                        DatePickerTableHead() {
                            DatePickerTableRow() {
                                Index(each = api().weekDays) {
                                    yield fun weekDay index ->
                                        DatePickerTableHeader() { weekDay().short }
                                }
                            }
                        }
                        DatePickerTableBody() {
                            Index(each = api().weeks) {
                                yield fun week index ->
                                    DatePickerTableRow() {
                                        Index(each = week()) {
                                            yield fun day index ->
                                                DatePickerTableCell(value = day()) {
                                                    DatePickerTableCellTrigger().spread props {
                                                        day().day.ToString()
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
[<Erase>]
type DatePickerMonthView() =
    inherit DatePickerTableCellTrigger()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
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
                            Index(each = api().getMonthsGrid(!!{| columns = 4; format = "short" |})) {
                                yield fun months index ->
                                    DatePickerTableRow() {
                                        Index(each = months()) {
                                            yield fun month index ->
                                                DatePickerTableCell(value = !!month().value) {
                                                    DatePickerTableCellTrigger().spread props {
                                                        month().label
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
        
[<Erase>]
type DatePickerYearView() =
    inherit DatePickerTableCellTrigger()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
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
                                                    DatePickerTableCellTrigger().spread props {
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
        