using System;

namespace NiGames.Tweening
{
    [Serializable]
    public struct ColorOptions : ITweenOptions
    {
        public bool UseAlpha;
    }
    
    public static partial class NiTweenBuilderExtensions
    {
        /// <summary>
        /// Specifies whether <c>alpha</c> should be changed when the color is changed.
        /// </summary>
        public static NiTweenBuilder<T, ColorOptions, TAdapter> WithUseAlpha<T, TAdapter>(this NiTweenBuilder<T, ColorOptions, TAdapter> builder, 
            bool use = true)
            where T : unmanaged
            where TAdapter : unmanaged, ITweenAdapter<T, ColorOptions>
        {
            builder.Buffer.Data.Options.UseAlpha = use;
            
            return builder;
        }
    }
}