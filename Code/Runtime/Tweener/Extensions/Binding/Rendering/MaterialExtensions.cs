using JetBrains.Annotations;
using UnityEngine;

namespace NiGames.Tweening
{
    public static class MaterialExtensions
    {
        /// <summary>
        /// Bind to float <c>Material</c> property.
        /// </summary>
        public static NiTweenHandle BindToMaterialFloat<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Material material, string name)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(material);

            return builder.BindWithState(material, name, static (v, target, n) =>
            {
                target.SetFloat(n, v);
            });
        }
        
        /// <summary>
        /// Bind to float <c>Material</c> property.
        /// </summary>
        public static NiTweenHandle BindToMaterialFloat<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Material material, int nameID)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(material);

            return builder.BindWithState(material, (v, target) =>
            {
                target.SetFloat(nameID, v);
            });
        }
        
        /// <summary>
        /// Bind to int <c>Material</c> property.
        /// </summary>
        public static NiTweenHandle BindToMaterialInt<TOptions, TAdapter>(this NiTweenBuilder<int, TOptions, TAdapter> builder,
            [NotNull] Material material, string name)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<int, TOptions>
        {
            Error.IsNull(material);
            Error.IsNullOrEmpty(name);

            return builder.BindWithState(material, name, static (v, target, n) =>
            {
                target.SetInt(n, v);
            });
        }
        
        /// <summary>
        /// Bind to int <c>Material</c> property.
        /// </summary>
        public static NiTweenHandle BindToMaterialInt<TOptions, TAdapter>(this NiTweenBuilder<int, TOptions, TAdapter> builder,
            [NotNull] Material material, int nameID)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<int, TOptions>
        {
            Error.IsNull(material);

            return builder.BindWithState(material, (v, target) =>
            {
                target.SetInt(nameID, v);
            });
        }
        
        /// <summary>
        /// Bind to color <c>Material</c> property.
        /// </summary>
        public static NiTweenHandle BindToMaterialColor<TOptions, TAdapter>(this NiTweenBuilder<Color, TOptions, TAdapter> builder,
            [NotNull] Material material, string name)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Color, TOptions>
        {
            Error.IsNull(material);
            Error.IsNullOrEmpty(name);

            return builder.BindWithState(material, name, static (v, target, n) =>
            {
                target.SetColor(n, v);
            });
        }
        
        /// <summary>
        /// Bind to color <c>Material</c> property.
        /// </summary>
        public static NiTweenHandle BindToMaterialColor<TOptions, TAdapter>(this NiTweenBuilder<Color, TOptions, TAdapter> builder,
            [NotNull] Material material, int nameID)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Color, TOptions>
        {
            Error.IsNull(material);

            return builder.BindWithState(material, (v, target) =>
            {
                target.SetColor(nameID, v);
            });
        }
    }
}