using System;
using JetBrains.Annotations;

namespace NiGames.Tweening
{
    public static class ProgressExtensions
    {
        /// <summary>
        /// Bind to <c>IProgress</c>.
        /// </summary>
        public static NiTweenHandle BindToProgress<T, TOptions, TAdapter>(this NiTweenBuilder<T, TOptions, TAdapter> builder,
            [NotNull] IProgress<T> progress)
            where T : unmanaged
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<T, TOptions>
        {
            return builder.BindWithState(progress, static (v, target) =>
            {
                target.Report(v);
            });
        }
    }
}