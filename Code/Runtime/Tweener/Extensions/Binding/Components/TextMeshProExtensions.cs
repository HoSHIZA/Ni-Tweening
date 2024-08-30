#if HAS_TEXT_MESH_PRO
using System.Buffers;
using JetBrains.Annotations;
using TMPro;
using Unity.Collections;
using UnityEngine;

namespace NiGames.Tweening
{
    public static class TextMeshProExtensions
    {
        /// <summary>
        /// Bind to <c>TMP_Text.fontSize</c>.
        /// </summary>
        public static NiTweenHandle BindToFontSize<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] TMP_Text text) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(text);
            
            return builder.BindWithState(text, static (v, target) =>
            {
                target.fontSize = v;
            });
        }

        #region Max Visible Characters
        
        /// <summary>
        /// Bind to <c>TMP_Text.maxVisibleCharacters</c>.
        /// </summary>
        public static NiTweenHandle BindToMaxVisibleCharacters<TOptions, TAdapter>(this NiTweenBuilder<int, TOptions, TAdapter> builder,
            [NotNull] TMP_Text text) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<int, TOptions>
        {
            Error.IsNull(text);

            return builder.BindWithState(text, static (v, target) =>
            {
                target.maxVisibleCharacters = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>TMP_Text.maxVisibleWords</c>.
        /// </summary>
        public static NiTweenHandle BindToMaxVisibleWords<TOptions, TAdapter>(this NiTweenBuilder<int, TOptions, TAdapter> builder,
            [NotNull] TMP_Text text) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<int, TOptions>
        {
            Error.IsNull(text);

            return builder.BindWithState(text, static (v, target) =>
            {
                target.maxVisibleWords = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>TMP_Text.maxVisibleLines</c>.
        /// </summary>
        public static NiTweenHandle BindToMaxVisibleLines<TOptions, TAdapter>(this NiTweenBuilder<int, TOptions, TAdapter> builder,
            [NotNull] TMP_Text text) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<int, TOptions>
        {
            Error.IsNull(text);

            return builder.BindWithState(text, static (v, target) =>
            {
                target.maxVisibleLines = v;
            });
        }
        
        #endregion

        #region Spacing

        /// <summary>
        /// Bind to <c>TMP_Text.characterSpacing</c>.
        /// </summary>
        public static NiTweenHandle BindToCharacterSpacing<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] TMP_Text text) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(text);

            return builder.BindWithState(text, static (v, target) =>
            {
                target.characterSpacing = v;
            });
        }

        /// <summary>
        /// Bind to <c>TMP_Text.wordSpacing</c>.
        /// </summary>
        public static NiTweenHandle BindToWordSpacing<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] TMP_Text text) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(text);

            return builder.BindWithState(text, static (v, target) =>
            {
                target.wordSpacing = v;
            });
        }

        /// <summary>
        /// Bind to <c>TMP_Text.lineSpacing</c>.
        /// </summary>
        public static NiTweenHandle BindToLineSpacing<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] TMP_Text text) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(text);

            return builder.BindWithState(text, static (v, target) =>
            {
                target.lineSpacing = v;
            });
        }
        
        #endregion
        
        #region Color
        
        /// <summary>
        /// Bind to <c>TMP_Text.color</c>.
        /// </summary>
        public static NiTweenHandle BindToColor<TOptions, TAdapter>(this NiTweenBuilder<Color, TOptions, TAdapter> builder,
            [NotNull] TMP_Text text) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Color, TOptions>
        {
            Error.IsNull(text);
            
            return builder.BindWithState(text, static (v, target) =>
            {
                target.color = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>TMP_Text.color.r</c>.
        /// </summary>
        public static NiTweenHandle BindToColorR<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] TMP_Text text) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(text);
            
            return builder.BindWithState(text, static (v, target) =>
            {
                var cache = target.color;
                cache.r = v;
                target.color = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>TMP_Text.color.g</c>.
        /// </summary>
        public static NiTweenHandle BindToColorG<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] TMP_Text text) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(text);

            return builder.BindWithState(text, static (v, target) =>
            {
                var cache = target.color;
                cache.g = v;
                target.color = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>TMP_Text.color.b</c>.
        /// </summary>
        public static NiTweenHandle BindToColorB<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] TMP_Text text) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(text);

            return builder.BindWithState(text, static (v, target) =>
            {
                var cache = target.color;
                cache.b = v;
                target.color = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>TMP_Text.color.a</c>.
        /// </summary>
        public static NiTweenHandle BindToAlpha<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] TMP_Text text) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(text);

            return builder.BindWithState(text, static (v, target) =>
            {
                var cache = target.color;
                cache.a = v;
                target.color = cache;
            });
        }

        #endregion

        #region Outline Color

        /// <summary>
        /// Bind to <c>TMP_Text.outlineColor</c>.
        /// </summary>
        public static NiTweenHandle BindToOutlineColor<TOptions, TAdapter>(this NiTweenBuilder<Color32, TOptions, TAdapter> builder,
            [NotNull] TMP_Text text) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Color32, TOptions>
        {
            Error.IsNull(text);
            
            return builder.BindWithState(text, static (v, target) =>
            {
                target.outlineColor = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>TMP_Text.outlineColor.r</c>.
        /// </summary>
        public static NiTweenHandle BindToOutlineColorR<TOptions, TAdapter>(this NiTweenBuilder<byte, TOptions, TAdapter> builder,
            [NotNull] TMP_Text text) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<byte, TOptions>
        {
            Error.IsNull(text);
            
            return builder.BindWithState(text, static (v, target) =>
            {
                var cache = target.outlineColor;
                cache.r = v;
                target.outlineColor = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>TMP_Text.outlineColor.g</c>.
        /// </summary>
        public static NiTweenHandle BindToOutlineColorG<TOptions, TAdapter>(this NiTweenBuilder<byte, TOptions, TAdapter> builder,
            [NotNull] TMP_Text text) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<byte, TOptions>
        {
            Error.IsNull(text);
            
            return builder.BindWithState(text, static (v, target) =>
            {
                var cache = target.outlineColor;
                cache.g = v;
                target.outlineColor = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>TMP_Text.outlineColor.b</c>.
        /// </summary>
        public static NiTweenHandle BindToOutlineColorB<TOptions, TAdapter>(this NiTweenBuilder<byte, TOptions, TAdapter> builder,
            [NotNull] TMP_Text text) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<byte, TOptions>
        {
            Error.IsNull(text);
            
            return builder.BindWithState(text, static (v, target) =>
            {
                var cache = target.outlineColor;
                cache.b = v;
                target.outlineColor = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>TMP_Text.outlineColor.a</c>.
        /// </summary>
        public static NiTweenHandle BindToOutlineColorAlpha<TOptions, TAdapter>(this NiTweenBuilder<byte, TOptions, TAdapter> builder,
            [NotNull] TMP_Text text) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<byte, TOptions>
        {
            Error.IsNull(text);
            
            return builder.BindWithState(text, static (v, target) =>
            {
                var cache = target.outlineColor;
                cache.a = v;
                target.outlineColor = cache;
            });
        }

        #endregion

        #region Text

        /// <summary>
        /// Bind to <c>TMP_Text.text</c>.
        /// </summary>
        public static NiTweenHandle BindToText<TOptions, TAdapter>(this NiTweenBuilder<FixedString32Bytes, TOptions, TAdapter> builder,
            [NotNull] TMP_Text text)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<FixedString32Bytes, TOptions>
        {
            Error.IsNull(text);
            
            return builder.BindWithState(text, static (v, target) =>
            {
                target.SetText(ref v);
            });
        }
        
        /// <summary>
        /// Bind to <c>TMP_Text.text</c>.
        /// </summary>
        public static NiTweenHandle BindToText<TOptions, TAdapter>(this NiTweenBuilder<FixedString64Bytes, TOptions, TAdapter> builder,
            [NotNull] TMP_Text text)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<FixedString64Bytes, TOptions>
        {
            Error.IsNull(text);
            
            return builder.BindWithState(text, static (v, target) =>
            {
                target.SetText(ref v);
            });
        }
        
        /// <summary>
        /// Bind to <c>TMP_Text.text</c>.
        /// </summary>
        public static NiTweenHandle BindToText<TOptions, TAdapter>(this NiTweenBuilder<FixedString128Bytes, TOptions, TAdapter> builder,
            [NotNull] TMP_Text text)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<FixedString128Bytes, TOptions>
        {
            Error.IsNull(text);
            
            return builder.BindWithState(text, static (v, target) =>
            {
                target.SetText(ref v);
            });
        }
        
        /// <summary>
        /// Bind to <c>TMP_Text.text</c>.
        /// </summary>
        public static NiTweenHandle BindToText<TOptions, TAdapter>(this NiTweenBuilder<FixedString512Bytes, TOptions, TAdapter> builder,
            [NotNull] TMP_Text text)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<FixedString512Bytes, TOptions>
        {
            Error.IsNull(text);
            
            return builder.BindWithState(text, static (v, target) =>
            {
                target.SetText(ref v);
            });
        }
        
        /// <summary>
        /// Bind to <c>TMP_Text.text</c>.
        /// </summary>
        public static NiTweenHandle BindToText<TOptions, TAdapter>(this NiTweenBuilder<FixedString4096Bytes, TOptions, TAdapter> builder,
            [NotNull] TMP_Text text)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<FixedString4096Bytes, TOptions>
        {
            Error.IsNull(text);
            
            return builder.BindWithState(text, static (v, target) =>
            {
                target.SetText(ref v);
            });
        }
        
        /// <summary>
        /// Bind to <c>TMP_Text.text</c>.
        /// </summary>
        public static NiTweenHandle BindToText<TOptions, TAdapter>(this NiTweenBuilder<int, TOptions, TAdapter> builder,
            [NotNull] TMP_Text text)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<int, TOptions>
        {
            Error.IsNull(text);
            
            return builder.BindWithState(text, static (v, target) =>
            {
                target.SetText(v.ToString());
            });
        }
        
        /// <summary>
        /// Bind to <c>TMP_Text.text</c>.
        /// </summary>
        public static NiTweenHandle BindToText<TOptions, TAdapter>(this NiTweenBuilder<int, TOptions, TAdapter> builder,
            [NotNull] TMP_Text text, string format)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<int, TOptions>
        {
            Error.IsNull(text);
            
            return builder.BindWithState(text, format, static (v, target, format) =>
            {
                target.SetText(v.ToString(format));
            });
        }
        
        /// <summary>
        /// Bind to <c>TMP_Text.text</c>.
        /// </summary>
        public static NiTweenHandle BindToText<TOptions, TAdapter>(this NiTweenBuilder<long, TOptions, TAdapter> builder,
            [NotNull] TMP_Text text)
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
        /// Bind to <c>TMP_Text.text</c>.
        /// </summary>
        public static NiTweenHandle BindToText<TOptions, TAdapter>(this NiTweenBuilder<long, TOptions, TAdapter> builder,
            [NotNull] TMP_Text text, string format)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<long, TOptions>
        {
            Error.IsNull(text);
            
            return builder.BindWithState(text, format, static (v, target, format) =>
            {
                target.SetText(v.ToString(format));
            });
        }
        
        /// <summary>
        /// Bind to <c>TMP_Text.text</c>.
        /// </summary>
        public static NiTweenHandle BindToText<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] TMP_Text text)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(text);
            
            return builder.BindWithState(text, static (v, target) =>
            {
                target.SetText(v.ToString());
            });
        }
        
        /// <summary>
        /// Bind to <c>TMP_Text.text</c>.
        /// </summary>
        public static NiTweenHandle BindToText<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] TMP_Text text, string format)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(text);
            
            return builder.BindWithState(text, format, static (v, target, format) =>
            {
                target.SetText(v.ToString(format));
            });
        }

        #endregion
        
        private static unsafe void SetText<T>(this TMP_Text target, ref T fs)
            where T : unmanaged, INativeList<byte>, IUTF8Bytes
        {
            int length;
            var buffer = ArrayPool<char>.Shared.Rent((fs.Capacity + 3) * 2);
            fixed (char* c = buffer)
            {
                Unicode.Utf8ToUtf16(fs.GetUnsafePtr(), fs.Length, c, out length, fs.Length * 2);
            }
            target.SetText(buffer, 0, length);
            ArrayPool<char>.Shared.Return(buffer);
        }
    }
}
#endif
