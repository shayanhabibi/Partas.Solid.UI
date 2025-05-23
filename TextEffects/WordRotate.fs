namespace Partas.Solid.UI

open Fable.Core
open Fable.Core.JS
open Fable.Core.JsInterop
open Partas.Solid
open Partas.Solid.Experimental.U
open Partas.Solid.Motion
open Partas.Solid.Style

[<AutoOpen; Erase>]
module ShowExtension =
    type Show with
        member _.keyed with set(value: bool) = ()
    

[<Erase>]
type WordRotate() =
    inherit div()
    interface OptionKeys
    [<Erase>] member val words: string[] = unbox null with get,set
    [<Erase>] member val duration: int = unbox null with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.duration <- 2500
        let index,setIndex = createSignal(0)
        createEffect(
            fun () ->
                let interval = setInterval (fun () -> setIndex.Invoke(fun prevIndex -> (prevIndex + 1) % (props.words.Length))) props.duration
                onCleanup(fun () -> clearInterval(interval))
        )
        Presence(exitBeforeEnter = true) {
            Show(when' = !!(index() + 1), keyed = true) {
                Motion(
                    initial = createObj [
                        MotionStyle.opacity "0"
                        MotionStyle.y -50
                    ],
                    animate = createObj [
                        MotionStyle.opacity "1"
                        MotionStyle.y 0
                    ],
                    exit = createObj [
                        MotionStyle.opacity "0"
                        MotionStyle.y 50
                    ],
                    transition = jsOptions<AnimationOptions>(
                        fun o ->
                            o.duration <- Some 0.25
                            o.easing <- Some AnimationOptions.easing.``ease-out``
                    )
                ).spread props {
                    props.words[index()]
                }
            }
        }
