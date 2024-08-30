using JetBrains.Annotations;
using UnityEngine.Video;

namespace NiGames.Tweening
{
    public static class VideoPlayerExtensions
    {
        /// <summary>
        /// Bind to <c>VideoPlayer.playbackSpeed</c>.
        /// </summary>
        public static NiTweenHandle BindToPlaybackSpeed<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] VideoPlayer videoPlayer) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(videoPlayer);

            return builder.BindWithState(videoPlayer, static (v, target) =>
            {
                target.playbackSpeed = v;
            });
        }
    }
}