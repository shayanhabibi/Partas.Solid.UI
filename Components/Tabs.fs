namespace Partas.Solid.UI
open Partas.Solid
open Partas.Solid.Kobalte
open Fable.Core

[<Erase>]
type Tabs() =
    inherit Kobalte.Tabs()
    [<SolidTypeComponentAttribute>]
    member props.constructor = Kobalte.Tabs().spread props

[<Erase>]
type TabsList() =
    inherit Tabs.List()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        Tabs.List(class' = Lib.cn [|
            "inline-flex h-10 items-center justify-center rounded-md bg-muted p-1 text-muted-foreground"
            props.class'
        |]).spread props

[<Erase>]
type TabsTrigger() =
    inherit Tabs.Trigger()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        Tabs.Trigger(class' = Lib.cn [|
            "inline-flex items-center justify-center whitespace-nowrap rounded-sm px-3 py-1.5 text-sm font-medium ring-offset-background transition-all focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-ring focus-visible:ring-offset-2 disabled:pointer-events-none disabled:opacity-50 data-[selected]:bg-background data-[selected]:text-foreground data-[selected]:shadow-sm"
            props.class'
        |]).spread props

[<Erase>]
type TabsContent() =
    inherit Tabs.Content()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        Tabs.Content(class' = Lib.cn [|
            "mt-2 ring-offset-background focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-ring focus-visible:ring-offset-2"
            props.class'
        |]).spread props

[<Erase>]
type TabsIndicator() =
    inherit Tabs.Indicator()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        Tabs.Indicator(class' = Lib.cn [|
            "duration-250ms absolute transition-all data-[orientation=horizontal]:-bottom-px data-[orientation=vertical]:-right-px data-[orientation=horizontal]:h-[2px] data-[orientation=vertical]:w-[2px]"
            props.class'
        |]).spread props