[<AutoOpen>]
module Partas.Solid.UI.Playground.Components.PageBadge

open Partas.Solid
open Partas.Solid.UI
open Fable.Core

[<Erase>]
type PageBadge() =
    inherit VoidNode()
    [<SolidTypeComponentAttribute>]
    member props.components =
        div(class' = "flex p-6 gap-8") {
            div(class' = "flex flex-col gap-4") {
                For(each = [|
                    "Default", badge.variant.Default
                    "Secondary", badge.variant.Secondary
                    "Error", badge.variant.Error
                    "Outline", badge.variant.Outline
                    "Success", badge.variant.Success
                    "Warning", badge.variant.Warning
                |]) {
                    yield fun (name, variant) index ->
                        Badge(variant = variant) { name }
                }
            }
            div(class' = "flex flex-col gap-4") {
                For(each = [|
                    badgeDelta.Unchanged, "Default", badge.variant.Default
                    badgeDelta.Increase, "Secondary", badge.variant.Secondary
                    badgeDelta.Decrease, "Error", badge.variant.Error
                    badgeDelta.ModerateIncrease, "Outline", badge.variant.Outline
                    badgeDelta.ModerateDecrease, "Success", badge.variant.Success
                    badgeDelta.Unchanged, "Warning", badge.variant.Warning
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
                    "Default", badge.variant.Default
                    "Secondary", badge.variant.Secondary
                    "Error", badge.variant.Error
                    "Outline", badge.variant.Outline
                    "Success", badge.variant.Success
                    "Warning", badge.variant.Warning
                |]) {
                    yield fun (name, variant) index ->
                        Badge(variant = variant, round = true) { name }
                }
            }
            div(class' = "flex flex-col gap-4") {
                For(each = [|
                    badgeDelta.Unchanged, "Default", badge.variant.Default
                    badgeDelta.Increase, "Secondary", badge.variant.Secondary
                    badgeDelta.Decrease, "Error", badge.variant.Error
                    badgeDelta.ModerateIncrease, "Outline", badge.variant.Outline
                    badgeDelta.ModerateDecrease, "Success", badge.variant.Success
                    badgeDelta.Unchanged, "Warning", badge.variant.Warning
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
