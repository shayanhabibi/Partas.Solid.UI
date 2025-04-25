namespace Partas.Solid.UI

open Partas.Solid
open Partas.Solid.Sonner
open Fable.Core

[<Erase>]
type Sonner() =
    inherit Sonner.Toaster()
    [<SolidTypeComponent>]
    member props.constructor =
        Sonner.Toaster(
            class' = "toaster group",
            toastOptions = Toast(
                classes = ToastClassnames(
                    toast = "group toast group-[.toaster]:bg-background group-[.toaster]:text-foreground group-[.toaster]:border-border group-[.toaster]:shadow-lg",
                    description = "group-[.toast]:text-muted-foreground",
                    actionButton = "group-[.toast]:bg-primary group-[.toast]:text-primary-foreground",
                    cancelButton = "group-[.toast]:bg-muted group-[.toast]:text-muted-foreground"
                    )
            )
        )   .spread props