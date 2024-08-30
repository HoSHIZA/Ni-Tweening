using JetBrains.Annotations;
using UnityEngine;

namespace NiGames.Tweening.Rendering
{
    public static class LineRendererExtensions
    {
        /// <summary>
        /// Bind to <c>LineRenderer.startWidth</c>.
        /// </summary>
        public static NiTweenHandle BindToStartWidth<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] LineRenderer renderer) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(renderer);

            return builder.BindWithState(renderer, static (v, target) =>
            {
                target.startWidth = v;
            });
        }

        /// <summary>
        /// Bind to <c>LineRenderer.endWidth</c>.
        /// </summary>
        public static NiTweenHandle BindToEndWidth<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] LineRenderer renderer) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(renderer);

            return builder.BindWithState(renderer, static (v, target) =>
            {
                target.endWidth = v;
            });
        }
    }
}