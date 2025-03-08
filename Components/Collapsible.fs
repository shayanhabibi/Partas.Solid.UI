namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Kobalte
open Fable.Core


[<Erase>]
type Collapsible() =
    inherit Kobalte.Collapsible()
    [<SolidTypeComponent>]
    member props.collapsible =
        Kobalte.Collapsible().spread props

[<Erase>]
type CollapsibleTrigger() =
    inherit Collapsible.Trigger()
    [<SolidTypeComponent>]
    member props.collapsible =
        Collapsible.Trigger().spread props
    
[<Erase>]
type CollapsibleContent() =
    inherit Collapsible.Content()
    [<SolidTypeComponent>]
    member props.collapsible =
        Collapsible.Content().spread props