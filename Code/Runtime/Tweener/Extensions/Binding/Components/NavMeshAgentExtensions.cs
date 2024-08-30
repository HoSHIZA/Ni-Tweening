using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

namespace NiGames.Tweening
{
    public static class NavMeshAgentExtensions
    {
        #region Speed

        /// <summary>
        /// Bind to <c>NavMeshAgent.speed</c>.
        /// </summary>
        public static NiTweenHandle BindToSpeed<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] NavMeshAgent agent) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(agent);

            return builder.BindWithState(agent, static (v, target) =>
            {
                target.speed = v;
            });
        }

        /// <summary>
        /// Bind to <c>NavMeshAgent.angularSpeed</c>.
        /// </summary>
        public static NiTweenHandle BindToAngularSpeed<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] NavMeshAgent agent) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(agent);

            return builder.BindWithState(agent, static (v, target) =>
            {
                target.angularSpeed = v;
            });
        }
        
        #endregion

        #region Velocity

        /// <summary>
        /// Bind to <c>NavMeshAgent.velocity</c>.
        /// </summary>
        public static NiTweenHandle BindToVelocity<TOptions, TAdapter>(this NiTweenBuilder<Vector3, TOptions, TAdapter> builder,
            [NotNull] NavMeshAgent agent) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<Vector3, TOptions>
        {
            Error.IsNull(agent);

            return builder.BindWithState(agent, static (v, target) =>
            {
                target.velocity = v;
            });
        }
        
        /// <summary>
        /// Bind to <c>NavMeshAgent.velocity.x</c>.
        /// </summary>
        public static NiTweenHandle BindToVelocityX<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] NavMeshAgent agent)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(agent);

            return builder.BindWithState(agent, static (v, target) =>
            {
                var cache = target.velocity;
                cache.x = v;
                target.velocity = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>NavMeshAgent.velocity.y</c>.
        /// </summary>
        public static NiTweenHandle BindToVelocityY<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] NavMeshAgent agent)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(agent);

            return builder.BindWithState(agent, static (v, target) =>
            {
                var cache = target.velocity;
                cache.y = v;
                target.velocity = cache;
            });
        }
        
        /// <summary>
        /// Bind to <c>NavMeshAgent.velocity.z</c>.
        /// </summary>
        public static NiTweenHandle BindToVelocityZ<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] NavMeshAgent agent)
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(agent);

            return builder.BindWithState(agent, static (v, target) =>
            {
                var cache = target.velocity;
                cache.z = v;
                target.velocity = cache;
            });
        }

        #endregion
    }
}