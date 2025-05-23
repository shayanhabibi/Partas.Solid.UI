namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Motion
open Fable.Core
open Fable.Core.JS
open Fable.Core.JsInterop
open System

[<Pojo>]
type GradualSpacingStates(?hidden: MotionStyle, ?visible: MotionStyle) =
    member val hidden = hidden.Value with get,set
    member val visible = visible.Value with get,set
    
    

[<Erase>]
type GradualSpacing() =
    inherit VoidNode()
    [<Erase>] member val text: string = unbox null with get,set
    [<Erase>] member val duration: float = unbox null with get,set
    [<Erase>] member val delayMultiple: float = unbox null with get,set
    [<Erase>] member val states: GradualSpacingStates = unbox null with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.duration <- 0.5
        props.delayMultiple <- 0.04
        props.states <- GradualSpacingStates(
                hidden = motionStyle [
                    MotionStyle.opacity "0"
                    MotionStyle.x -20
                ],
                visible = motionStyle [
                    MotionStyle.opacity "1"
                    MotionStyle.x 0
                ]
            )
        div(class' = Lib.cn [| "flex"; props.class' |]) {
            For(each = (props.text.ToCharArray() |> Array.map string)) {
                yield fun letter index ->
                    Motion(
                        initial = props.states.hidden,
                        inView = props.states.visible,
                        exit = props.states.hidden,
                        transition = jsOptions<AnimationOptions>(fun o ->
                            o.duration <- Some props.duration
                            o.delay <-  Some (!!index() * !!props.delayMultiple))
                    ) {
                        if letter = " " then "\u00A0" else letter
                    }
            }
        }
