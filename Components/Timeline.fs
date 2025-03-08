namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Aria
open Fable.Core

[<Erase>]
type private TimelineItemBullet() =
    inherit RegularNode()
    member val isActive: bool = unbox null with get,set
    member val bulletSize: int = unbox null with get,set
    member val lineSize: int = unbox null with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        div(
            class' = Lib.cn [|
                "absolute top-0 flex items-center justify-center rounded-full border bg-background"
                props.isActive &&= "border-primary"
                props.class'
            |],
            ariaHidden = true
        )   .style'(
            {| width = $"{props.bulletSize}px"
               height = $"{props.bulletSize}px"
               left = $"{-props.bulletSize / 2 - props.lineSize / 2}px"
               ``border-width`` = $"{props.lineSize}px" |} )
            .spread props

[<Erase>]
type private TimelineItemTitle() =
    inherit RegularNode()
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
    inherit RegularNode()
    member val title: HtmlElement = unbox null with get,set
    member val description: HtmlElement = unbox null with get,set
    member val bullet: HtmlElement = unbox null with get,set
    member val isLast: bool = unbox null with get,set
    member val isActive: bool = unbox null with get,set
    member val isActiveBullet: bool = unbox null with get,set
    member val bulletSize: int = unbox null with get,set
    member val lineSize: int = unbox null with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        li(
            class' =
                Lib.cn [| "relative border-l pb-8 pl-8"
                          props.isLast &&= "border-l-transparent pb-0"
                          props.isActive &&= not(props.isLast) &&= "border-l-primary"
                          props.class' |]
            ).style'(
                {|
                    ``border-left-width`` = $"{props.lineSize}px"  
                |}
            ).spread props
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
    [<Pojo>]
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
    inherit VoidNode()
    member val activeItem: int = unbox null with get,set
    member val bulletSize: int = unbox null with get,set
    member val lineSize: int = unbox null with get,set
    member val items: Timeline.Item[] = unbox null with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.bulletSize <- 16
        props.lineSize <- 2
        ul().style'({| ``padding-left`` = $"{props.bulletSize / 2}px" |})
            {
            For(each = props.items) {
                yield fun item index ->
                    TimelineItem(
                        title = item.title,
                        description = item.description,
                        bullet = item.bullet,
                        isLast = (index() = props.items.Length - 1),
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