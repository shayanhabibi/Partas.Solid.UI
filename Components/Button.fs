namespace Partas.Solid.UI

open System
open Partas.Solid
open Partas.Solid.Cva
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
    static member variations (?variant: Button.Variant, ?size: Button.Size) : string =
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
                Button.variations(props.variant,props.size)
                props.class'
            |]
        )
            .spread props

module [<Erase>] button =
    [<Obsolete("Use Button.variants with Button.Variant and Button.Size as this is implemented in idiomatic F# rather than using class-variance-authority")>]
    let variants: obj -> string =
        Lib.cva
            "cursor-pointer disabled:cursor-default inline-flex items-center justify-center gap-2 whitespace-nowrap rounded-md text-sm font-medium transition-colors focus-visible:outline-hidden focus-visible:ring-1 focus-visible:ring-ring disabled:pointer-events-none disabled:opacity-50 [&_svg]:pointer-events-none [&_svg]:size-4 [&_svg]:shrink-0"
            {|
             variants = {|
                          variant = {|
                                      ``default`` = "bg-primary text-primary-foreground shadow-sm hover:bg-primary/90"
                                      destructive = "bg-destructive text-destructive-foreground shadow-xs hover:bg-destructive/90"
                                      outline = "border border-input bg-background shadow-xs hover:bg-accent hover:text-accent-foreground"
                                      secondary = "bg-secondary text-secondary-foreground shadow-xs hover:bg-secondary/80"
                                      ghost = "hover:bg-accent hover:text-accent-foreground"
                                      link = "text-primary underline-offset-4 hover:underline"
                                      |}
                          size = {|
                                   ``default`` = "h-9 px-4 py-2"
                                   small = "h-8 rounded-md px-3 text-xs"
                                   large = "h-10 rounded-md px-8"
                                   icon = "h-9 w-9"
                                   |}
                          |}
             defaultVariants = {|
                                 variant = "default"
                                 size = "default"
                                |}
            |}
    [<Erase>]
    type size =
        static member inline default' : Button.Size = Button.Size.Default
        static member inline sm : Button.Size = Button.Size.Small
        static member inline lg : Button.Size = Button.Size.Large
        static member inline icon : Button.Size = Button.Size.Icon
    [<Erase>]
    type variant =
        static member inline default' : Button.Variant = Button.Variant.Default
        static member inline outline : Button.Variant = Button.Variant.Outline
        static member inline ghost : Button.Variant = Button.Variant.Ghost
        static member inline link : Button.Variant = Button.Variant.Link
        static member inline destructive : Button.Variant = Button.Variant.Destructive
        static member inline secondary : Button.Variant = Button.Variant.Secondary