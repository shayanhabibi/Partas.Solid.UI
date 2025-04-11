namespace Partas.Solid.UI

open Fable.Core
open Partas.Solid

type [<Erase>] Lib =
    [<Import("twMerge","tailwind-merge")>]
    static member inline twMerge ( classes : string ) : string = jsNative
    [<Import("clsx","clsx")>]
    static member inline clsx ( classes : obj ) : string = jsNative
    static member inline cn ( classes : string * bool ) : string = classes |> Lib.clsx |> Lib.twMerge
    static member inline cn ( classes : string array ) : string = classes |> Lib.clsx |> Lib.twMerge
    static member inline cn ( classes : string ) : string = classes |> Lib.clsx |> Lib.twMerge
    [<Import("cva","class-variance-authority")>]
    static member inline cva ( orig : string ) ( object : 'T) : obj -> string = jsNative
    [<Import("children", "solid-js")>]
    static member inline children(value: unit -> #HtmlElement): #HtmlElement Accessor = jsNative
    static member inline createChildrenResolver(children: #HtmlElement): Accessor<#HtmlElement> * Accessor<bool> =
        let resolvedChildren = Lib.children(fun () -> children)
        let hasChildren =
            fun () ->
                resolvedChildren
                |> JS.Constructors.Array.from
                |> _.Length
                |> (<>) 0
        resolvedChildren, hasChildren
    static member inline nbsp = "\u00A0"
    
[<AutoOpen; Erase>]
module Operators =
    [<Emit("$0 && $1")>]
    let (&&=) (conditional: 'T) (output: 'M): 'M = jsNative


[<Erase>]
type SrSpan() =
    inherit span()
    [<SolidTypeComponent>]
    member props.span =
        span(class' = Lib.cn [|"sr-only"; props.class'|]).spread props

[<Erase>]
module Context =
    [<Erase>]
    let private noop = ()