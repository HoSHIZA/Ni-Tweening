using System.Runtime.CompilerServices;

namespace NiGames.Tweening
{
    public static partial class NiTween
    {
        [MethodImpl(256)]
        public static NiTweenBuilder<float, NoOptions, FloatAdapter> Create(float to, float duration)
        {
            return NiTweenBuilder<float, NoOptions, FloatAdapter>.Create(to, duration);
        }
        
        [MethodImpl(256)]
        public static NiTweenBuilder<float, NoOptions, FloatAdapter> Create(float from, float to, float duration)
        {
            return NiTweenBuilder<float, NoOptions, FloatAdapter>.Create(from, to, duration);
        }
    }
}