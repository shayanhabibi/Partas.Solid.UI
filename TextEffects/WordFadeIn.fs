namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Motion
open Fable.Core
open Fable.Core.JS
open Fable.Core.JsInterop

[<Erase>]
type WordFadeIn() =
    inherit VoidNode()
    [<Erase>] member val text: string = unbox null with get,set
    [<Erase>] member val delay: float = unbox null with get,set
    [<Erase>] member val duration: float = unbox null with get,set
    [<Erase>] member val blur: float = unbox null with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.delay <- 0.15
        props.duration <- 1.
        props.blur <- 8.
        div(class' = Lib.cn [| "flex"; props.class' |])
            .spread props
            {
            For(each = (props.text.Split(" "))) {
                yield fun word index ->
                    Motion(
                        initial = motionStyle [
                            MotionStyle.opacity "0"
                            MotionStyle.filter $"blur({props.blur}px)"
                        ],
                        inView = motionStyle [
                            MotionStyle.opacity "1"
                            MotionStyle.filter "blur(0px)"
                        ],
                        inViewOptions = {| once = true |},
                        transition = jsOptions<AnimationOptions>(fun (o: AnimationOptions) ->
                            o.delay <- !!(props.delay + !!index() * !!props.delay)
                            o.duration <- !!props.duration
                            )
                    ) {
                        $"{word}{Lib.nbsp}"
                    }
            }
        }
