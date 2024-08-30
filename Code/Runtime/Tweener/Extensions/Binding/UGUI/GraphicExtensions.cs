using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace NiGames.Tweening
{
    public static class GraphicExtensions
    {
        /// <summary>
        /// Bind to <c>Graphic.color</c>.
        /// </summary>
        public static NiTweenHandle BindToColor<TOptions, TAdapter>(this NiTweenBuilder<Color, TOptions, TAdapter> builder,
            [NotNull] Graphic graphic) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Color, TOptions>
        {
            Error.IsNull(graphic);

            return builder.BindWithState(graphic, static (v, target) =>
            {
                target.color = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>Graphic.color.r</c>.
        /// </summary>
        public static NiTweenHandle BindToColorR<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Graphic graphic) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(graphic);

            return builder.BindWithState(graphic, static (v, target) =>
            {
                var cache = target.color;
                cache.r = v;
                target.color = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Graphic.color.g</c>.
        /// </summary>
        public static NiTweenHandle BindToColorG<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Graphic graphic) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(graphic);

            return builder.BindWithState(graphic, static (v, target) =>
            {
                var cache = target.color;
                cache.g = v;
                target.color = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Graphic.color.b</c>.
        /// </summary>
        public static NiTweenHandle BindToColorB<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Graphic graphic) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(graphic);

            return builder.BindWithState(graphic, static (v, target) =>
            {
                var cache = target.color;
                cache.b = v;
                target.color = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Graphic.color.a</c>.
        /// </summary>
        public static NiTweenHandle BindToAlpha<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Graphic graphic) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(graphic);

            return builder.BindWithState(graphic, static (v, target) =>
            {
                var cache = target.color;
                cache.a = v;
                target.color = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Graphic.color</c>. Works with HUE, takes values from <c>0f</c> to <c>1f</c>.
        /// If the value is above the range, the color continues from 0.
        /// </summary>
        /// <remarks>
        /// Automatically sets <c>Saturation</c> and <c>Brightness</c> to 1.
        /// </remarks>
        public static NiTweenHandle BindToColorRainbow01<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Graphic graphic) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(graphic);

            return builder.BindWithState(graphic, static (v, target) =>
            {
                target.color = Color.HSVToRGB(v % 1f, 1f, 1f);
            });
        }
        
        /// <summary>
        /// Bind to <c>Graphic.color</c>. Works with HUE, takes values from <c>0f</c> to <c>360f</c>.
        /// If the value is above the range, the color continues from 0.
        /// </summary>
        /// <remarks>
        /// Automatically sets <c>Saturation</c> and <c>Brightness</c> to 1.
        /// </remarks>
        public static NiTweenHandle BindToColorRainbow360<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Graphic graphic) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(graphic);

            return builder.BindWithState(graphic, static (v, target) =>
            {
                target.color = Color.HSVToRGB(v % 360f / 360f, 1f, 1f);
            });
        }
        
        /// <summary>
        /// Bind to <c>Graphic.color</c>. Works with HUE.
        /// </summary>
        /// <remarks>
        /// Automatically sets <c>Saturation</c> and <c>Brightness</c> to 1.
        /// </remarks>
        public static NiTweenHandle BindToColorRainbow<TOptions, TAdapter>(this NiTweenBuilder<Color, TOptions, TAdapter> builder,
            [NotNull] Graphic graphic) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Color, TOptions>
        {
            Error.IsNull(graphic);

            return builder.BindWithState(graphic, static (v, target) =>
            {
                Color.RGBToHSV(v, out var h, out _, out _);
                
                target.color = Color.HSVToRGB(h % 1f, 1f, 1f);
            });
        }
    }
}