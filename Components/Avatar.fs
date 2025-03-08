namespace Partas.Solid.UI
open Partas.Solid
open Partas.Solid.Kobalte
open Fable.Core

[<Erase>]
type Avatar() =
    inherit Kobalte.Image()
    [<SolidTypeComponent>]
    member props.constructor =
        Kobalte.Image(class' = Lib.cn [|
            "relative flex size-10 shrink-0 overflow-hidden rounded-full"
            props.class'
        |]).spread props

[<Erase>]
type AvatarImage() =
    inherit Image.Img()
    [<SolidTypeComponent>]
    member props.constructor =
        Image.Img(class' = Lib.cn [|
            "aspect-square size-full"
            props.class'
        |]).spread props
        
[<Erase>]
type AvatarFallback() =
    inherit Image.Fallback()
    [<SolidTypeComponent>]
    member props.constructor =
        Image.Fallback(class' = Lib.cn [|
            "flex size-full items-center justify-center bg-muted"
            props.class'
        |]).spread props
