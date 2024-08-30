using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace NiGames.Tweening
{
    public static class ProgressBarExtensions
    {
        /// <summary>
        /// Bind to <c>AbstractProgressBar.value</c>.
        /// </summary>
        public static NiTweenHandle BindToProgressBar<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] AbstractProgressBar progressBar) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(progressBar);

            return builder.BindWithState(progressBar, static (v, target) =>
            {
                target.value = v;
            });
        }
    }
}