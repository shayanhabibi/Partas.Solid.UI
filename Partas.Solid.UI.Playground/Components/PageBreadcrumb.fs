[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageBreadcrumb

open Partas.Solid
open Partas.Solid.UI
open Partas.Solid.Polymorphism
open Partas.Solid.Router
open Fable.Core

[<Erase>]
type PageBreadcrumb() =
    interface VoidNode
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(class' = "flex p-6 gap-8") {
            Breadcrumb() {
                BreadcrumbList() {
                    BreadcrumbLink() { "Link" }
                    BreadcrumbSeparator()
                    BreadcrumbItem() { "Item" }
                    BreadcrumbSeparator()
                    BreadcrumbEllipsis()
                    BreadcrumbSeparator()
                    BreadcrumbItem() { BreadcrumbLink().as'(A(href = "/")) { "Item Link" } }
                }
            }
        }
