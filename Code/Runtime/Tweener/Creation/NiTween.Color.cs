using System.Runtime.CompilerServices;
using UnityEngine;

namespace NiGames.Tweening
{
    public static partial class NiTween
    {
        [MethodImpl(256)]
        public static NiTweenBuilder<Color, ColorOptions, ColorAdapter> Create(Color to, float duration, bool useAlpha = true)
        {
            return NiTweenBuilder<Color, ColorOptions, ColorAdapter>.Create(to, duration)
                .WithOptions(new ColorOptions { UseAlpha = useAlpha });
        }

        [MethodImpl(256)]
        public static NiTweenBuilder<Color, ColorOptions, ColorAdapter> Create(Color from, Color to, float duration, bool useAlpha = true)
        {
            return NiTweenBuilder<Color, ColorOptions, ColorAdapter>.Create(from, to, duration)
                .WithOptions(new ColorOptions { UseAlpha = useAlpha });
        }
    }
}