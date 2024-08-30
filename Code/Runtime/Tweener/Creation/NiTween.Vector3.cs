using System.Runtime.CompilerServices;
using UnityEngine;

namespace NiGames.Tweening
{
    public static partial class NiTween
    {
        [MethodImpl(256)]
        public static NiTweenBuilder<Vector3, NoOptions, Vector3Adapter> Create(Vector3 to, float duration)
        {
            return NiTweenBuilder<Vector3, NoOptions, Vector3Adapter>.Create(to, duration);
        }
        
        [MethodImpl(256)]
        public static NiTweenBuilder<Vector3, NoOptions, Vector3Adapter> Create(Vector3 from, Vector3 to, float duration)
        {
            return NiTweenBuilder<Vector3, NoOptions, Vector3Adapter>.Create(from, to, duration);
        }
    }
}