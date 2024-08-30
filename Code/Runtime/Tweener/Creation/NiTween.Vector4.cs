using System.Runtime.CompilerServices;
using UnityEngine;

namespace NiGames.Tweening
{
    public static partial class NiTween
    {
        [MethodImpl(256)]
        public static NiTweenBuilder<Vector4, NoOptions, Vector4Adapter> Create(Vector4 to, float duration)
        {
            return NiTweenBuilder<Vector4, NoOptions, Vector4Adapter>.Create(to, duration);
        }
        
        [MethodImpl(256)]
        public static NiTweenBuilder<Vector4, NoOptions, Vector4Adapter> Create(Vector4 from, Vector4 to, float duration)
        {
            return NiTweenBuilder<Vector4, NoOptions, Vector4Adapter>.Create(from, to, duration);
        }
    }
}