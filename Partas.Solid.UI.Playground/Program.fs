namespace Partas.Solid.UI.Playground

open Browser
open Partas.Solid.App
open Partas.Solid.UI.Playground.Components
open Partas.Solid
open Partas.Solid.Router
open Fable.Core.JsInterop
open Partas.Solid.UI
open Fable.Core
open Partas.Solid.UI.Playground.Root

[<Erase>]
module Program =
    importAll "./index.css"


    render (Root, document.getElementById "root")