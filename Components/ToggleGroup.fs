namespace Partas.Solid.UI

open System
open System.Runtime.CompilerServices
open Partas.Solid
open Partas.Solid.Kobalte
open Fable.Core

[<Erase>]
module toggleGroup =
    [<StringEnum>]
    type size = toggle.size
    [<StringEnum>]
    type variant = toggle.variant
    type ToggleGroupsContext = {| size: size; variant: variant |}

open toggleGroup

[<AutoOpen; Erase>]
module ToggleGroup =
    [<Erase>]
    module Context =
        let ToggleGroupContext = createContext<ToggleGroupsContext>({| size = size.Default; variant = variant.Default |})

[<Erase>]
type ToggleGroup() =
    inherit Kobalte.ToggleGroup()
    member val size: size = unbox null with get,set
    member val variant: variant = unbox null with get,set
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.ToggleGroup(
            class' = Lib.cn [|
                "flex items-center justify-center gap-1"
                props.class'
            |]
            ).spread props
            {
                Context.ToggleGroupContext({| size = props.size; variant = props.variant |}) {
                    props.children
                }
            }

[<Erase>]
type ToggleGroupItem() =
    inherit ToggleGroup.Item()
    member val size: size = unbox null with get,set
    member val variant: variant = unbox null with get,set
    [<SolidTypeComponent>]
    member props.constructor =
        let context = useContext(Context.ToggleGroupContext)
        ToggleGroup.Item(
            class' = Lib.cn [|
                toggle.variants({|
                    size = props.size &&= context.size
                    variant = props.variant &&= context.variant
                |})
                "hover:bg-muted hover:text-muted-foreground
                data-[pressed]:bg-accent data-[pressed]:text-accent-foreground"
                props.class'
            |]
            ).spread props