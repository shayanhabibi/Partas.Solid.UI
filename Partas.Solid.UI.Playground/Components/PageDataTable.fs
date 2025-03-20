[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageDataTable

open Fable.Core.JS
open Fable.Core.JsInterop
open Partas.Solid.TanStack.Table
open Partas.Solid
open Fable.Core

[<StringEnum>]
type PaymentStatus =
    | Pending
    | Processing
    | Success
    | Failed

[<Pojo>]
type Payment
    (
        id: string,
        amount: float,
        status: PaymentStatus,
        email: string
    ) =
    member val id = id with get,set
    member val amount = amount with get,set
    member val status = status with get,set
    member val email = email with get,set
    
let columns: ColumnDef<Payment>[] = [|
    ColumnDef(accessorKey = "status", header = !!"Status")
    ColumnDef(accessorKey = "email", header = !!"Email")
    ColumnDef(accessorKey = "amount", header = !!"Amount")
|]

[<Erase>]
type DataTable() =
    inherit RegularNode()
    [<Erase>] member val columns: ColumnDef<Payment>[] = unbox null with get,set
    [<Erase>] member val data: Payment[] = unbox null with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        let table = createTable(TableOptions(data = props.data, columns = props.columns, getCoreRowModel = getCoreRowModel()))
        // div()
        div(class' = "rounded-md border") {
            UI.Table() {
                UI.TableHeader() {
                    For(each = table.getHeaderGroups()) {
                        yield fun headerGroup index ->
                            UI.TableRow() {
                                For(each = headerGroup.headers) {
                                    yield fun header index ->
                                        UI.TableHead(colspan = header.colSpan) {
                                            Show(when' = not header.isPlaceholder) {
                                                flexRender(header.column.columnDef.header, header.getContext())
                                            }
                                        }
                                }
                            }
                    }
                }
                UI.TableBody() {
                    Show(when' = unbox (table.getRowModel().rows.Length),
                         fallback = (UI.TableRow() { UI.TableCell(colspan = (props.columns |> _.Length), class' = "h-24 text-center") { "No Results." } }))
                        {
                        For(each = table.getRowModel().rows) {
                            yield fun row index ->
                                UI.TableRow().data("state", !!(row.getIsSelected() && !!"selected")) {
                                    For(each = row.getVisibleCells()) {
                                        yield fun cell index ->
                                            UI.TableCell() {
                                                flexRender(cell.column.columnDef.cell, cell.getContext())
                                            }
                                    }
                                }
                        }
                    }
                }
            }
        }

let data = [|
    Payment(id = "23124", amount = 100., status = Pending, email = "something")
|]

[<Erase>]
type PageDataTable() =
    inherit div()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(class' = "container mx-auto py-10") {
            DataTable(columns = columns, data = data)
        }