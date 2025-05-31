[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageEffects

open Partas.Solid
open Partas.Solid.Lucide
open Partas.Solid.UI
open Fable.Core
open Fable.Core.JsInterop
open Partas.Solid.Experimental
open Partas.Solid.Experimental.U
open Browser.Types

[<Erase>]
type Circle() =
    interface RegularNode
    [<Erase>]
    member val ref': Element = JS.undefined with get,set
    [<SolidTypeComponentAttribute>]
    member props.__ =
        div(
            class' = Lib.cn [|
                "z-10 flex size-12 items-center justify-center rounded-full border-2 bg-white p-3 shadow-[0_0_20px_-12px_rgba(0,0,0,0.8)]"
                props.class'
            |]
            ).ref(props.ref').spread props

[<Erase>]
type PageEffects() =
    interface VoidNode
    [<SolidTypeComponentAttribute>]
    member props.__ =
        let mutable containerRef: HTMLDivElement = null
        let mutable div1Ref: HTMLDivElement = null
        let mutable div2Ref: HTMLDivElement = null
        let mutable div3Ref: HTMLDivElement = null
        let mutable div4Ref: HTMLDivElement = null
        let mutable div5Ref: HTMLDivElement = null
        let mutable div6Ref: HTMLDivElement = null
        let mutable div7Ref: HTMLDivElement = null
        div(class' = "relative w-full mx-auto max-w-sm my-6").ref(containerRef) {
            div(class' = "flex size-full flex-col max-w-lg max-h-[200px]
                    items-stretch justify-between gap-10") {
                div(class' = "flex flex-row items-center justify-between" ) {
                    Circle(ref' = div1Ref) {
                        Lucide.Goal()
                    }
                    Circle(ref' = div5Ref) {
                        Lucide.Cuboid()
                    }
                }
                div(class' = "flex flex-row items-center justify-between" ) {
                    Circle(ref' = div2Ref) {
                        Lucide.Goal()
                    }
                    Circle(ref' = div4Ref) {
                        Lucide.Cuboid(size = 24)
                    }
                    Circle(ref' = div6Ref) {
                        Lucide.Cuboid()
                    }
                }
                div(class' = "flex flex-row items-center justify-between" ) {
                    Circle(ref' = div3Ref) {
                        Lucide.Goal()
                    }
                    Circle(ref' = div7Ref) {
                        Lucide.Cuboid()
                    }
                }
            }
            AnimatedBeam(
                containerRef = containerRef
                ,fromRef = div1Ref
                ,toRef = div4Ref
                ,curvature = -75 
                ,endYOffset = -10
                )
            AnimatedBeam(
                containerRef = containerRef
                ,fromRef = div2Ref
                ,toRef = div4Ref
                )
            AnimatedBeam(
                containerRef = containerRef
                ,fromRef = div3Ref
                ,toRef = div4Ref
                ,curvature = 75
                ,endYOffset = 10
                )
            AnimatedBeam(
                containerRef = containerRef
                ,fromRef = div5Ref
                ,toRef = div4Ref
                ,curvature = -75
                ,endYOffset = -10
                )
            AnimatedBeam(
                containerRef = containerRef
                ,fromRef = div6Ref
                ,toRef = div4Ref
                )
            AnimatedBeam(
                containerRef = containerRef
                ,fromRef = div7Ref
                ,toRef = div4Ref
                ,curvature = 75
                ,endYOffset = 10
                )
        }
