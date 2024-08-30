using JetBrains.Annotations;
using UnityEngine;

namespace NiGames.Tweening
{
    public static class AnimatorExtensions
    {
        /// <summary>
        /// Bind to <c>Animator.speed</c>.
        /// </summary>
        public static NiTweenHandle BindToAnimationSpeed<TOptions, TAdapter>(this NiTweenBuilder<float, TOptions, TAdapter> builder,
            [NotNull] Animator animator) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<float, TOptions>
        {
            Error.IsNull(animator);

            return builder.BindWithState(animator, static (v, target) =>
            {
                target.speed = v;
            });
        }       
    }
}