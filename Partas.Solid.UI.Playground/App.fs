module Partas.Solid.UI.Playground.App

open Partas.Solid.Polymorphism
open Partas.Solid
open Partas.Solid.UI
open Partas.Solid.Router
open Fable.Core
open Fable.Core.JsInterop

type Page = { Constructor: HtmlContainer
              Name: string
              Icon: Lucide.Icon }

[<JS.Pojo>]
type MenuItem(title: string, url: string, icon: Lucide.IconNode) =
    member val title = title
    member val url = url
    member val icon = icon


[<Erase>]
type AppSidebar() =
    inherit Sidebar()
    [<Erase>] member val items: MenuItem array = unbox null with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        Sidebar(
            collapsible = sidebar.Collapsible.Icon,
            variant = sidebar.Variant.Floating
        ) {
            SidebarHeader() {
                DropdownMenu() {
                    DropdownMenuTrigger() {
                        SidebarMenuButton(
                            size = sidebarMenuButton.Large,
                            class' = "data-[state=open]:bg-sidebar-accent data-[state=open]:text-sidebar-accent-foreground"
                            ) {
                            div(class' = "flex aspect-square size-8 items-center justify-center rounded-lg bg-sidebar-primary text-sidebar-primary-foreground") {
                                Lucide.Lucide.BringToFront()
                            }
                            div(class' = "grid flex-1 text-left text-sm leading-tight") {
                                span(class' = "font-semibold truncate") { "Partas" }
                                span(class' = "text-xs truncate") { "Components" }
                                
                            }
                            Lucide.Lucide.ChevronsUpDown(class' = "ml-auto")
                        }
                    }
                    DropdownMenuContent(
                        class' = "w-(--kobalte-dropdown-menu-trigger-width) min-w-56 rounded-lg"
                    ) {
                        DropdownMenuLabel() { "Partas" }
                        DropdownMenuSeparator()
                        DropdownMenuItem(
                            id = "settings",
                            class' = "gap-2 p-2"
                        ) {
                            div(class' = "flex size-6 items-center justify-center rounded-xs border")
                                { Lucide.Lucide.Settings(class' = "size-4 shrink-0") }
                            "Settings"
                            DropdownMenuShortcut() { "Alt+S" }
                        }
                    }
                }
            }
            SidebarRail()
            SidebarContent(
            ) {
                SidebarGroup() {
                    SidebarGroupLabel() { "Components" }
                    SidebarGroupContent() {
                        SidebarMenu() {
                            For(each = props.items) {
                                yield fun item index ->
                                    SidebarMenuItem() {
                                        SidebarMenuButton(tooltip = item.title).as'(A(href= item.url)) {
                                            item.icon
                                            span() { item.title }
                                        }
                                    }
                            }
                        }
                    }
                }
                SidebarGroup()
            }
            SidebarFooter()
        }

[<Erase>]
type App() =
    inherit RegularNode()
    [<SolidTypeComponent>]
    member props.constructor =
        let initialItems = [|
            MenuItem("Accordion", "accordion", Lucide.Lucide.ListCollapse())
            MenuItem("Alert", "alert", Lucide.Lucide.CircleAlert())
            MenuItem("AlertDialog", "alertdialog", Lucide.Lucide.MessageSquareWarning())
            MenuItem("Avatar", "avatar", Lucide.Lucide.CircleUser())
            MenuItem("Badge", "badge", Lucide.Lucide.Badge())
            MenuItem("Breadcrumb", "breadcrumb", Lucide.Lucide.Ellipsis())
            MenuItem("Button", "button", Lucide.Lucide.SquarePlus())
            // MenuItem("KobalteButton", "kobaltebutton", Lucide.Lucide.SquareMinus())
            MenuItem("Callout", "callout", Lucide.Lucide.Megaphone())
            MenuItem("Card", "card", Lucide.Lucide.IdCard())
            MenuItem("Checkbox", "checkbox", Lucide.Lucide.SquareCheck())
            MenuItem("Collapsible", "collapsible", Lucide.Lucide.ChevronsDownUp())
            MenuItem("Combobox", "combobox", Lucide.Lucide.Rows3())
            MenuItem("Dialog", "dialog", Lucide.Lucide.MessageSquare())
            MenuItem("Command", "command", Lucide.Lucide.SquareChevronRight())
            MenuItem("ContextMenu", "contextmenu", Lucide.Lucide.TableOfContents())
            MenuItem("Drawer", "drawer", Lucide.Lucide.PanelBottomOpen())
            MenuItem("DropdownMenu", "dropdownmenu", Lucide.Lucide.PanelTopOpen())
            MenuItem("HoverCard", "hovercard", Lucide.Lucide.BringToFront())
            MenuItem("Label", "label", Lucide.Lucide.Tag())
            MenuItem("Menubar", "menubar", Lucide.Lucide.AppWindowMac())
            MenuItem("NavigationMenu", "navigationmenu", Lucide.Lucide.PanelTopDashed())
            MenuItem("NumberField", "numberfield", Lucide.Lucide.ArrowDown01())
            MenuItem("OtpField", "otpfield", Lucide.Lucide.SquareAsterisk())
            MenuItem("Pagination", "pagination", Lucide.Lucide.ChevronsLeftRightEllipsis())
            MenuItem("Popover", "popover", Lucide.Lucide.SquareSquare())
            MenuItem("RadioGroup", "radiogroup", Lucide.Lucide.List())
            MenuItem("Resizeable", "resizeable", Lucide.Lucide.Scaling())
            MenuItem("Select", "select", Lucide.Lucide.Rows4())
            MenuItem("Separator", "separator", Lucide.Lucide.SeparatorHorizontal())
            MenuItem("Sheet", "sheet", Lucide.Lucide.PanelLeftOpen())
            MenuItem("Sidebar", "sidebar", Lucide.Lucide.PanelLeftDashed())
            MenuItem("Skeleton", "skeleton", Lucide.Lucide.Bone())
            MenuItem("Slider", "slider", Lucide.Lucide.SlidersHorizontal())
            MenuItem("Sonner", "sonner", Lucide.Lucide.BotMessageSquare())
            MenuItem("Switch", "switch", Lucide.Lucide.CircleOff())
            MenuItem("Table", "table", Lucide.Lucide.Table())
            MenuItem("Tabs", "tabs", Lucide.Lucide.NotebookTabs())
            MenuItem("Text", "text", Lucide.Lucide.Text())
            MenuItem("Timeline", "timeline", Lucide.Lucide.History())
            MenuItem("Toggle", "toggle", Lucide.Lucide.ToggleLeft())
            MenuItem("ToggleGroup", "togglegroup", Lucide.Lucide.ToggleRight())
            MenuItem("Tooltip", "tooltip", Lucide.Lucide.PenTool())
            MenuItem("BarList", "barlist", Lucide.Lucide.ChartBar())
            MenuItem("DeltaBar", "deltabar", Lucide.Lucide.ChartBarDecreasing())
            MenuItem("Progress", "progress", Lucide.Lucide.SlidersHorizontal())
            MenuItem("Flex", "flex", Lucide.Lucide.BicepsFlexed())
            MenuItem("Calendar", "calendar", Lucide.Lucide.Calendar())
            MenuItem("DatePicker", "datepicker", Lucide.Lucide.Calendar1())
            MenuItem("DataTable", "datatable", Lucide.Lucide.Table())
            MenuItem("Grid", "grid", Lucide.Lucide.LayoutGrid())
            MenuItem("Apex Chart", "apexchart", Lucide.Lucide.ChartBar())
        |]
        let (items, setItems) = createSignal(initialItems)
        let (item, addItem) = createSignal<MenuItem>(null)
        div(class' = "flex w-full") {
            AppSidebar(items = items())
            main(
                class' = "p-2 w-full"
            ) {
                SidebarTrigger()
                props.children
            }
        }