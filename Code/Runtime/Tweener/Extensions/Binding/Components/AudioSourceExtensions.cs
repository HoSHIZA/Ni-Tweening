using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Audio;

namespace NiGames.Tweening
{
    public static class AudioSourceExtensions
    {
        /// <summary>
        /// Bind to <c>AudioSource.volume</c>.
        /// </summary>
        public static NiTweenHandle BindToVolume<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] AudioSource audio) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(audio);

            return builder.BindWithState(audio, static (v, target) =>
            {
                target.volume = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>AudioSource.pitch</c>.
        /// </summary>
        public static NiTweenHandle BindToPitch<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] AudioSource audio) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(audio);

            return builder.BindWithState(audio, static (v, target) =>
            {
                target.pitch = v;
            });
        }

        /// <summary>
        /// Bind to <c>AudioSource.priority</c>.
        /// </summary>
        public static NiTweenHandle BindToPriority<TOptions, TAdapter>(this NiTweenBuilder<int, TOptions, TAdapter> builder,
            [NotNull] AudioSource audio) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<int, TOptions>
        {
            Error.IsNull(audio);

            return builder.BindWithState(audio, static (v, target) =>
            {
                target.priority = v;
            });
        }

        /// <summary>
        /// Bind to <c>AudioSource.reverbZoneMix</c>.
        /// </summary>
        public static NiTweenHandle BindToReverbZoneMix<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] AudioSource audio) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(audio);

            return builder.BindWithState(audio, static (v, target) =>
            {
                target.reverbZoneMix = v;
            });
        }

        /// <summary>
        /// Bind to <c>AudioSource.panStereo</c>.
        /// </summary>
        public static NiTweenHandle BindToPanStereo<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] AudioSource audio) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(audio);

            return builder.BindWithState(audio, static (v, target) =>
            {
                target.panStereo = v;
            });
        }

        /// <summary>
        /// Bind to float <c>AudioMixer</c> property.
        /// </summary>
        public static NiTweenHandle BindToSpatialBlend<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] AudioMixer audioMixer, string name)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(audioMixer);

            return builder.BindWithState(audioMixer, name, static (v, target, n) =>
            {
                target.SetFloat(n, v);
            });
        }
    }
}