[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageSonner

open Partas.Solid
open Partas.Solid.UI
open Partas.Solid.Sonner
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type PageSonner() =
    inherit VoidNode()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        Fragment() {
            Button(
                variant = button.variant.outline,
                onClick = (fun _ ->
                                Sonner.toast(
                                    "Event has been created",
                                    Toast(description = !!"Sunday, December 03, 2023 at 9:00 AM",
                                          action = Action(
                                              label = !!"Undo", onClick = (
                                                  fun _ -> System.Console.WriteLine("Undo")
                                                  )
                                              )
                                          )
                                    )
                                |> ignore
                                )
            ) { "Show Toast" }
            Sonner.Toaster()
        }
