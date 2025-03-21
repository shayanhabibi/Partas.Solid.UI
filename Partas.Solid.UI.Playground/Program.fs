module Partas.Solid.UI.Playground

open Browser
open Partas.Solid.UI.Playground.App
open Partas.Solid.UI.Playground.PageAccordion
open Partas.Solid.UI.Playground.Components
open Partas.Solid
open Partas.Solid.Router
open Fable.Core.JsInterop
open Partas.Solid.UI
open Fable.Core

importAll "./index.css"

// [<SolidComponent>]
// let Wrapper(): HtmlElement =
//     SidebarProvider() {
//         App ()
//     }
[<Erase>]
type RootWrapper() =
    inherit RegularNode()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        SidebarProvider(defaultOpen = true) {
            App().spread props
        }


[<SolidComponent>]
let Root () =
    HashRouter(root = !@RootWrapper) {
        Route(path = "/")
        Route(path = "accordion", component' = !@PageAccordion)
        Route(path = "alert", component' = !@PageAlert)
        Route(path = "accordion" ,component' = !@PageAccordion)
        Route(path = "alert" ,component' = !@PageAlert)
        Route(path = "alertdialog" ,component' = !@PageAlertDialog)
        Route(path = "avatar" ,component' = !@PageAvatar)
        Route(path = "badge" ,component' = !@PageBadge)
        Route(path = "breadcrumb" ,component' = !@PageBreadcrumb)
        Route(path = "button" ,component' = !@PageButton)
        // Route(path = "kobaltebutton" ,component' = !@PageKobalteButton)
        Route(path = "callout" ,component' = !@PageCallout)
        Route(path = "card" ,component' = !@PageCard)
        Route(path = "checkbox" ,component' = !@PageCheckbox)
        Route(path = "collapsible" ,component' = !@PageCollapsible)
        Route(path = "combobox" ,component' = !@PageCombobox)
        Route(path = "dialog" ,component' = !@PageDialog)
        Route(path = "command" ,component' = !@PageCommand)
        Route(path = "contextmenu" ,component' = !@PageContextMenu)
        Route(path = "drawer" ,component' = !@PageDrawer)
        Route(path = "dropdownmenu" ,component' = !@PageDropdownMenu)
        Route(path = "hovercard" ,component' = !@PageHoverCard)
        Route(path = "label" ,component' = !@PageLabel)
        Route(path = "menubar" ,component' = !@PageMenubar)
        Route(path = "navigationmenu" ,component' = !@PageNavigationMenu)
        Route(path = "numberfield" ,component' = !@PageNumberField)
        Route(path = "otpfield" ,component' = !@PageOtpField)
        Route(path = "pagination" ,component' = !@PagePagination)
        Route(path = "popover" ,component' = !@PagePopover)
        Route(path = "radiogroup" ,component' = !@PageRadioGroup)
        Route(path = "resizeable" ,component' = !@PageResizeable)
        Route(path = "select" ,component' = !@PageSelect)
        Route(path = "separator" ,component' = !@PageSeparator)
        Route(path = "sheet" ,component' = !@PageSheet)
        Route(path = "sidebar" ,component' = !@PageSidebar)
        Route(path = "skeleton" ,component' = !@PageSkeleton)
        Route(path = "slider" ,component' = !@PageSlider)
        Route(path = "sonner" ,component' = !@PageSonner)
        Route(path = "switch" ,component' = !@PageCard)
        Route(path = "table" ,component' = !@PageTable)
        Route(path = "tabs" ,component' = !@PageTabs)
        Route(path = "text" ,component' = !@PageTabs)
        Route(path = "timeline" ,component' = !@PageTimeline)
        Route(path = "toggle" ,component' = !@PageToggle)
        Route(path = "togglegroup" ,component' = !@PageToggle)
        Route(path = "tooltip", component' = !@PageSidebar)
        Route(path = "barlist", component' = !@PageBarList)
        Route(path = "deltabar", component' = !@PageDeltaBar)
        Route(path = "progress", component' = !@PageProgress)
        Route(path = "flex", component' = !@PageFlex)
        Route(path = "calendar", component' = !@PageCalendar)
        Route(path = "datepicker", component' = !@PageDatePicker)
        Route(path = "datatable", component' = !@PageDataTable)
        Route(path = "grid", component' = !@PageGrid)
        Route(path = "apexchart", component' = !@PageApexChart)
    }

render (Root, document.getElementById "root")