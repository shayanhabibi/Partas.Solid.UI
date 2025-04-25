namespace Partas.Solid.UI

open Partas.Solid
open Fable.Core

module [<Erase>] button =
    let variants =
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
                                   sm = "h-8 rounded-md px-3 text-xs"
                                   lg = "h-10 rounded-md px-8"
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
        static member inline default' : size = unbox "default"
        static member inline sm : size = unbox "sm"
        static member inline lg : size = unbox "lg"
        static member inline icon : size = unbox "icon"
    [<Erase>]
    type variant =
        static member inline default' : variant = unbox "default"
        static member inline outline : variant = unbox "outline"
        static member inline ghost : variant = unbox "ghost"
        static member inline link : variant = unbox "link"
        static member inline destructive : variant = unbox "destructive"
        static member inline secondary : variant = unbox "secondary"

[<Erase>]
type Button() =
    inherit Kobalte.Button()
    [<Erase>]
    member val size: button.size = jsNative with get,set
    [<Erase>]
    member val variant: button.variant = jsNative with get,set
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.Button(
            class' = Lib.cn [|
                button.variants({|size = props.size; variant = props.variant|})
                props.class'
            |]
        )
            .spread props