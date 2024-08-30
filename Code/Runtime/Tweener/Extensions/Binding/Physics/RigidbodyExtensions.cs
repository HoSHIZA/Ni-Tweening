using JetBrains.Annotations;
using UnityEngine;

namespace NiGames.Tweening
{
    public static class RigidbodyExtensions
    {
        #region Velocity

        /// <summary>
        /// Bind to <c>Rigidbody.velocity</c>.
        /// </summary>
        public static NiTweenHandle BindToVelocity<TOptions, TAdapter>(this NiTweenBuilder<Vector3, TOptions, TAdapter> builder,
            [NotNull] Rigidbody rb) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Vector3, TOptions>
        {
            Error.IsNull(rb);

            return builder.BindWithState(rb, static (v, target) =>
            {
                target.velocity = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>Rigidbody.velocity.x</c>.
        /// </summary>
        public static NiTweenHandle BindToVelocityX<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Rigidbody rb)
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
        /// Bind to <c>Rigidbody.velocity.y</c>.
        /// </summary>
        public static NiTweenHandle BindToVelocityY<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Rigidbody rb)
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
        
        /// <summary>
        /// Bind to <c>Rigidbody.velocity.z</c>.
        /// </summary>
        public static NiTweenHandle BindToVelocityZ<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Rigidbody rb)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(rb);

            return builder.BindWithState(rb, static (v, target) =>
            {
                var cache = target.velocity;
                cache.z = v;
                target.velocity = cache;
            });
        }

        #endregion
        
        #region Angular Velocity

        /// <summary>
        /// Bind to <c>Rigidbody.angularVelocity</c>.
        /// </summary>
        public static NiTweenHandle BindToAngularVelocity<TOptions, TAdapter>(this NiTweenBuilder<Vector3, TOptions, TAdapter> builder,
            [NotNull] Rigidbody rb) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Vector3, TOptions>
        {
            Error.IsNull(rb);

            return builder.BindWithState(rb, static (v, target) =>
            {
                target.angularVelocity = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>Rigidbody.angularVelocity.x</c>.
        /// </summary>
        public static NiTweenHandle BindToAngularVelocityX<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Rigidbody rb)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(rb);

            return builder.BindWithState(rb, static (v, target) =>
            {
                var cache = target.angularVelocity;
                cache.x = v;
                target.angularVelocity = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Rigidbody.angularVelocity.y</c>.
        /// </summary>
        public static NiTweenHandle BindToAngularVelocityY<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Rigidbody rb)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(rb);

            return builder.BindWithState(rb, static (v, target) =>
            {
                var cache = target.angularVelocity;
                cache.y = v;
                target.angularVelocity = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Rigidbody.angularVelocity.z</c>.
        /// </summary>
        public static NiTweenHandle BindToAngularVelocityZ<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Rigidbody rb)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(rb);

            return builder.BindWithState(rb, static (v, target) =>
            {
                var cache = target.angularVelocity;
                cache.z = v;
                target.angularVelocity = cache;
            });
        }

        #endregion
    }
}