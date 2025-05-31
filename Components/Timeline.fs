namespace Partas.Solid.UI

open System
open Partas.Solid
open Partas.Solid.Style
open Partas.Solid.Aria
open Fable.Core

[<Erase>]
type private TimelineItemBullet() =
    interface RegularNode
    [<Erase>]
    member val isActive: bool = unbox null with get,set
    [<Erase>]
    member val bulletSize: int = unbox null with get,set
    [<Erase>]
    member val lineSize: int = unbox null with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        let bulletSize () = props.bulletSize
        let lineSize () = props.lineSize
        div(
            class' = Lib.cn [|
                "absolute top-0 flex items-center justify-center rounded-full border bg-background"
                props.isActive &&= "border-primary"
                props.class'
            |],
            ariaHidden = true
        )   .style'([
            Style.width $"{bulletSize()}px"
            Style.height $"{bulletSize()}px"
            Style.left $"{-bulletSize() / 2 - lineSize() / 2}px"
            "border-width", $"{lineSize()}px"
        ])  .spread props

[<Erase>]
type private TimelineItemTitle() =
    interface RegularNode
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(class' = "mb-1 text-base font-semibold leading-none") { props.children }

[<Erase>]
type private TimelineItemDescription() =
    inherit p()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        p(class' = Lib.cn [| "text-sm text-muted-foreground" ; props.class' |])
            .spread props
            { props.children }

[<Erase>]
type private TimelineItem() =
    interface RegularNode
    [<Erase>]
    member val title: HtmlElement = unbox null with get,set
    [<Erase>]
    member val description: HtmlElement = unbox null with get,set
    [<Erase>]
    member val bullet: HtmlElement = unbox null with get,set
    [<Erase>]
    member val isLast: bool = unbox null with get,set
    [<Erase>]
    member val isActive: bool = unbox null with get,set
    [<Erase>]
    member val isActiveBullet: bool = unbox null with get,set
    [<Erase>]
    member val bulletSize: int = unbox null with get,set
    [<Erase>]
    member val lineSize: int = unbox null with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        let lineSize = props.lineSize
        li(
            class' =
                Lib.cn [| "relative border-l pb-8 pl-8"
                          props.isLast &&= "border-l-transparent pb-0"
                          props.isActive &&= not(props.isLast) &&= "border-l-primary"
                          props.class' |]
            ).style'([Style.borderLeftWidth $"{lineSize}px"]).spread props
            {
                TimelineItemBullet(
                        lineSize = props.lineSize,
                        bulletSize = props.bulletSize,
                        isActive = props.isActiveBullet
                    ) { props.bullet }
                TimelineItemTitle()
                    { props.title }
                if unbox props.description then
                    TimelineItemDescription() { props.description }
                else ()
            }

open Fable.Core.JS

[<Erase>]
module Timeline =
    [<Pojo; Global>]
    type Item
        (
            title: HtmlElement,
            ?description: HtmlElement,
            ?bullet: HtmlElement,
            ?class': string,
            ?bulletSize: int
        ) =
        member val title: HtmlElement = unbox null with get,set
        member val description: HtmlElement = unbox null with get,set
        member val bullet: HtmlElement = unbox null with get,set
        member val class': string = unbox null with get,set
        member val bulletSize: int = unbox null with get,set

[<Erase>]
type Timeline() =
    interface VoidNode
    [<Erase>]
    member val activeItem: int = unbox null with get,set
    [<Erase>]
    member val bulletSize: int = unbox null with get,set
    [<Erase>]
    member val lineSize: int = unbox null with get,set
    [<Erase>]
    member val items: Timeline.Item[] = unbox null with get,set
    static member calcPadding num =
        num / 2
        |> fun x -> $"{x}px"
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.bulletSize <- 16
        props.lineSize <- 2
        let checkIsLast (index: Accessor<int>) =
            let length =
                props.items
                |> _.Length
            length - 1
            |> (=) (index())
        ul().style'([Style.paddingLeft (Timeline.calcPadding props.bulletSize)])
            {
            For(each = props.items) {
                yield fun item index ->
                    TimelineItem(
                        title = item.title,
                        description = item.description,
                        bullet = item.bullet,
                        isLast = (checkIsLast index),
                        isActive =
                            if props.activeItem = -1 then false
                            else props.activeItem >= index() + 1
                        ,isActiveBullet =
                            if props.activeItem = -1 then false
                            else props.activeItem >= index()
                        ,bulletSize = props.bulletSize,
                        lineSize = props.lineSize
                    )
            }
        }
