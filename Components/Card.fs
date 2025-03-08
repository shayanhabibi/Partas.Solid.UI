namespace Partas.Solid.UI

open Partas.Solid
open Fable.Core

[<Erase>]
type Card() =
    inherit div()
    [<SolidTypeComponent>]
    member props.card =
        div(
            class' = Lib.cn [|
                "rounded-lg border bg-card text-card-foreground shadow-sm"
                props.class'
            |]
            ).spread props

[<Erase>]
type CardHeader() =
    inherit div()
    [<SolidTypeComponent>]
    member props.card =
        div(class'=Lib.cn [| "flex flex-col space-y-1.5 p-6"; props.class' |]).spread(props)
    
[<Erase>]
type CardTitle() =
    inherit h3()
    [<SolidTypeComponent>]
    member props.card =
        h3(class'= Lib.cn [|"text-lg font-semibold leading-none tracking-tight"; props.class' |]).spread(props)
[<Erase>]
type CardDescription() =
    inherit p()
    [<SolidTypeComponent>]
    member props.card =
        p(class'= Lib.cn [| "text-sm text-muted-foreground"; props.class'  |]).spread(props)
[<Erase>]
type CardContent() =
    inherit div()
    [<SolidTypeComponent>]
    member props.card =
        div(class' = Lib.cn [|"p-6 pt-0"; props.class' |]).spread(props)
[<Erase>]
type CardFooter() =
    inherit div()
    [<SolidTypeComponent>]
    member props.card =
        div(class'= Lib.cn [| "flex items-center p-6 pt-0"; props.class'  |]).spread(props)