using JetBrains.Annotations;
using UnityEngine;

namespace NiGames.Tweening
{
    public static class Rigidbody2DExtensions
    {
        #region Velocity

        /// <summary>
        /// Bind to <c>Rigidbody2D.velocity.x</c>.
        /// </summary>
        public static NiTweenHandle BindToVelocity<TOptions, TAdapter>(this NiTweenBuilder<Vector2, TOptions, TAdapter> builder,
            [NotNull] Rigidbody2D rb) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Vector2, TOptions>
        {
            Error.IsNull(rb);

            return builder.BindWithState(rb, static (v, target) =>
            {
                target.velocity = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>Rigidbody2D.velocity.x</c>.
        /// </summary>
        public static NiTweenHandle BindToVelocityX<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Rigidbody2D rb)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(rb);

            return builder.BindWithState(rb, static (v, target) =>
            {
                var cache = target.velocity;
                cache.x = v;
                target.velocity = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Rigidbody2D.velocity.x</c>.
        /// </summary>
        public static NiTweenHandle BindToVelocityY<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Rigidbody2D rb)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(rb);

            return builder.BindWithState(rb, static (v, target) =>
            {
                var cache = target.velocity;
                cache.y = v;
                target.velocity = cache;
            });
        }
        #endregion

        #region Angular Velocity

        /// <summary>
        /// Bind to <c>Rigidbody2D.angularVelocity</c>.
        /// </summary>
        public static NiTweenHandle BindToAngularVelocity<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Rigidbody2D rb)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(rb);

            return builder.BindWithState(rb, static (v, target) =>
            {
                target.angularVelocity = v;
            });
        }

        #endregion
    }
}