using JetBrains.Annotations;
using NiGames.Tweening.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace NiGames.Tweening
{
    public static class ImageExtensions
    {
        /// <summary>
        /// Bind to <c>Image.fillAmount</c>.
        /// </summary>
        public static NiTweenHandle BindToFillAmount<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Image image) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(image);

            return builder.BindWithState(image, static (v, target) =>
            {
                target.fillAmount = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>Image.sprite</c>. Gradually sets sprites from the <c>Sprite[] sprites</c> array.
        /// </summary>
        public static NiTweenHandle BindToSprite<TOptions, TAdapter>(this NiTweenBuilder<int, TOptions, TAdapter> builder,
            [NotNull] Image image, Sprite[] sprites) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<int, TOptions>
        {
            Error.IsNull(image);
            Error.IsNull(sprites);

            var length = sprites.Length;
            var from = builder.Buffer.Data.From;
            var to = builder.Buffer.Data.To;
            
            return builder.BindWithState(image, (v, target) =>
            {
                var index = MathUtility.GetNearestIndex(length, v);
                
                target.sprite = sprites[index];
            });
        }
    }
}