[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageTable

open Partas.Solid
open Partas.Solid.UI
open Fable.Core

[<JS.Pojo>]
type Invoice
    (
        invoice: string,
        paymentStatus: string,
        totalAmount: float,
        paymentMethod: string
    ) =
    member val invoice = invoice with get,set
    member val paymentStatus = paymentStatus with get,set
    member val totalAmount = totalAmount with get,set
    member val paymentMethod = paymentMethod with get,set

let invoices = [|
    Invoice("INV001", "Paid", 250.00, "Credit Card")
    Invoice("INV002", "Pending", 200.00, "Bank Transfer")
    Invoice("INV003", "Unpaid", 50.00, "PayPal")
    Invoice("INV004", "Paid", 350.00, "Credit Card")
    Invoice("INV005", "Paid", 400.00, "Credit Card")
    Invoice("INV006", "Pending", 250.00, "Cash")
    Invoice("INV007", "Unpaid", 550.00, "Credit Card")
|]

[<Erase>]
type PageTable() =
    interface VoidNode
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(class' = "flex items-center justify-center p-6 w-full") {
            Table(class' = "max-w-[800px]") {
                TableCaption() { "A list of your recent invoices." }
                TableHeader() {
                    TableRow() {
                        TableHead(class' = "w-[100px]") { "Invoice" }
                        TableHead() { "Status" }
                        TableHead() { "Method" }
                        TableHead(class' = "text-right") { "Amount" }
                    }
                }
                TableBody() {
                    For(each = invoices) {
                        yield fun item index ->
                            TableRow() {
                                TableCell(class' = "font-medium") { item.invoice }
                                TableCell() { item.paymentStatus }
                                TableCell() { item.paymentMethod }
                                TableCell(class' = "text-right") { $"${item.totalAmount}" }
                            }
                    }
                }
            }
        }
