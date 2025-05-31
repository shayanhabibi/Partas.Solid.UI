[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PagePagination

open Partas.Solid
open Partas.Solid.UI
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type PagePagination() =
    interface VoidNode
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(class' = "flex w-full p-6") {
            Pagination(
                count = 10,
                fixedItems = Kobalte.pagination.fixedItems.true',
                itemComponent = (fun itemProps -> PaginationItem(page = itemProps?page) { itemProps?page }),
                ellipsisComponent = (fun _ -> PaginationEllipsis())
            ) {
                PaginationPrevious()
                PaginationItems()
                PaginationNext()
            }
        }
