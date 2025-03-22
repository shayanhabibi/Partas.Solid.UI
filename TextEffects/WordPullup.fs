namespace Partas.Solid.UI

open Partas.Solid
open Fable.Core.JsInterop
open Partas.Solid.Motion
open Fable.Core

[<Erase>]
type WordPullup() =
    inherit VoidNode()
    [<Erase>] member val text: string = unbox null with get,set
    [<Erase>] member val delay: int = unbox null with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(class' = Lib.cn [| "flex"; props.class' |]) {
            For(each = props.text.Split(" ")) {
                yield fun letter index ->
                    Motion(
                        initial = jsOptions<MotionStyle>(
                            fun o ->
                                o.y <- !!20
                                o.opacity <- !!0
                        ),
                        inView = jsOptions<MotionStyle>(
                            fun o ->
                                o.y <- !!0
                                o.opacity <- !!1
                        ),
                        inViewOptions = {| once = true |},
                        transition = jsOptions<AnimationOptions>(
                            fun o ->
                                o.delay <- !!(props.delay * index())
                        )
                    ) {
                        $"{letter}&nbsp"
                    }
            }
        }
