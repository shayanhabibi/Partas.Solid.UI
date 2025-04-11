[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageTextEffects

open Partas.Solid
open Partas.Solid.UI
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type PageTextEffects() =
    inherit VoidNode()
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        let textClass = "text-4xl md:text-6xl font-bold"
        div(
            class' = "w-full flex flex-col gap-8 items-center justify-center"
        ) {
            div(class' = "w-full flex items-center justify-center p-12 overflow-hidden py-2") {
                WordRotate(class' = textClass, words = [| "Word" ; "Rotate" |])
            }
            
            WordPullup(text = "Pullup Words", class' = textClass)
            
            FlipText(text = "Flip Text", class' = textClass)
            
            GradualSpacing(text = "Gradual Spacing", class' = textClass)
            
            p(class' = textClass) {
                "Partas"
                SparklesText() { ".Solid." }
                "UI"
                
            }
            
            WordFadeIn(text = "Word Fade In", class' = textClass)
            
            // ShineBorder(
            //     class' = "relative flex h-(500px) w-full items-center justify-center overflow-hidden rounded-lg shadow-lg",
            //     color = !![| "#A07CFE"; "#FE8FB5"; "#FFBE7B" |]
            // ) {span(class' = textClass) { "Shine Border" }}
        }
