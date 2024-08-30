using JetBrains.Annotations;
using Unity.Collections;
using UnityEngine.UI;

namespace NiGames.Tweening
{
    public static class TextExtensions
    {
        /// <summary>
        /// Bind to <c>Text.fontSize</c>.
        /// </summary>
        public static NiTweenHandle BindToFontSize<TOptions, TAdapter>(this NiTweenBuilder<int, TOptions, TAdapter> builder,
            [NotNull] Text text)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<int, TOptions>
        {
            Error.IsNull(text);

            return builder.BindWithState(text, static (v, target) =>
            {
                target.fontSize = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>Text.lineSpacing</c>.
        /// </summary>
        public static NiTweenHandle BindToLineSpacing<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Text text) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(text);

            return builder.BindWithState(text, static (v, target) =>
            {
                target.lineSpacing = v;
            });
        }
        
        #region Text
        
        /// <summary>
        /// Bind to <c>Text.text</c>.
        /// </summary>
        public static NiTweenHandle BindToText<TOptions, TAdapter>(this NiTweenBuilder<FixedString32Bytes, TOptions, TAdapter> builder,
            [NotNull] Text text)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<FixedString32Bytes, TOptions>
        {
            Error.IsNull(text);

            return builder.BindWithState(text, static (v, target) =>
            {
                target.text = v.ConvertToString();
            });
        }
        
        /// <summary>
        /// Bind to <c>Text.text</c>.
        /// </summary>
        public static NiTweenHandle BindToText<TOptions, TAdapter>(this NiTweenBuilder<FixedString64Bytes, TOptions, TAdapter> builder,
            [NotNull] Text text)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<FixedString64Bytes, TOptions>
        {
            Error.IsNull(text);

            return builder.BindWithState(text, static (v, target) =>
            {
                target.text = v.ConvertToString();
            });
        }
        
        /// <summary>
        /// Bind to <c>Text.text</c>.
        /// </summary>
        public static NiTweenHandle BindToText<TOptions, TAdapter>(this NiTweenBuilder<FixedString128Bytes, TOptions, TAdapter> builder,
            [NotNull] Text text)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<FixedString128Bytes, TOptions>
        {
            Error.IsNull(text);

            return builder.BindWithState(text, static (v, target) =>
            {
                target.text = v.ConvertToString();
            });
        }
        
        /// <summary>
        /// Bind to <c>Text.text</c>.
        /// </summary>
        public static NiTweenHandle BindToText<TOptions, TAdapter>(this NiTweenBuilder<FixedString512Bytes, TOptions, TAdapter> builder,
            [NotNull] Text text)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<FixedString512Bytes, TOptions>
        {
            Error.IsNull(text);

            return builder.BindWithState(text, static (v, target) =>
            {
                target.text = v.ConvertToString();
            });
        }
        
        /// <summary>
        /// Bind to <c>Text.text</c>.
        /// </summary>
        public static NiTweenHandle BindToText<TOptions, TAdapter>(this NiTweenBuilder<FixedString4096Bytes, TOptions, TAdapter> builder,
            [NotNull] Text text)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<FixedString4096Bytes, TOptions>
        {
            Error.IsNull(text);

            return builder.BindWithState(text, static (v, target) =>
            {
                target.text = v.ConvertToString();
            });
        }
        
        /// <summary>
        /// Bind to <c>Text.text</c>.
        /// </summary>
        public static NiTweenHandle BindToText<TOptions, TAdapter>(this NiTweenBuilder<int, TOptions, TAdapter> builder,
            [NotNull] Text text)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<int, TOptions>
        {
            Error.IsNull(text);

            return builder.BindWithState(text, static (v, target) =>
            {
                target.text = v.ToString();
            });
        }
        
        /// <summary>
        /// Bind to <c>Text.text</c>.
        /// </summary>
        public static NiTweenHandle BindToText<TOptions, TAdapter>(this NiTweenBuilder<int, TOptions, TAdapter> builder,
            [NotNull] Text text, string format)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<int, TOptions>
        {
            Error.IsNull(text);

            return builder.BindWithState(text, format, static (v, target, format) =>
            {
                target.text = v.ToString(format);
            });
        }
        
        /// <summary>
        /// Bind to <c>Text.text</c>.
        /// </summary>
        public static NiTweenHandle BindToText<TOptions, TAdapter>(this NiTweenBuilder<long, TOptions, TAdapter> builder,
            [NotNull] Text text)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<long, TOptions>
        {
            Error.IsNull(text);

            return builder.BindWithState(text, static (v, target) =>
            {
                target.text = v.ToString();
            });
        }
        
        /// <summary>
        /// Bind to <c>Text.text</c>.
        /// </summary>
        public static NiTweenHandle BindToText<TOptions, TAdapter>(this NiTweenBuilder<long, TOptions, TAdapter> builder,
            [NotNull] Text text, string format)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<long, TOptions>
        {
            Error.IsNull(text);

            return builder.BindWithState(text, format, static (v, target, format) =>
            {
                target.text = v.ToString(format);
            });
        }
        
        /// <summary>
        /// Bind to <c>Text.text</c>.
        /// </summary>
        public static NiTweenHandle BindToText<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Text text)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(text);

            return builder.BindWithState(text, static (v, target) =>
            {
                target.text = v.ToString();
            });
        }
        
        /// <summary>
        /// Bind to <c>Text.text</c>.
        /// </summary>
        public static NiTweenHandle BindToText<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Text text, string format)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(text);

            return builder.BindWithState(text, format, static (v, target, format) =>
            {
                target.text = v.ToString(format);
            });
        }
        
        #endregion
    }
}