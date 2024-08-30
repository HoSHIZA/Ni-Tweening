using JetBrains.Annotations;
using UnityEngine;

namespace NiGames.Tweening
{
    public static class TransformExtensions
    {
        #region Position
        
        /// <summary>
        /// Bind to <c>Transform.position</c>.
        /// </summary>
        public static NiTweenHandle BindToPosition<TOptions, TAdapter>(this NiTweenBuilder<Vector3, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Vector3, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                target.position = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.position.x</c>.
        /// </summary>
        public static NiTweenHandle BindToPositionX<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.position;
                cache.x = v;
                target.position = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.position.y</c>.
        /// </summary>
        public static NiTweenHandle BindToPositionY<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.position;
                cache.y = v;
                target.position = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.position.z</c>.
        /// </summary>
        public static NiTweenHandle BindToPositionZ<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.position;
                cache.z = v;
                target.position = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.position.xy</c>.
        /// </summary>
        public static NiTweenHandle BindToPositionXY<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.position;
                cache.x = v;
                cache.y = v;
                target.position = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.position.xz</c>.
        /// </summary>
        public static NiTweenHandle BindToPositionXZ<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.position;
                cache.x = v;
                cache.z = v;
                target.position = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.position.yz</c>.
        /// </summary>
        public static NiTweenHandle BindToPositionYZ<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.position;
                cache.y = v;
                cache.z = v;
                target.position = cache;
            });
        }
        
        #endregion
        
        #region Local Position
        
        /// <summary>
        /// Bind to <c>Transform.localPosition</c>.
        /// </summary>
        public static NiTweenHandle BindToLocalPosition<TOptions, TAdapter>(this NiTweenBuilder<Vector3, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Vector3, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                target.localPosition = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.localPosition.x</c>.
        /// </summary>
        public static NiTweenHandle BindToLocalPositionX<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.localPosition;
                cache.x = v;
                target.localPosition = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.localPosition.y</c>.
        /// </summary>
        public static NiTweenHandle BindToLocalPositionY<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.localPosition;
                cache.y = v;
                target.localPosition = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.localPosition.z</c>.
        /// </summary>
        public static NiTweenHandle BindToLocalPositionZ<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.localPosition;
                cache.z = v;
                target.localPosition = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.localPosition.xy</c>.
        /// </summary>
        public static NiTweenHandle BindToLocalPositionXY<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.localPosition;
                cache.x = v;
                cache.y = v;
                target.localPosition = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.localPosition.xz</c>.
        /// </summary>
        public static NiTweenHandle BindToLocalPositionXZ<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.localPosition;
                cache.x = v;
                cache.z = v;
                target.localPosition = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.localPosition.yz</c>.
        /// </summary>
        public static NiTweenHandle BindToLocalPositionYZ<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.localPosition;
                cache.y = v;
                cache.z = v;
                target.localPosition = cache;
            });
        }
        
        #endregion

        #region Local Scale
        
        /// <summary>
        /// Bind to <c>Transform.localScale</c>.
        /// </summary>
        public static NiTweenHandle BindToLocalScale<TOptions, TAdapter>(this NiTweenBuilder<Vector3, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Vector3, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                target.localScale = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.localScale.x</c>.
        /// </summary>
        public static NiTweenHandle BindToLocalScaleX<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.localScale;
                cache.x = v;
                target.localScale = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.localScale.y</c>.
        /// </summary>
        public static NiTweenHandle BindToLocalScaleY<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.localScale;
                cache.y = v;
                target.localScale = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.localScale.z</c>.
        /// </summary>
        public static NiTweenHandle BindToLocalScaleZ<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.localScale;
                cache.z = v;
                target.localScale = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.localScale.xy</c>.
        /// </summary>
        public static NiTweenHandle BindToLocalScaleXY<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.localScale;
                cache.x = v;
                cache.y = v;
                target.localScale = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.localScale.xz</c>.
        /// </summary>
        public static NiTweenHandle BindToLocalScaleXZ<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.localScale;
                cache.x = v;
                cache.z = v;
                target.localScale = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.localScale.yz</c>.
        /// </summary>
        public static NiTweenHandle BindToLocalScaleYZ<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.localScale;
                cache.y = v;
                cache.z = v;
                target.localScale = cache;
            });
        }
        
        #endregion

        #region Rotation

        /// <summary>
        /// Bind to <c>Transform.rotation</c>.
        /// </summary>
        public static NiTweenHandle BindToRotation<TOptions, TAdapter>(this NiTweenBuilder<Quaternion, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Quaternion, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                target.rotation = v;
            });
        }

        #endregion

        #region Local Rotation
        
        /// <summary>
        /// Bind to <c>Transform.localRotation</c>.
        /// </summary>
        public static NiTweenHandle BindToLocalRotation<TOptions, TAdapter>(this NiTweenBuilder<Quaternion, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Quaternion, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                target.localRotation = v;
            });
        }

        #endregion
        
        #region Euler Angles
        
        /// <summary>
        /// Bind to <c>Transform.eulerAngles</c>.
        /// </summary>
        public static NiTweenHandle BindToEulerAngles<TOptions, TAdapter>(this NiTweenBuilder<Vector3, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Vector3, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                target.eulerAngles = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.eulerAngles.x</c>.
        /// </summary>
        public static NiTweenHandle BindToEulerAnglesX<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.eulerAngles;
                cache.x = v;
                target.eulerAngles = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.eulerAngles.y</c>.
        /// </summary>
        public static NiTweenHandle BindToEulerAnglesY<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.eulerAngles;
                cache.y = v;
                target.eulerAngles = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.eulerAngles.z</c>.
        /// </summary>
        public static NiTweenHandle BindToEulerAnglesZ<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.eulerAngles;
                cache.z = v;
                target.eulerAngles = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.eulerAngles.xy</c>.
        /// </summary>
        public static NiTweenHandle BindToEulerAnglesXY<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.eulerAngles;
                cache.x = v;
                cache.y = v;
                target.eulerAngles = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.eulerAngles.xz</c>.
        /// </summary>
        public static NiTweenHandle BindToEulerAnglesXZ<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.eulerAngles;
                cache.x = v;
                cache.z = v;
                target.eulerAngles = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.eulerAngles.yz</c>.
        /// </summary>
        public static NiTweenHandle BindToEulerAnglesYZ<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.eulerAngles;
                cache.y = v;
                cache.z = v;
                target.eulerAngles = cache;
            });
        }
        
        #endregion
        
        #region Local Euler Angles
        
        /// <summary>
        /// Bind to <c>Transform.localEulerAngles</c>.
        /// </summary>
        public static NiTweenHandle BindToLocalEulerAngles<TOptions, TAdapter>(this NiTweenBuilder<Vector3, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Vector3, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                target.localEulerAngles = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.localEulerAngles.x</c>.
        /// </summary>
        public static NiTweenHandle BindToLocalEulerAnglesX<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.localEulerAngles;
                cache.x = v;
                target.localEulerAngles = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.localEulerAngles.y</c>.
        /// </summary>
        public static NiTweenHandle BindToLocalEulerAnglesY<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.localEulerAngles;
                cache.y = v;
                target.localEulerAngles = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.localEulerAngles.z</c>.
        /// </summary>
        public static NiTweenHandle BindToLocalEulerAnglesZ<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.localEulerAngles;
                cache.z = v;
                target.localEulerAngles = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.localEulerAngles.xy</c>.
        /// </summary>
        public static NiTweenHandle BindToLocalEulerAnglesXY<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.localEulerAngles;
                cache.x = v;
                cache.y = v;
                target.localEulerAngles = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.localEulerAngles.xz</c>.
        /// </summary>
        public static NiTweenHandle BindToLocalEulerAnglesXZ<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.localEulerAngles;
                cache.x = v;
                cache.z = v;
                target.localEulerAngles = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>Transform.localEulerAngles.yz</c>.
        /// </summary>
        public static NiTweenHandle BindToLocalEulerAnglesYZ<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Transform transform)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(transform);
            
            return builder.BindWithState(transform, static (v, target) =>
            {
                var cache = target.localEulerAngles;
                cache.y = v;
                cache.z = v;
                target.localEulerAngles = cache;
            });
        }
        
        #endregion
    } 
}