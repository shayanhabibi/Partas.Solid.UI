namespace Partas.Solid.UI

open Fable.Core

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

[<AutoOpen; Erase>]
module Operators =
    [<Emit("$0 && $1")>]
    let (&&=) (conditional: 'T) (output: 'M): 'M = jsNative

open Partas.Solid

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