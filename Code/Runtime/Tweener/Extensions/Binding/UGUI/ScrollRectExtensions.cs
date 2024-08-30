using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace NiGames.Tweening
{
    public static class ScrollRectExtensions
    {
        /// <summary>
        /// Bind to <c>ScrollRect.normalizedPosition</c>.
        /// </summary>
        public static NiTweenHandle BindToNormalizedPosition<TOptions, TAdapter>(this NiTweenBuilder<Vector2, TOptions, TAdapter> builder,
            [NotNull] ScrollRect scrollRect) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Vector2, TOptions>
        {
            Error.IsNull(scrollRect);

            return builder.BindWithState(scrollRect, static (v, target) =>
            {
                target.normalizedPosition = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>ScrollRect.horizontalNormalizedPosition</c>.
        /// </summary>
        public static NiTweenHandle BindToNormalizedPositionHorizontal<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] ScrollRect scrollRect) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(scrollRect);

            return builder.BindWithState(scrollRect, static (v, target) =>
            {
                target.horizontalNormalizedPosition = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>ScrollRect.verticalNormalizedPosition</c>.
        /// </summary>
        public static NiTweenHandle BindToNormalizedPositionVertical<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] ScrollRect scrollRect) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(scrollRect);

            return builder.BindWithState(scrollRect, static (v, target) =>
            {
                target.verticalNormalizedPosition = v;
            });
        }
    }
}