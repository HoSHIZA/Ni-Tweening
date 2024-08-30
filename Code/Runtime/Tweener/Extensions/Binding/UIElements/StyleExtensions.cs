using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

namespace NiGames.Tweening
{
    public static class StyleExtensions
    {
        #region VisualElement - Flex

        /// <summary>
        /// Bind to <c>VisualElement.style.flexGrow</c>.
        /// </summary>
        public static NiTweenHandle BindToStyleFlexGrow<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] VisualElement ve) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(ve);

            return builder.BindWithState(ve, static (v, target) =>
            {
                target.style.flexGrow = v;
            });
        }

        /// <summary>
        /// Bind to <c>VisualElement.style.flexShrink</c>.
        /// </summary>
        public static NiTweenHandle BindToStyleFlexShrink<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] VisualElement ve) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(ve);

            return builder.BindWithState(ve, static (v, target) =>
            {
                target.style.flexShrink = v;
            });
        }

        #endregion
        
        #region VisualElement - Distance
        
        /// <summary>
        /// Bind to <c>VisualElement.style.left</c>.
        /// </summary>
        public static NiTweenHandle BindToStyleLeft<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] VisualElement ve) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(ve);

            return builder.BindWithState(ve, static (v, target) =>
            {
                target.style.left = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>VisualElement.style.right</c>.
        /// </summary>
        public static NiTweenHandle BindToStyleRight<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] VisualElement ve) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(ve);

            return builder.BindWithState(ve, static (v, target) =>
            {
                target.style.right = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>VisualElement.style.top</c>.
        /// </summary>
        public static NiTweenHandle BindToStyleTop<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] VisualElement ve) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(ve);

            return builder.BindWithState(ve, static (v, target) =>
            {
                target.style.top = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>VisualElement.style.bottom</c>.
        /// </summary>
        public static NiTweenHandle BindToStyleBottom<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] VisualElement ve) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(ve);

            return builder.BindWithState(ve, static (v, target) =>
            {
                target.style.bottom = v;
            });
        }
        
        #endregion

        #region VisualElement - Size
        
        /// <summary>
        /// Bind to <c>VisualElement.style.width</c>.
        /// </summary>
        public static NiTweenHandle BindToStyleWidth<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] VisualElement ve) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(ve);

            return builder.BindWithState(ve, static (v, target) =>
            {
                target.style.width = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>VisualElement.style.height</c>.
        /// </summary>
        public static NiTweenHandle BindToStyleHeight<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] VisualElement ve) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(ve);

            return builder.BindWithState(ve, static (v, target) =>
            {
                target.style.height = v;
            });
        }
        
        #endregion

        #region VisualElement - Color
        
        /// <summary>
        /// Bind to <c>VisualElement.style.color</c>.
        /// </summary>
        public static NiTweenHandle BindToStyleColor<TOptions, TAdapter>(this NiTweenBuilder<Color, TOptions, TAdapter> builder,
            [NotNull] VisualElement ve) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Color, TOptions>
        {
            Error.IsNull(ve);

            return builder.BindWithState(ve, static (v, target) =>
            {
                target.style.color = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>VisualElement.style.color.r</c>.
        /// </summary>
        public static NiTweenHandle BindToStyleColorR<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] VisualElement ve) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(ve);

            return builder.BindWithState(ve, static (v, target) =>
            {
                var cache = target.style.color.value;
                cache.r = v;
                target.style.color = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>VisualElement.style.color.g</c>.
        /// </summary>
        public static NiTweenHandle BindToStyleColorG<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] VisualElement ve) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(ve);

            return builder.BindWithState(ve, static (v, target) =>
            {
                var cache = target.style.color.value;
                cache.g = v;
                target.style.color = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>VisualElement.style.color.b</c>.
        /// </summary>
        public static NiTweenHandle BindToStyleColorB<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] VisualElement ve) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(ve);

            return builder.BindWithState(ve, static (v, target) =>
            {
                var cache = target.style.color.value;
                cache.b = v;
                target.style.color = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>VisualElement.style.color.a</c>.
        /// </summary>
        public static NiTweenHandle BindToStyleColorAlpha<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] VisualElement ve) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(ve);

            return builder.BindWithState(ve, static (v, target) =>
            {
                var cache = target.style.color.value;
                cache.a = v;
                target.style.color = cache;
            });
        }
        
        #endregion

        #region VisualElement - Background Color

        /// <summary>
        /// Bind to <c>VisualElement.style.backgroundColor</c>.
        /// </summary>
        public static NiTweenHandle BindToStyleBackgroundColor<TOptions, TAdapter>(this NiTweenBuilder<Color, TOptions, TAdapter> builder,
            [NotNull] VisualElement ve) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Color, TOptions>
        {
            Error.IsNull(ve);

            return builder.BindWithState(ve, static (v, target) =>
            {
                target.style.backgroundColor = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>VisualElement.style.backgroundColor.r</c>.
        /// </summary>
        public static NiTweenHandle BindToStyleBackgroundColorR<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] VisualElement ve) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(ve);

            return builder.BindWithState(ve, static (v, target) =>
            {
                var cache = target.style.backgroundColor.value;
                cache.r = v;
                target.style.backgroundColor = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>VisualElement.style.backgroundColor.g</c>.
        /// </summary>
        public static NiTweenHandle BindToStyleBackgroundColorG<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] VisualElement ve) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(ve);

            return builder.BindWithState(ve, static (v, target) =>
            {
                var cache = target.style.backgroundColor.value;
                cache.g = v;
                target.style.backgroundColor = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>VisualElement.style.backgroundColor.b</c>.
        /// </summary>
        public static NiTweenHandle BindToStyleBackgroundColorB<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] VisualElement ve) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(ve);

            return builder.BindWithState(ve, static (v, target) =>
            {
                var cache = target.style.backgroundColor.value;
                cache.b = v;
                target.style.backgroundColor = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>VisualElement.style.backgroundColor.a</c>.
        /// </summary>
        public static NiTweenHandle BindToStyleBackgroundColorAlpha<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] VisualElement ve) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(ve);

            return builder.BindWithState(ve, static (v, target) =>
            {
                var cache = target.style.backgroundColor.value;
                cache.a = v;
                target.style.backgroundColor = cache;
            });
        }

        #endregion

        #region VisualElement - Other

        /// <summary>
        /// Bind to <c>VisualElement.style.opacity</c>.
        /// </summary>
        public static NiTweenHandle BindToStyleOpacity<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] VisualElement ve) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(ve);

            return builder.BindWithState(ve, static (v, target) =>
            {
                target.style.opacity = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>VisualElement.style.fontSize</c>.
        /// </summary>
        public static NiTweenHandle BindToStyleFontSize<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] VisualElement ve) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(ve);

            return builder.BindWithState(ve, static (v, target) =>
            {
                target.style.fontSize = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>VisualElement.style.wordSpacing</c>.
        /// </summary>
        public static NiTweenHandle BindToStyleWordSpacing<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] VisualElement ve) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(ve);

            return builder.BindWithState(ve, static (v, target) =>
            {
                target.style.wordSpacing = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>VisualElement.style.translate</c>.
        /// </summary>
        public static NiTweenHandle BindToStyleTranslate<TOptions, TAdapter>(this NiTweenBuilder<Vector2, TOptions, TAdapter> builder,
            [NotNull] VisualElement ve) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Vector2, TOptions>
        {
            Error.IsNull(ve);

            return builder.BindWithState(ve, static (v, target) =>
            {
                target.style.translate = new Translate(v.x, v.y);
            });
        }
        
        /// <summary>
        /// Bind to <c>VisualElement.style.translate</c>.
        /// </summary>
        public static NiTweenHandle BindToStyleTranslate<TOptions, TAdapter>(this NiTweenBuilder<Vector3, TOptions, TAdapter> builder,
            [NotNull] VisualElement ve) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Vector3, TOptions>
        {
            Error.IsNull(ve);

            return builder.BindWithState(ve, static (v, target) =>
            {
                target.style.translate = new Translate(v.x, v.y, v.z);
            });
        }
        
        /// <summary>
        /// Bind to <c>VisualElement.style.rotate</c>.
        /// </summary>
        public static NiTweenHandle BindToStyleRotate<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] VisualElement ve, AngleUnit angleUnit = AngleUnit.Degree)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(ve);

            return builder.BindWithState(ve, (v, target) =>
            {
                target.style.rotate = new Rotate(new Angle(v, angleUnit));
            });
        }
        
        /// <summary>
        /// Bind to <c>VisualElement.style.scale</c>.
        /// </summary>
        public static NiTweenHandle BindToStyleScale<TOptions, TAdapter>(this NiTweenBuilder<Vector3, TOptions, TAdapter> builder,
            [NotNull] VisualElement ve) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Vector3, TOptions>
        {
            Error.IsNull(ve);

            return builder.BindWithState(ve, static (v, target) =>
            {
                target.style.scale = new Scale(v);
            });
        }

        /// <summary>
        /// Bind to <c>VisualElement.style.transformOrigin</c>.
        /// </summary>
        public static NiTweenHandle BindToStyleTransformOrigin<TOptions, TAdapter>(this NiTweenBuilder<Vector2, TOptions, TAdapter> builder,
            [NotNull] VisualElement ve) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Vector2, TOptions>
        {
            Error.IsNull(ve);

            return builder.BindWithState(ve, static (v, target) =>
            {
                target.style.transformOrigin = new TransformOrigin(v.x, v.y);
            });
        }

        /// <summary>
        /// Bind to <c>VisualElement.style.transformOrigin</c>.
        /// </summary>
        public static NiTweenHandle BindToStyleTransformOrigin<TOptions, TAdapter>(this NiTweenBuilder<Vector3, TOptions, TAdapter> builder,
            [NotNull] VisualElement ve) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Vector3, TOptions>
        {
            Error.IsNull(ve);

            return builder.BindWithState(ve, static (v, target) =>
            {
                target.style.transformOrigin = new TransformOrigin(v.x, v.y, v.z);
            });
        }

        #endregion
    }
}