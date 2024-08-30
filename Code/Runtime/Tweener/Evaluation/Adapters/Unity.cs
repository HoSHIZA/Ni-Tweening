using UnityEngine;

namespace NiGames.Tweening
{
    public readonly struct ColorAdapter : ITweenAdapter<Color, ColorOptions>
    {
        public Color Evaluate(ref Color from, ref Color to, ref ColorOptions options, in float t)
        {
            var color = options.UseAlpha ? to : new Color(to.r, to.g, to.b, from.a);
            
            return Color.LerpUnclamped(from, color, t);
        }
    }
    
    public readonly struct Vector2Adapter : ITweenAdapter<Vector2, NoOptions>
    {
        public Vector2 Evaluate(ref Vector2 from, ref Vector2 to, ref NoOptions options, in float t)
        {
            return Vector2.LerpUnclamped(from, to, t);
        }
    }
    
    public readonly struct Vector3Adapter : ITweenAdapter<Vector3, NoOptions>
    {
        public Vector3 Evaluate(ref Vector3 from, ref Vector3 to, ref NoOptions options, in float t)
        {
            return Vector3.LerpUnclamped(from, to, t);
        }
    }
    
    public readonly struct Vector4Adapter : ITweenAdapter<Vector4, NoOptions>
    {
        public Vector4 Evaluate(ref Vector4 from, ref Vector4 to, ref NoOptions options, in float t)
        {
            return Vector4.LerpUnclamped(from, to, t);
        }
    }
    
    public readonly struct QuaternionAdapter : ITweenAdapter<Quaternion, NoOptions>
    {
        public Quaternion Evaluate(ref Quaternion from, ref Quaternion to, ref NoOptions options, in float t)
        {
            return Quaternion.LerpUnclamped(from, to, t);
        }
    }
}