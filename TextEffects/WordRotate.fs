namespace Partas.Solid.UI

open Fable.Core
open Fable.Core.JS
open Fable.Core.JsInterop
open Partas.Solid
open Partas.Solid.Experimental.U
open Partas.Solid.Motion

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
                    initial = [
                        MotionStyle.opacity 0
                        MotionStyle.y -50
                    ],
                    animate = [
                        MotionStyle.opacity 1
                        MotionStyle.y 0
                    ],
                    exit = [
                        MotionStyle.opacity 0
                        MotionStyle.y 50
                    ],
                    transition = [
                        MotionTransition.duration 0.25
                        MotionTransition.easing Easing.EaseOut
                    ]
                ).spread props {
                    props.words[index()]
                }
            }
        }
