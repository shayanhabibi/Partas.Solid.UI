[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageBadge

open Partas.Solid
open Partas.Solid.UI
open Fable.Core

[<Erase>]
type PageBadge() =
    interface VoidNode
    [<SolidTypeComponentAttribute>]
    member props.components =
        div(class' = "flex p-6 gap-8") {
            div(class' = "flex flex-col gap-4") {
                For(each = [|
                    "Default", Badge.Variant.Default
                    "Secondary", Badge.Variant.Secondary
                    "Error", Badge.Variant.Error
                    "Outline", Badge.Variant.Outline
                    "Success", Badge.Variant.Success
                    "Warning", Badge.Variant.Warning
                |]) {
                    yield fun (name, variant) index ->
                        Badge(variant = variant) { name }
                }
            }
            div(class' = "flex flex-col gap-4") {
                For(each = [|
                    badgeDelta.Unchanged, "Default", Badge.Variant.Default
                    badgeDelta.Increase, "Secondary", Badge.Variant.Secondary
                    badgeDelta.Decrease, "Error", Badge.Variant.Error
                    badgeDelta.ModerateIncrease, "Outline", Badge.Variant.Outline
                    badgeDelta.ModerateDecrease, "Success", Badge.Variant.Success
                    badgeDelta.Unchanged, "Warning", Badge.Variant.Warning
                |]) {
                    yield fun (badgeDelta, name, variant) index ->
                        BadgeDelta(deltaType = badgeDelta, variant = variant) { name }
                }
            }
            div(class' = "flex flex-col gap-4") {
                For(each = [| 
                    "No Change", badgeDelta.Unchanged
                    "Increase", badgeDelta.Increase
                    "Decrease", badgeDelta.Decrease
                    "Moderate Increase", badgeDelta.ModerateIncrease
                    "Moderate Decrease", badgeDelta.ModerateDecrease
                |]) {
                    yield fun (name, variant) index ->
                        BadgeDelta(deltaType = variant) { name }
                }
            }
            div(class' = "flex flex-col gap-4") {
                For(each = [|
                    "Default", Badge.Variant.Default
                    "Secondary", Badge.Variant.Secondary
                    "Error", Badge.Variant.Error
                    "Outline", Badge.Variant.Outline
                    "Success", Badge.Variant.Success
                    "Warning", Badge.Variant.Warning
                |]) {
                    yield fun (name, variant) index ->
                        Badge(variant = variant, round = true) { name }
                }
            }
            div(class' = "flex flex-col gap-4") {
                For(each = [|
                    badgeDelta.Unchanged, "Default", Badge.Variant.Default
                    badgeDelta.Increase, "Secondary", Badge.Variant.Secondary
                    badgeDelta.Decrease, "Error", Badge.Variant.Error
                    badgeDelta.ModerateIncrease, "Outline", Badge.Variant.Outline
                    badgeDelta.ModerateDecrease, "Success", Badge.Variant.Success
                    badgeDelta.Unchanged, "Warning", Badge.Variant.Warning
                |]) {
                    yield fun (badgeDelta, name, variant) index ->
                        BadgeDelta(deltaType = badgeDelta, variant = variant, round = true) { name }
                }
            }
            div(class' = "flex flex-col gap-4") {
                For(each = [| 
                    "No Change", badgeDelta.Unchanged
                    "Increase", badgeDelta.Increase
                    "Decrease", badgeDelta.Decrease
                    "Moderate Increase", badgeDelta.ModerateIncrease
                    "Moderate Decrease", badgeDelta.ModerateDecrease
                |]) {
                    yield fun (name, variant) index ->
                        BadgeDelta(deltaType = variant, round = true) { name }
                }
            }
        }
