namespace Partas.Solid.Sonner

open Partas.Solid
open Fable.Core
open Fable.Core.JS

module sonner =
    [<StringEnum ; RequireQualifiedAccess>]
    type [<Erase>] Type =
        | Normal
        | Action
        | Success
        | Info
        | Warning
        | Error
        | Loading
        | Default

    [<StringEnum(CaseRules.KebabCase) ; RequireQualifiedAccess>]
    type [<Erase>] Position =
        | TopLeft
        | TopRight
        | BottomLeft
        | BottomRight
        | TopCenter
        | BottomCenter

open sonner

[<Pojo>]
type ToastIcons
    (
        ?success : HtmlElement,
        ?info : HtmlElement,
        ?warning : HtmlElement,
        ?error : HtmlElement,
        ?loading : HtmlElement,
        ?close : HtmlElement
    ) =
    member val success : HtmlElement option = jsNative with get,set
    member val info : HtmlElement option = jsNative with get,set
    member val warning : HtmlElement option = jsNative with get,set
    member val error : HtmlElement option = jsNative with get,set
    member val loading : HtmlElement option = jsNative with get,set
    member val close : HtmlElement option = jsNative with get,set

[<Pojo>]
type ToastClassnames
    (
        ?toast : string,
        ?title : string,
        ?description : string,
        ?loader : string,
        ?closeButton : string,
        ?cancelButton : string,
        ?actionButton : string,
        ?success : string,
        ?error : string,
        ?info : string,
        ?warning : string,
        ?loading : string,
        ?``default`` : string,
        ?content : string,
        ?icon : string
    ) =
    member val close : string option = jsNative with get,set
    member val toast : string option = jsNative with get,set
    member val title : string option = jsNative with get,set
    member val description : string option = jsNative with get,set
    member val loader : string option = jsNative with get,set
    member val closeButton : string option = jsNative with get,set
    member val cancelButton : string option = jsNative with get,set
    member val actionButton : string option = jsNative with get,set
    member val success : string option = jsNative with get,set
    member val error : string option = jsNative with get,set
    member val info : string option = jsNative with get,set
    member val warning : string option = jsNative with get,set
    member val loading : string option = jsNative with get,set
    member val ``default`` : string option = jsNative with get,set
    member val content : string option = jsNative with get,set
    member val icon : string option = jsNative with get,set

[<Pojo>]
type Action
    (
        label : HtmlElement,
        onClick : Browser.Types.MouseEvent -> unit,
        ?actionButtonStyle : obj
    ) =
    member val label : HtmlElement = jsNative with get,set
    member val onClick : Browser.Types.MouseEvent -> unit = jsNative with get,set
    member val actionButtonStyle : obj option = jsNative with get,set
[<Pojo>]
type Toast
    (
        ?id : string,
        ?title : string,
        ?type' : Type,
        ?icon : HtmlElement,
        ?jsx : HtmlElement,
        ?richColors : bool,
        ?invert : bool,
        ?closeButton : bool,
        ?dismissible : bool,
        ?description : HtmlElement,
        ?duration : int,
        ?delete : bool,
        ?action : Action,
        ?cancel : Action,
        ?onDismiss : Toast -> unit,
        ?onAutoClose : Toast -> unit,
        // ?promise : PromiseT,
        ?cancelButtonStyle : obj,
        ?actionButtonStyle : obj,
        ?style : obj,
        ?unstyled : bool,
        ?class' : string,
        ?classes : ToastClassnames,
        ?descriptionClassName : string,
        ?position : Position
    ) =
    member val id : string option = jsNative with get, set
    member val action : Action option = jsNative with get, set
    member val cancel : Action option = jsNative with get, set
    member val title : string option = jsNative with get, set
    member val type' : Type option = jsNative with get, set
    member val icon : HtmlElement option = jsNative with get, set
    member val jsx : HtmlElement option = jsNative with get, set
    member val description : HtmlElement option = jsNative with get, set
    member val richColors : bool option = jsNative with get, set
    member val invert : bool option = jsNative with get, set
    member val closeButton : bool option = jsNative with get, set
    member val dismissible : bool option = jsNative with get, set
    member val delete : bool option = jsNative with get, set
    member val unstyled : bool option = jsNative with get, set
    member val duration : int option = jsNative with get, set
    member val onDismiss : Option<Toast -> unit> = jsNative with get, set
    member val onAutoClose : Option<Toast -> unit> = jsNative with get, set
    member val cancelButtonStyle : obj option = jsNative with get, set
    member val actionButtonStyle : obj option = jsNative with get, set
    member val style : obj option = jsNative with get, set
    member val class' : string option = jsNative with get, set
    member val descriptionClassName : string option = jsNative with get, set
    member val position : Position option = jsNative with get, set
    member val classes : ToastClassnames option = jsNative with get, set


type [<Erase>] Sonner =
    [<Import("toast","solid-sonner")>]
    static member toast ( text : string , ?data : Toast ) : string = unbox null
    [<Import("toast","solid-sonner")>]
    static member toast ( ele : HtmlElement , ?data : Toast) : string = unbox null

[<RequireQualifiedAccess>]
module [<Erase>] Sonner =
    [<Import("toast","solid-sonner")>]
    type [<Erase>] toast =
        static member success ( text : string , ?data : Toast ) : string = unbox null
        static member info ( text : string , ?data : Toast ) : string = unbox null
        static member warning ( text : string , ?data : Toast ) : string = unbox null
        static member error ( text : string , ?data : Toast ) : string = unbox null
        static member message ( text : string , ?data : Toast ) : string = unbox null
        static member loading ( text : string , ?data : Toast ) : string = unbox null
        static member dismiss ( id : string ) : unit = unbox null
        static member dismiss ( id : int ) : unit = unbox null
        static member dismiss () : unit = unbox null

[<Import("Toaster","solid-sonner")>]
type Toaster() =
    inherit div()
    member val invert: bool = unbox null with get,set
    member val hotkey: string[] = unbox null with get,set
    member val richColors: bool = unbox null with get,set
    member val expand: bool = unbox null with get,set
    member val duration: int = unbox null with get,set
    member val gap: int = unbox null with get,set
    member val visibleToasts: int = unbox null with get,set
    member val closeButton: bool = unbox null with get,set
    member val toastOptions: Toast = unbox null with get,set
    member val offset: int = unbox null with get,set
    member val icons: ToastIcons = unbox null with get,set
    member val containerAriaLabel: string = unbox null with get,set
    member val pauseWhenPageIsHidden: bool = unbox null with get,set
    member val cn: string list -> string = unbox null with get,set
    