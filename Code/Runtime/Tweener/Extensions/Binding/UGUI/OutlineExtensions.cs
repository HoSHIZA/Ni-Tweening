using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace NiGames.Tweening
{
    public static class OutlineExtensions
    {
        #region Effect Color
        
        /// <summary>
        /// Bind to <c>Outline.effectColor</c>.
        /// </summary>
        public static NiTweenHandle BindToOutlineColor<TOptions, TAdapter>(this NiTweenBuilder<Color, TOptions, TAdapter> builder,
            [NotNull] Outline outline) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Color, TOptions>
        {
            Error.IsNull(outline);

            return builder.BindWithState(outline, static (v, target) =>
            {
                target.effectColor = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>Outline.effectColor.r</c>.
        /// </summary>
        public static NiTweenHandle BindToOutlineColorR<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Outline outline) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(outline);

            return builder.BindWithState(outline, static (v, target) =>
            {
                var cache = target.effectColor;
                cache.r = v;
                target.effectColor = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Outline.effectColor.g</c>.
        /// </summary>
        public static NiTweenHandle BindToOutlineColorG<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Outline outline) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(outline);

            return builder.BindWithState(outline, static (v, target) =>
            {
                var cache = target.effectColor;
                cache.g = v;
                target.effectColor = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Outline.effectColor.b</c>.
        /// </summary>
        public static NiTweenHandle BindToOutlineColorB<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Outline outline) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(outline);

            return builder.BindWithState(outline, static (v, target) =>
            {
                var cache = target.effectColor;
                cache.b = v;
                target.effectColor = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Outline.effectColor.a</c>.
        /// </summary>
        public static NiTweenHandle BindToOutlineColorAlpha<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Outline outline) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(outline);

            return builder.BindWithState(outline, static (v, target) =>
            {
                var cache = target.effectColor;
                cache.a = v;
                target.effectColor = cache;
            });
        }
        
        #endregion
        
        #region Effect Distance
        
        /// <summary>
        /// Bind to <c>Outline.effectDistance</c>.
        /// </summary>
        public static NiTweenHandle BindToOutlineDistance<TOptions, TAdapter>(this NiTweenBuilder<Vector2, TOptions, TAdapter> builder,
            [NotNull] Outline outline) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Vector2, TOptions>
        {
            Error.IsNull(outline);

            return builder.BindWithState(outline, static (v, target) =>
            {
                target.effectDistance = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>Outline.effectDistance.x</c>.
        /// </summary>
        public static NiTweenHandle BindToOutlineDistanceX<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Outline outline) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(outline);

            return builder.BindWithState(outline, static (v, target) =>
            {
                var cache = target.effectDistance;
                cache.x = v;
                target.effectDistance = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Outline.effectDistance.y</c>.
        /// </summary>
        public static NiTweenHandle BindToOutlineDistanceY<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Outline outline) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(outline);

            return builder.BindWithState(outline, static (v, target) =>
            {
                var cache = target.effectDistance;
                cache.y = v;
                target.effectDistance = cache;
            });
        }
        
        #endregion
    }
}
