using System.Runtime.CompilerServices;
using UnityEngine;

namespace NiGames.Tweening.Utility
{
    internal static class MathUtility
    {
        /// <summary>
        /// Remap a value from one range to another.
        /// </summary>
        [MethodImpl(256)]
        public static float Remap(float value, float min1, float max1, float min2, float max2)
        {
            return (value - min1) / (max1 - min1) * (max2 - min2) + min2;
        }
        
        /// <summary>
        /// Get the nearest value in a range using a normalized parameter t.
        /// </summary>
        [MethodImpl(256)]
        public static float GetNearestInRange(float min, float max, float t)
        {
            return Mathf.Lerp(min, max, Mathf.Clamp01(t));
        }

        /// <summary>
        /// Get the nearest index in an array using a normalized parameter t
        /// </summary>
        [MethodImpl(256)]
        public static int GetNearestIndex(int arrayLength, float t)
        {
            return Mathf.Clamp(Mathf.RoundToInt(t * (arrayLength - 1)), 0, arrayLength - 1);
        }
    }
}