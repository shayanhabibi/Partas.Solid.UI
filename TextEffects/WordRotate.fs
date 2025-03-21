namespace Partas.Solid.UI

open Fable.Core
open Fable.Core.JS
open Fable.Core.JsInterop
open Partas.Solid
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
                let interval = setInterval (fun () -> setIndex !!(fun prevIndex -> (prevIndex + 1) % (props.words |> _.Length (* Why is this workaround needed? TODO*)))) props.duration
                onCleanup(fun () -> clearInterval(interval))
        )
        Presence(exitBeforeEnter = true) {
            Show(when' = !!(index() + 1), keyed = true) {
                Motion(
                    initial = jsOptions<MotionStyle>(
                        fun o ->
                            o.opacity  <- !!0
                            o.y <- !!(-50)
                        ),
                    animate = jsOptions<MotionStyle>(
                        fun o ->
                            o.opacity <- !!1
                            o.y <- !!0
                    ),
                    exit = jsOptions<MotionStyle>(
                        fun o ->
                            o.opacity <- !!0
                            o.y <- !!50
                    ),
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
