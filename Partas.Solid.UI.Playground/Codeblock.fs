[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.Codeblock

open Partas.Solid
open Fable.Core

[<Erase>]
type Codeblock() =
    inherit RegularNode()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        pre() {
            code(class' = "language-fsharp").spread props
        }

