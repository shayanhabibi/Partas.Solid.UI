namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Motion
open Partas.Solid.Aria
open Fable.Core
open Fable.Core.JS
open Fable.Core.JsInterop

[<Pojo>]
type SparkleOptions
    (
        color: string,
        delay: float,
        id: string,
        lifespan: float,
        scale: float,
        x: string,
        y: string
    ) =
    member val color: string = unbox null with get,set
    member val delay: float = unbox null with get,set
    member val id: string = unbox null with get,set
    member val lifespan: float = unbox null with get,set
    member val scale: float = unbox null with get,set
    member val x: string = unbox null with get,set
    member val y: string = unbox null with get,set

[<Erase>]
type Sparkle() =
    inherit VoidNode()
    [<Erase>] member val color: string = unbox null with get,set
    [<Erase>] member val delay: float = unbox null with get,set
    [<Erase>] member val id: string = unbox null with get,set
    [<Erase>] member val lifespan: float = unbox null with get,set
    [<Erase>] member val scale: float = unbox null with get,set
    [<Erase>] member val x: string = unbox null with get,set
    [<Erase>] member val y: string = unbox null with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        Motion(
            tag = "svg",
            class' = "pointer-events-none absolute z-20",
            ariaHidden = true,
            initial = motionStyle [
                MotionStyle.opacity "0"
            ],
            animate = motionStyle [
                MotionStyle.opacity !![|0;1;0|]
                MotionStyle.scale !![|0; !!props.scale; 0|]
                MotionStyle.rotate !![|75;120;150|]
            ],
            transition = jsOptions<AnimationOptions>(fun o ->
                o.duration <- !!1.2
                o.repeat <- !!Constructors.Number.MAX_SAFE_INTEGER
                o.delay <- !!props.delay
                )
        )   .style'([Style.Style.left props.x; Style.Style.top props.y])
            .attr("width", "21")
            .attr("height", "21")
            .attr("viewBox", "0 0 21 21")
            {
            Svg.path(
                d = "M9.82531 0.843845C10.0553 0.215178 10.9446 0.215178 11.1746 0.843845L11.8618 2.72026C12.4006 4.19229 12.3916 6.39157 13.5 7.5C14.6084 8.60843 16.8077 8.59935 18.2797 9.13822L20.1561 9.82534C20.7858 10.0553 20.7858 10.9447 20.1561 11.1747L18.2797 11.8618C16.8077 12.4007 14.6084 12.3916 13.5 13.5C12.3916 14.6084 12.4006 16.8077 11.8618 18.2798L11.1746 20.1562C10.9446 20.7858 10.0553 20.7858 9.82531 20.1562L9.13819 18.2798C8.59932 16.8077 8.60843 14.6084 7.5 13.5C6.39157 12.3916 4.19225 12.4007 2.72023 11.8618L0.843814 11.1747C0.215148 10.9447 0.215148 10.0553 0.843814 9.82534L2.72023 9.13822C4.19225 8.59935 6.39157 8.60843 7.5 7.5C8.60843 6.39157 8.59932 4.19229 9.13819 2.72026L9.82531 0.843845Z"
                ).attr("fill", props.color)
        }

[<Erase>]
type SparklesText() =
    inherit RegularNode()
    [<Erase>] member val colors: string[] = unbox null with get,set
    [<Erase>] member val sparklesCount: int = unbox null with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.colors <- [|
            "#9E7AFF"
            "#FE8BBB"
        |]
        props.sparklesCount <- 10
        let sparkles,setSparkles = createSignal<SparkleOptions[]>([||])
        onMount( fun () ->
            let generateStar: unit -> SparkleOptions = fun () ->
                let genPos () = $"{Math.random() * 100.}%%"
                let starX, starY = genPos(), genPos()
                let color = props.colors[!!Math.floor(Math.random() * !!props.colors.Length)]
                let delay = Math.random() * 2.
                let scale = Math.random() * 1. + !!0.3
                let lifespan = Math.random() * 10.
                let id = $"{starX}-{starY}-{Constructors.Date.now()}"
                SparkleOptions(
                    color = color,
                    delay = delay,
                    scale = scale,
                    lifespan = lifespan,
                    id = id,
                    x = starX,
                    y = starY
                    )
            let initializeStars = fun () ->
                let newSparkles = Constructors.Array.Create(props.sparklesCount) |> FSharp.Collections.Array.map( fun () -> generateStar() )
                setSparkles(newSparkles)
            let updateStars = fun () ->
                setSparkles.Invoke(
                    FSharp.Collections.Array.map (fun (star: SparkleOptions) ->
                        if star.lifespan <= 0 then generateStar()
                        else
                            star.lifespan <- star.lifespan - 0.1
                            star)
                )
            initializeStars ()
            let interval = setInterval updateStars 100
            onCleanup(fun () -> clearInterval(interval))
        )
        span(
            class' = Lib.cn [|
                "relative inline-block"
                props.class'
            |]
        ).spread props {
            Index(each = sparkles()) {
                yield fun sparkle index ->
                    Sparkle().spread sparkle
            }
            props.children
        }
