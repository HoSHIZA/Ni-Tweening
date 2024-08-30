using System.Runtime.CompilerServices;

namespace NiGames.Tweening
{
    public static partial class NiTween
    {
        /// <summary>
        /// Creates a <c>NiTweenBuilder</c>.
        /// </summary>
        [MethodImpl(256)]
        public static NiTweenBuilder<T, TOptions, TAdapter> Create<T, TOptions, TAdapter>(T from, T to, float duration) 
            where T : unmanaged 
            where TOptions : unmanaged, ITweenOptions 
            where TAdapter : unmanaged, ITweenAdapter<T, TOptions>
        {
            return NiTweenBuilder<T, TOptions, TAdapter>.Create(from, to, duration);
        }
        
        /// <summary>
        /// Creates an empty <c>NiTweenBuilder</c> with no <c>From</c>, <c>To</c> values.
        /// </summary>
        [MethodImpl(256)]
        public static NiTweenBuilder<T, TOptions, TAdapter> Empty<T, TOptions, TAdapter>(float duration) 
            where T : unmanaged 
            where TOptions : unmanaged, ITweenOptions 
            where TAdapter : unmanaged, ITweenAdapter<T, TOptions>
        {
            return NiTweenBuilder<T, TOptions, TAdapter>.Create(duration);
        }
    }
}