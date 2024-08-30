using JetBrains.Annotations;
using UnityEngine;

namespace NiGames.Tweening
{
    public static class RectTransformExtensions
    {
        /// <summary>
        /// Bind to <c>RectTransform.anchoredPosition</c>.
        /// </summary>
        public static NiTweenHandle BindToAnchoredPosition<TOptions, TAdapter>(this NiTweenBuilder<Vector2, TOptions, TAdapter> builder,
            [NotNull] RectTransform rt)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Vector2, TOptions>
        {
            Error.IsNull(rt);
            
            return builder.BindWithState(rt, static (v, target) =>
            {
                target.anchoredPosition = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>RectTransform.anchoredPosition.x</c>.
        /// </summary>
        public static NiTweenHandle BindToAnchoredPositionX<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] RectTransform rt)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(rt);

            return builder.BindWithState(rt, static (v, target) =>
            {
                var cache = target.anchoredPosition;
                cache.x = v;
                target.anchoredPosition = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>RectTransform.anchoredPosition.y</c>.
        /// </summary>
        public static NiTweenHandle BindToAnchoredPositionY<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] RectTransform rt)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(rt);

            return builder.BindWithState(rt, static (v, target) =>
            {
                var cache = target.anchoredPosition;
                cache.y = v;
                target.anchoredPosition = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>RectTransform.sizeDelta</c>.
        /// </summary>
        public static NiTweenHandle BindToSizeDelta<TOptions, TAdapter>(this NiTweenBuilder<Vector2, TOptions, TAdapter> builder,
            [NotNull] RectTransform rt)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Vector2, TOptions>
        {
            Error.IsNull(rt);

            return builder.BindWithState(rt, static (v, target) =>
            {
                target.sizeDelta = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>RectTransform.sizeDelta.x</c>.
        /// </summary>
        public static NiTweenHandle BindToSizeDeltaX<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] RectTransform rt)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(rt);

            return builder.BindWithState(rt, static (v, target) =>
            {
                var cache = target.sizeDelta;
                cache.x = v;
                target.sizeDelta = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>RectTransform.sizeDelta.y</c>.
        /// </summary>
        public static NiTweenHandle BindToSizeDeltaY<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] RectTransform rt)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(rt);

            return builder.BindWithState(rt, static (v, target) =>
            {
                var cache = target.sizeDelta;
                cache.y = v;
                target.sizeDelta = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>RectTransform.anchorMin</c>.
        /// </summary>
        public static NiTweenHandle BindToAnchorMin<TOptions, TAdapter>(this NiTweenBuilder<Vector2, TOptions, TAdapter> builder,
            [NotNull] RectTransform rt)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Vector2, TOptions>
        {
            Error.IsNull(rt);

            return builder.BindWithState(rt, static (v, target) =>
            {
                target.anchorMin = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>RectTransform.anchorMax</c>.
        /// </summary>
        public static NiTweenHandle BindToAnchorMax<TOptions, TAdapter>(this NiTweenBuilder<Vector2, TOptions, TAdapter> builder,
            [NotNull] RectTransform rt)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Vector2, TOptions>
        {
            Error.IsNull(rt);
            
            return builder.BindWithState(rt, static (v, target) =>
            {
                target.anchorMax = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>RectTransform.pivot</c>.
        /// </summary>
        public static NiTweenHandle BindToPivot<TOptions, TAdapter>(this NiTweenBuilder<Vector2, TOptions, TAdapter> builder,
            [NotNull] RectTransform rt)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Vector2, TOptions>
        {
            Error.IsNull(rt);
            
            return builder.BindWithState(rt, static (v, target) =>
            {
                target.pivot = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>RectTransform.pivot.x</c>.
        /// </summary>
        public static NiTweenHandle BindToPivotX<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] RectTransform rt)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(rt);
            
            return builder.BindWithState(rt, static (v, target) =>
            {
                var cache = target.pivot;
                cache.x = v;
                target.pivot = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>RectTransform.pivot.y</c>.
        /// </summary>
        public static NiTweenHandle BindToPivotY<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] RectTransform rt)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(rt);
            
            return builder.BindWithState(rt, static (v, target) =>
            {
                var cache = target.pivot;
                cache.y = v;
                target.pivot = cache;
            });
        }
    }
}