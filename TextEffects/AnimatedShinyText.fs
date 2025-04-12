namespace Partas.Solid.UI

open Fable.Core
open Partas.Solid


/// <summary>
/// To use this component, make sure you extend your css with the appropriate attributes:
/// <code>
/// @theme inline {
///     --animate-shiny-text: shiny-text 8s infinite;
///     @keyframes shiny-text {
///         0%, 90%, 100% {
///             background-position: calc(-100% - var(--shiny-width)) 0;
///         }
///         30%, 60% {
///             background-position: calc(100% + var(--shiny-width)) 0;
///         }
///     }
/// }
/// </code>
/// </summary>
[<Erase>]
type AnimatedShinyText() =
    inherit p()
    [<Erase>] member val shimmerWidth: int = unbox null with get,set
    [<SolidTypeComponentAttribute>]
    member props.constructor =
        props.shimmerWidth <- 100
        p(
            class' = Lib.cn [|
                "mx-auto max-w-md text-neutral-600/70 dark:text-neutral-400/70"
                // Shine effect
                "animate-shiny-text bg-clip-text bg-no-repeat [background-position:0_0] [background-size:var(--shiny-width)_100%] [transition:background-position_1s_cubic-bezier(.6,.6,0,1)_infinite]"
                // Shine gradient
                "bg-gradient-to-r from-transparent via-black/80 via-50% to-transparent  dark:via-white/80"
                props.class'
            |]
        )   .style'({|
            ``--shiny-width`` = $"{props.shimmerWidth}px"
            |})
            .spread props