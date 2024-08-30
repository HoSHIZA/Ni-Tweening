using UnityEngine;

namespace NiGames.Tweening
{
    public readonly struct FloatAdapter : ITweenAdapter<float, NoOptions>
    {
        public float Evaluate(ref float from, ref float to, ref NoOptions options, in float t)
        {
            return Mathf.LerpUnclamped(from, to, t);
        }
    }
    
    public readonly struct IntAdapter : ITweenAdapter<int, IntOptions>
    {
        public int Evaluate(ref int from, ref int to, ref IntOptions options, in float t)
        {
            return options.Round(Mathf.LerpUnclamped(from, to, t));
        }
    }
}