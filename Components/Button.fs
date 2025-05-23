namespace Partas.Solid.UI

open System
open Partas.Solid
open Fable.Core

module Button =
    [<RequireQualifiedAccess; StringEnum>]
    type Size =
        | Default
        | Small
        | Large
        | Icon
    [<RequireQualifiedAccess; StringEnum>]
    type Variant =
        | Default
        | Outline
        | Ghost
        | Link
        | Destructive
        | Secondary

[<Erase>]
type Button() =
    inherit Kobalte.Button()
    static member variants (?variant: Button.Variant, ?size: Button.Size) : string =
        let variant = defaultArg variant Button.Variant.Default
        let size = defaultArg size Button.Size.Default
        "cursor-pointer disabled:cursor-default inline-flex items-center justify-center
        gap-2 whitespace-nowrap rounded-md text-sm font-medium transition-colors
        focus-visible:outline-hidden focus-visible:ring-1 focus-visible:ring-ring
        disabled:pointer-events-none disabled:opacity-50
        [&_svg]:pointer-events-none [&_svg]:size-4 [&_svg]:shrink-0 " +
        match variant with
        | Button.Variant.Default ->     "bg-primary text-primary-foreground shadow-sm hover:bg-primary/90"
        | Button.Variant.Destructive -> "bg-destructive text-destructive-foreground shadow-xs hover:bg-destructive/90"
        | Button.Variant.Outline ->     "border border-input bg-background shadow-xs hover:bg-accent hover:text-accent-foreground"
        | Button.Variant.Secondary ->   "bg-secondary text-secondary-foreground shadow-xs hover:bg-secondary/80"
        | Button.Variant.Ghost ->       "hover:bg-accent hover:text-accent-foreground"
        | Button.Variant.Link ->        "text-primary underline-offset-4 hover:underline"
        + " " +
        match size with
        | Button.Size.Default ->        "h-9 px-4 py-2"
        | Button.Size.Small ->          "h-8 rounded-md px-3 text-xs"
        | Button.Size.Large ->          "h-10 rounded-md px-8"
        | Button.Size.Icon ->           "h-9 w-9"
    [<Erase>]
    member val size: Button.Size = jsNative with get,set
    [<Erase>]
    member val variant: Button.Variant = jsNative with get,set
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.Button(
            class' = Lib.cn [|
                Button.variants(props.variant,props.size)
                props.class'
            |]
        )
            .spread props