using System.Runtime.CompilerServices;
using UnityEngine;

namespace NiGames.Tweening
{
    public static partial class NiTween
    {
        [MethodImpl(256)]
        public static NiTweenBuilder<Vector2, NoOptions, Vector2Adapter> Create(Vector2 to, float duration)
        {
            return NiTweenBuilder<Vector2, NoOptions, Vector2Adapter>.Create(to, duration);
        }
        
        [MethodImpl(256)]
        public static NiTweenBuilder<Vector2, NoOptions, Vector2Adapter> Create(Vector2 from, Vector2 to, float duration)
        {
            return NiTweenBuilder<Vector2, NoOptions, Vector2Adapter>.Create(from, to, duration);
        }
    }
}