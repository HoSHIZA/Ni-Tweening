using JetBrains.Annotations;
using UnityEngine;

namespace NiGames.Tweening
{
    public static class LightExtensions
    {
        /// <summary>
        /// Bind to <c>Light.intensity</c>.
        /// </summary>
        public static NiTweenHandle BindToLightIntensity<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Light light) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(light);

            return builder.BindWithState(light, static (v, target) =>
            {
                target.intensity = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>Light.range</c>.
        /// </summary>
        public static NiTweenHandle BindToLightRange<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Light light) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(light);

            return builder.BindWithState(light, static (v, target) =>
            {
                target.range = v;
            });
        }

        #region Color

        /// <summary>
        /// Bind to <c>Light.color</c>.
        /// </summary>
        public static NiTweenHandle BindToLightColor<TOptions, TAdapter>(this NiTweenBuilder<Color, TOptions, TAdapter> builder,
            [NotNull] Light light) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Color, TOptions>
        {
            return builder.BindWithState(light, static (v, target) =>
            {
                target.color = v;
            });
        }

        /// <summary>
        /// Bind to <c>Light.color.r</c>.
        /// </summary>
        public static NiTweenHandle BindToLightColorR<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Light light) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            return builder.BindWithState(light, static (v, target) =>
            {
                var cache = target.color;
                cache.r = v;
                target.color = cache;
            });
        }

        /// <summary>
        /// Bind to <c>Light.color.g</c>.
        /// </summary>
        public static NiTweenHandle BindToLightColorG<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder, [NotNull] Light light) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            return builder.BindWithState(light, static (v, target) =>
            {
                var cache = target.color;
                cache.g = v;
                target.color = cache;
            });
        }

        /// <summary>
        /// Bind to <c>Light.color.b</c>.
        /// </summary>
        public static NiTweenHandle BindToLightColorB<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder, [NotNull] Light light) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            return builder.BindWithState(light, static (v, target) =>
            {
                var cache = target.color;
                cache.b = v;
                target.color = cache;
            });
        }

        /// <summary>
        /// Bind to <c>Light.color.a</c>.
        /// </summary>
        public static NiTweenHandle BindToLightColorAlpha<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder, [NotNull] Light light) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            return builder.BindWithState(light, static (v, target) =>
            {
                var cache = target.color;
                cache.a = v;
                target.color = cache;
            });
        }
        
        #endregion
    }
}
