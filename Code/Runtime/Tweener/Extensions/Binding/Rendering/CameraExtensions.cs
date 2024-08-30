using JetBrains.Annotations;
using UnityEngine;

namespace NiGames.Tweening
{
    public static class CameraExtensions
    {
        /// <summary>
        /// Bind to <c>Camera.backgroundColor</c>.
        /// </summary>
        public static NiTweenHandle BindToBackgroundColor<TOptions, TAdapter>(this NiTweenBuilder<Color, TOptions, TAdapter> builder,
            [NotNull] Camera camera) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Color, TOptions>
        {
            Error.IsNull(camera);

            return builder.BindWithState(camera, static (v, target) =>
            {
                target.backgroundColor = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>Camera.fieldOfView</c>.
        /// </summary>
        public static NiTweenHandle BindToFieldOfView<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Camera camera) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(camera);

            return builder.BindWithState(camera, static (v, target) =>
            {
                target.fieldOfView = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>Camera.orthographicSize</c>.
        /// </summary>
        public static NiTweenHandle BindToOrthographicSize<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Camera camera) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(camera);

            return builder.BindWithState(camera, static (v, target) =>
            {
                target.orthographicSize = v;
            });
        }
    }
}