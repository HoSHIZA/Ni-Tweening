using JetBrains.Annotations;
using UnityEngine;

namespace NiGames.Tweening
{
    public static class CanvasGroupExtensions
    {
        /// <summary>
        /// Bind to <c>CanvasGroup.alpha</c>.
        /// </summary>
        public static NiTweenHandle BindToAlpha<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] CanvasGroup canvasGroup) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(canvasGroup);

            return builder.BindWithState(canvasGroup, static (v, target) =>
            {
                target.alpha = v;
            });
        }
    }
}