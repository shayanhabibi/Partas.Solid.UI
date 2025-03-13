[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageAvatar

open Partas.Solid.UI
open Partas.Solid
open Fable.Core

[<Erase>]
type PageAvatar() =
    inherit VoidNode()
    [<SolidTypeComponentAttribute>]
    member props.compon =
        div() {
            Avatar() {
                AvatarFallback() { "SH" }
            }
        }
