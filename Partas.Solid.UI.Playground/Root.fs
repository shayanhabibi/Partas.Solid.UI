module Partas.Solid.UI.Playground.Root

open Browser
open Browser.Types
open Partas.Solid.App
open Partas.Solid.UI.Playground.Components
open Partas.Solid
open Partas.Solid.Experimental
open Partas.Solid.Router
open Fable.Core.JsInterop
open Partas.Solid.UI
open Fable.Core

[<Erase>]
type RootWrapper() =
    inherit RegularNode()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        let location = useLocation()
        let accordion = PageAccordion()
        let alert = PageAlert()
        let alertDialog = PageAlertDialog()
        let avatar = PageAvatar()
        let badge = PageBadge()
        let breadcrumb = PageBreadcrumb()
        let button = PageButton()
        let callout = PageCallout()
        let card = PageCard()
        let checkbox = PageCheckbox()
        let collapsible = PageCollapsible()
        let combobox = PageCombobox()
        let dialog = PageDialog()
        let command = PageCommand()
        let contextMenu = PageContextMenu()
        let drawer = PageDrawer()
        let dropdownMenu = PageDropdownMenu()
        let hoverCard = PageHoverCard()
        let label = PageLabel()
        let menubar = PageMenubar()
        let navigationMenu = PageNavigationMenu()
        let numberField = PageNumberField()
        let otpField = PageOtpField()
        let pagination = PagePagination()
        let popover = PagePopover()
        let radioGroup = PageRadioGroup()
        let resizeable = PageResizeable()
        let select = PageSelect()
        let separator = PageSeparator()
        let sheet = PageSheet()
        let sidebar = PageSidebar()
        let skeleton = PageSkeleton()
        let slider = PageSlider()
        let sonner = PageSonner()
        let card = PageCard()
        let table = PageTable()
        let tabs = PageTabs()
        let timeline = PageTimeline()
        let toggle = PageToggle()
        let toggle = PageToggle()
        let sidebar = PageSidebar()
        let barList = PageBarList()
        let deltaBar = PageDeltaBar()
        let progress = PageProgress()
        let flex = PageFlex()
        let calendar = PageCalendar()
        let datePicker = PageDatePicker()
        let dataTable = PageDataTable()
        let grid = PageGrid()
        let apexChart = PageApexChart()
        let textEffects = PageTextEffects()
        effect {
            match location.pathname.Substring(1) with
            | "accordion" -> accordion :> HtmlElement
            | "alert" -> alert
            | "alertdialog" -> alertDialog
            | "avatar" -> avatar
            | "badge" -> badge
            | "breadcrumb" -> breadcrumb
            | "button" -> button
            | "callout" -> callout
            | "card" -> card
            | "checkbox" -> checkbox
            | "collapsible" -> collapsible
            | "combobox" -> combobox
            | "dialog" -> dialog
            | "command" -> command
            | "contextmenu" -> contextMenu
            | "drawer" -> drawer
            | "dropdownmenu" -> dropdownMenu
            | "hovercard" -> hoverCard
            | "label" -> checkbox
            | "menubar" -> menubar
            | "navigationmenu" -> navigationMenu
            | "numberfield" -> numberField
            | "otpfield" -> otpField
            | "pagination" -> pagination
            | "popover" -> popover
            | "radiogroup" -> radioGroup
            | "resizeable" -> resizeable
            | "select" -> select
            | "separator" -> separator
            | "sheet" -> sheet
            | "sidebar" -> sidebar
            | "skeleton" -> skeleton
            | "slider" -> slider
            | "sonner" -> sonner
            | "switch" -> tabs
            | "table" -> table
            | "tabs" -> tabs
            | "text" -> tabs
            | "timeline" -> timeline
            | "toggle" -> toggle
            | "togglegroup" -> toggle
            // | "tooltip" -> tooltip
            | "barlist" -> barList
            | "deltabar" -> deltaBar
            | "progress" -> progress
            | "flex" -> flex
            | "calendar" -> calendar
            | "datepicker" -> datePicker
            | "datatable" -> dataTable
            | "grid" -> grid
            | "apexchart" -> apexChart
            | "texteffects" -> textEffects
            | _ -> accordion
            |> unbox<HTMLElement>
            |> _.scrollIntoView(jsOptions<ScrollIntoViewOptions>(fun x -> x.behavior <- ScrollBehavior.Smooth; x.block <- ScrollAlignment.Start; x.``inline`` <- ScrollAlignment.Start))
        }
        SidebarProvider(defaultOpen = true) {
            App() {
                accordion
                alert
                alertDialog
                avatar
                badge
                breadcrumb
                button
                callout
                card
                checkbox
                collapsible
                combobox
                dialog
                command
                contextMenu
                drawer
                dropdownMenu
                hoverCard
                menubar
                navigationMenu
                numberField
                otpField
                pagination
                popover
                radioGroup
                resizeable
                select
                separator
                sheet
                sidebar
                skeleton
                slider
                sonner
                card
                table
                tabs
                timeline
                toggle
                toggle
                sidebar
                barList
                deltaBar
                progress
                flex
                calendar
                datePicker
                dataTable
                grid
                apexChart
                textEffects
            }
        }


[<SolidComponent>]
let Root () =
    HashRouter(root = !@RootWrapper)