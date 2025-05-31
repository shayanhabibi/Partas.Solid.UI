namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Motion
open Fable.Core
open Fable.Core.JS
open Fable.Core.JsInterop

[<Erase>]
type WordFadeIn() =
    interface VoidNode
    [<Erase>] member val text: string = unbox null with get,set
    [<Erase>] member val delay: float = unbox null with get,set
    [<Erase>] member val duration: float = unbox null with get,set
    [<Erase>] member val blur: float = unbox null with get,set
    [<Erase>] member val once: bool = undefined with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.delay <- 0.15
        props.duration <- 1.
        props.blur <- 8.
        props.once <- true
        let inline blur value = $"blur({value}px)"
        div(class' = Lib.cn [| "flex"; props.class' |]).spread props
            {
            For(each = (props.text.Split(" "))) {
                yield fun word index ->
                    Motion(
                        initial = [
                            MotionStyle.opacity 0
                            MotionStyle.filter (blur props.blur)
                        ],
                        inView = [
                            MotionStyle.opacity 1
                            MotionStyle.filter (blur 0)
                        ],
                        exit = [
                            MotionStyle.opacity 0
                            MotionStyle.filter (blur props.blur)
                        ],
                        inViewOptions = [ InViewOption.once props.once ],
                        transition = [
                            MotionTransition.delay (props.delay + !!index() * props.delay)
                            MotionTransition.duration (props.duration)
                        ]
                    ) {
                        $"{word}{Lib.nbsp}"
                    }
            }
        }
