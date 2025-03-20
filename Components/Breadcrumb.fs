namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Lucide
open Partas.Solid.Kobalte
open Fable.Core

[<Erase>]
type Breadcrumb() =
    inherit Kobalte.Breadcrumbs()
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.Breadcrumbs().spread props

[<Erase>]
type BreadcrumbList() =
    inherit ol()
    [<SolidTypeComponent>]
    member props.constructor =
        ol(
            class' = Lib.cn [|
                "flex flex-wrap items-center gap-1.5 break-words text-sm text-muted-foreground sm:gap-2.5"
                props.class'
            |]
        ).spread props

[<Erase>]
type BreadcrumbItem() =
    inherit li()
    [<SolidTypeComponent>]
    member props.constructor =
        li( class' = Lib.cn [| "inline-flex items-center gap-1.5" ; props.class' |]).spread props

[<Erase>]
type BreadcrumbLink() =
    inherit Breadcrumbs.Link()
    [<SolidTypeComponent>]
    member props.constructor =
        Breadcrumbs.Link(
            class' = Lib.cn [|
                "transition-colors hover:text-foreground data-[current]:font-normal data-[current]:text-foreground"
                props.class'
            |]).spread props

[<Erase>]
type BreadcrumbSeparator() =
    inherit Breadcrumbs.Separator()
    [<SolidTypeComponent>]
    member props.constructor =
        let children,hasChildren = Lib.createChildrenResolver(props.children)
        Breadcrumbs.Separator(class' = Lib.cn [|"[&>svg]:size-3.5"; props.class'|]).spread(props) {
            if hasChildren() then children() else Lucide.Slash(strokeWidth = 2)
        }

[<Erase>]
type BreadcrumbEllipsis() =
    inherit span()
    [<SolidTypeComponent>]
    member props.constructor =
        span(
            class' = Lib.cn [|
                "flex size-9 items-center justify-center"
                props.class'
            |]
        ).spread(props)
            {
                Lucide.Ellipsis( strokeWidth = 2, class' = "size-4")
                span(class' = "sr-only") { "More" }
            }