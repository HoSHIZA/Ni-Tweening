using System.Runtime.CompilerServices;

namespace NiGames.Tweening
{
    public static partial class NiTween
    {
        [MethodImpl(256)]
        public static NiTweenBuilder<int, IntOptions, IntAdapter> Create(int to, float duration, RoundingMode roundingMode = default)
        {
            return NiTweenBuilder<int, IntOptions, IntAdapter>.Create(to, duration)
                .WithOptions(new IntOptions() { RoundingMode = roundingMode });
        }

        [MethodImpl(256)]
        public static NiTweenBuilder<int, IntOptions, IntAdapter> Create(int from, int to, float duration, RoundingMode roundingMode = default)
        {
            return NiTweenBuilder<int, IntOptions, IntAdapter>.Create(from, to, duration)
                .WithOptions(new IntOptions() { RoundingMode = roundingMode });
        }
    }
}