namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Kobalte
open Fable.Core

[<Erase>]
module toggle =
    let variants =
        Lib.cva
            "inline-flex items-center justify-center rounded-md text-sm font-medium ring-offset-background transition-colors focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-ring focus-visible:ring-offset-2 disabled:pointer-events-none disabled:opacity-50"
            {|
                variants = {|
                    variant = {|
                        ``default`` = "bg-transparent"
                        outline = "border border-input bg-transparent shadow-sm"
                    |}
                    size = {|
                        ``default`` = "h-9 px-3"
                        sm = "h-8 px-2"
                        lg = "h-10 px-3"
                    |}
                |}
                defaultVariants = {|
                    variant = "default"
                    size = "default"
                |}
            |}
    [<StringEnum>]
    type variant =
        | Default
        | Outline
    [<StringEnum>]
    type size =
        | Default
        | [<CompiledName("sm")>] Small
        | [<CompiledName("lg")>] Large

[<Erase>]
type Toggle() =
    inherit ToggleButton()
    interface KobalteStateProvider<{|pressed:(unit -> bool)|}>
    member val variant: toggle.variant = unbox null with get,set
    member val size: toggle.size = unbox null with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        ToggleButton(
                class' = Lib.cn [|
                    toggle.variants({| variant = props.variant; size = props.size |})
                    props.class'
                |]
            ).spread props
