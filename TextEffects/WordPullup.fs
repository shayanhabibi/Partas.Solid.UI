namespace Partas.Solid.UI

open Partas.Solid
open Fable.Core.JsInterop
open Partas.Solid.Motion
open Fable.Core

[<Erase>]
type WordPullup() =
    inherit VoidNode()
    [<Erase>] member val text: string = unbox null with get,set
    [<Erase>] member val delay: float = unbox null with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.delay <- 0.2
        div(class' = Lib.cn [| "flex"; props.class' |]) {
            For(each = props.text.Split(" ")) {
                yield fun letter index ->
                    Motion(
                        initial = motionStyle [
                            MotionStyle.y 20
                            MotionStyle.opacity "0"
                        ],
                        inView = motionStyle [
                            MotionStyle.y 0
                            MotionStyle.opacity "1"
                        ],
                        inViewOptions = {| once = true |},
                        transition = jsOptions<AnimationOptions>(
                            fun o ->
                                o.delay <- !!(props.delay * !!index())
                        )
                    ) {
                        $"{letter}\u00A0"
                    }
            }
        }
