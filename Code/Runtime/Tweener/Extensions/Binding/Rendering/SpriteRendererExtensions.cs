using JetBrains.Annotations;
using NiGames.Tweening.Utility;
using UnityEngine;

namespace NiGames.Tweening
{
    public static class SpriteRendererExtensions
    {
        #region Color

        /// <summary>
        /// Bind to <c>SpriteRenderer.color</c>.
        /// </summary>
        public static NiTweenHandle BindToColor<TOptions, TAdapter>(this NiTweenBuilder<Color, TOptions, TAdapter> builder,
            [NotNull] SpriteRenderer renderer) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Color, TOptions>
        {
            Error.IsNull(renderer);

            return builder.BindWithState(renderer, static (v, target) =>
            {
                target.color = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>SpriteRenderer.color.r</c>.
        /// </summary>
        public static NiTweenHandle BindToColorR<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] SpriteRenderer renderer) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(renderer);

            return builder.BindWithState(renderer, static (v, target) =>
            {
                var cache = target.color;
                cache.r = v;
                target.color = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>SpriteRenderer.color.g</c>.
        /// </summary>
        public static NiTweenHandle BindToColorG<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] SpriteRenderer renderer) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(renderer);

            return builder.BindWithState(renderer, static (v, target) =>
            {
                var cache = target.color;
                cache.g = v;
                target.color = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>SpriteRenderer.color.b</c>.
        /// </summary>
        public static NiTweenHandle BindToColorB<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] SpriteRenderer renderer) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(renderer);

            return builder.BindWithState(renderer, static (v, target) =>
            {
                var cache = target.color;
                cache.b = v;
                target.color = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>SpriteRenderer.color.a</c>.
        /// </summary>
        public static NiTweenHandle BindToAlpha<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] SpriteRenderer renderer) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(renderer);

            return builder.BindWithState(renderer, static (v, target) =>
            {
                var cache = target.color;
                cache.a = v;
                target.color = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>SpriteRenderer.color</c>. Works with HUE, takes values from <c>0f</c> to <c>1f</c>.
        /// If the value is above the range, the color continues from 0.
        /// </summary>
        /// <remarks>
        /// Automatically sets <c>Saturation</c> and <c>Brightness</c> to 1.
        /// </remarks>
        public static NiTweenHandle BindToColorRainbow01<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] SpriteRenderer renderer) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(renderer);

            return builder.BindWithState(renderer, static (v, target) =>
            {
                target.color = Color.HSVToRGB(v % 1f, 1f, 1f);
            });
        }
        
        /// <summary>
        /// Bind to <c>SpriteRenderer.color</c>. Works with HUE, takes values from <c>0f</c> to <c>360f</c>.
        /// If the value is above the range, the color continues from 0.
        /// </summary>
        /// <remarks>
        /// Automatically sets <c>Saturation</c> and <c>Brightness</c> to 1.
        /// </remarks>
        public static NiTweenHandle BindToColorRainbow360<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] SpriteRenderer renderer) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(renderer);

            return builder.BindWithState(renderer, static (v, target) =>
            {
                target.color = Color.HSVToRGB(v % 360f / 360f, 1f, 1f);
            });
        }
        
        /// <summary>
        /// Bind to <c>SpriteRenderer.color</c>. Works with HUE.
        /// </summary>
        /// <remarks>
        /// Automatically sets <c>Saturation</c> and <c>Brightness</c> to 1.
        /// </remarks>
        public static NiTweenHandle BindToColorRainbow<TOptions, TAdapter>(this NiTweenBuilder<Color, TOptions, TAdapter> builder,
            [NotNull] SpriteRenderer renderer) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Color, TOptions>
        {
            Error.IsNull(renderer);

            return builder.BindWithState(renderer, static (v, target) =>
            {
                Color.RGBToHSV(v, out var h, out _, out _);
                
                target.color = Color.HSVToRGB(h % 1f, 1f, 1f);
            });
        }
        
        #endregion

        #region Size
        
        /// <summary>
        /// Bind to <c>SpriteRenderer.size</c>.
        /// </summary>
        public static NiTweenHandle BindToSize<TOptions, TAdapter>(this NiTweenBuilder<Vector2, TOptions, TAdapter> builder,
            [NotNull] SpriteRenderer renderer) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Vector2, TOptions>
        {
            Error.IsNull(renderer);

            return builder.BindWithState(renderer, static (v, target) =>
            {
                target.size = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>SpriteRenderer.size.x</c>.
        /// </summary>
        public static NiTweenHandle BindToSizeX<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] SpriteRenderer renderer) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(renderer);

            return builder.BindWithState(renderer, static (v, target) =>
            {
                var cache = target.size;
                cache.x = v;
                target.size = cache;
            });
        }

        /// <summary>
        /// Bind to <c>SpriteRenderer.size.y</c>.
        /// </summary>
        public static NiTweenHandle BindToSizeY<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] SpriteRenderer renderer) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(renderer);

            return builder.BindWithState(renderer, static (v, target) =>
            {
                var cache = target.size;
                cache.y = v;
                target.size = cache;
            });
        }
        
        #endregion

        /// <summary>
        /// Bind to <c>SpriteRenderer.sprite</c>. Gradually sets sprites from the <c>Sprite[] sprites</c> array.
        /// </summary>
        public static NiTweenHandle BindToSprite<TOptions, TAdapter>(this NiTweenBuilder<int, TOptions, TAdapter> builder,
            [NotNull] SpriteRenderer renderer, Sprite[] sprites) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<int, TOptions>
        {
            Error.IsNull(renderer);
            Error.IsNull(sprites);

            var length = sprites.Length;
            var from = builder.Buffer.Data.From;
            var to = builder.Buffer.Data.To;
            
            return builder.BindWithState(renderer, (v, target) =>
            {
                var index = MathUtility.GetNearestIndex(length, v);
                
                target.sprite = sprites[index];
            });
        }
    }
}
