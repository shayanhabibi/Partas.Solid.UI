namespace Partas.Solid.UI

open Partas.Solid
open Fable.Core
open Fable.Core.JS
open Fable.Core.JsInterop
open Partas.Solid.EmblaCarousel

[<StringEnum>]
type CarouselOrientation =
   | Horizontal
   | Vertical

[<Pojo>]
type CarouselContext
    (
        ?opts: EmblaCarouselOptions,
        ?plugins: Map<string,EmblaCarouselPlugin>,
        ?orientation: CarouselOrientation,
        ?setApi: (EmblaCarouselApi -> unit),
        ?carouselRef: EmblaCarouselRef,
        ?api: EmblaCarouselApi,
        ?scrollPrev: (unit -> unit),
        ?scrollNext: (unit -> unit),
        ?canScrollNext: Accessor<bool>,
        ?canScrollPrev: Accessor<bool>
    ) =
    member val opts = opts with get,set
    member val plugins = plugins with get,set
    member val orientation = orientation with get,set
    member val setApi = setApi with get,set
    member val carouselRef = carouselRef with get,set
    member val api = api with get,set
    member val scrollPrev = scrollPrev with get,set
    member val scrollNext = scrollNext with get,set
    member val canScrollNext = canScrollNext with get,set
    member val canScrollPrev = canScrollPrev with get,set

[<Erase>]
module Context =
    let CarouselContext = createContext<Accessor<CarouselContext>>()
    let useCarousel = fun () ->
        let context = useContext(CarouselContext)
        if not !!context then failwith "useCarousel must be used within a <Carousel />"
        context

[<Erase>]
type Carousel() =
    inherit div()
    [<Erase>] member val opts: EmblaCarouselOptions = unbox null with get,set
    [<Erase>] member val plugins: Map<string,EmblaCarouselPlugin> = unbox null with get,set
    [<Erase>] member val orientation: CarouselOrientation = unbox null with get,set
    [<Erase>] member val setApi: (EmblaCarouselApi -> unit) = unbox null with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.orientation <- Horizontal
        let carouselRef, api = createEmblaCarousel(
                (fun () -> props.opts),
                (fun () -> if props.plugins = undefined then [||] else !!props.plugins)
            )
        let canScrollPrev, setCanScrollPrev = createSignal(false)
        let canScrollNext, setCanScrollNext = createSignal(false)
        let onSelect = fun (_,(api: EmblaCarouselApi)) ->
            setCanScrollPrev(api.canScrollPrev())
            setCanScrollNext(api.canScrollNext())
        let scrollPrev = fun () ->
            if api() |> isNull then ()
            else api().scrollPrev()
        let scrollNext = fun () ->
            if api() |> isNull then ()
            else api().scrollNext()
        let handleKeyDown = fun (event: Browser.Types.KeyboardEvent) ->
            match event.key with
            | "ArrowLeft" ->
                event.preventDefault()
                scrollPrev()
            | "ArrowRight" ->
                event.preventDefault()
                scrollNext()
            | _ -> ()
        createEffect(fun () ->
            if (not !!(api())) || (not !!props.setApi) then ()
            else props.setApi(api())
            )
        // createEffect(fun () ->
        //     if api() |> unbox then
        //         onSelect(api())
        //         api().on(!!"reInit", onSelect)
        //         api().on(!!"select", onSelect)
        //         )
        
    
