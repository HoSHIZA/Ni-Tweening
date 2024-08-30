using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace NiGames.Tweening
{
    public static class LayoutGroupExtensions
    {
        /// <summary>
        /// Bind to <c>VerticalLayoutGroup.spacing</c>.
        /// </summary>
        public static NiTweenHandle BindToLayoutSpacing<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder, 
            [NotNull] VerticalLayoutGroup group)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(group);

            return builder.BindWithState(group, static (v, target) =>
            {
                target.spacing = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>HorizontalLayoutGroup.spacing</c>.
        /// </summary>
        public static NiTweenHandle BindToLayoutSpacing<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder, 
            [NotNull] HorizontalLayoutGroup group) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(group);

            return builder.BindWithState(group, static (v, target) =>
            {
                target.spacing = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>GridLayoutGroup.spacing</c>.
        /// </summary>
        public static NiTweenHandle BindToLayoutSpacing<TOptions, TAdapter>(this NiTweenBuilder<Vector2, TOptions, TAdapter> builder, 
            [NotNull] GridLayoutGroup group) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Vector2, TOptions>
        {
            Error.IsNull(group);

            return builder.BindWithState(group, static (v, target) =>
            {
                target.spacing = v;
            });
        }

        /// <summary>
        /// Bind to <c>GridLayoutGroup.spacing.x</c>.
        /// </summary>
        public static NiTweenHandle BindToLayoutSpacingX<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder, 
            [NotNull] GridLayoutGroup group) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(group);

            return builder.BindWithState(group, static (v, target) =>
            {
                var cache = target.spacing;
                cache.x = v;
                target.spacing = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>GridLayoutGroup.spacing.y</c>.
        /// </summary>
        public static NiTweenHandle BindToLayoutSpacingY<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder, 
            [NotNull] GridLayoutGroup group) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(group);

            return builder.BindWithState(group, static (v, target) =>
            {
                var cache = target.spacing;
                cache.y = v;
                target.spacing = cache;
            });
        }
    }
}