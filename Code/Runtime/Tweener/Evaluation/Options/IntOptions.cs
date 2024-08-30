using System;
using UnityEngine;

namespace NiGames.Tweening
{
    public enum RoundingMode : byte
    {
        Round,
        Ceil,
        Floor,
    }
    
    [Serializable]
    public struct IntOptions : ITweenOptions
    {
        public RoundingMode RoundingMode;
        
        public int Round(float value)
        {
            return RoundingMode switch
            {
                RoundingMode.Round => Mathf.RoundToInt(value),
                RoundingMode.Ceil => Mathf.CeilToInt(value),
                RoundingMode.Floor => Mathf.FloorToInt(value),
                _ => (int)value
            };
        }
    }
    
    public static partial class NiTweenBuilderExtensions
    {
        /// <summary>
        /// Specifies the rounding mode for <c>int</c> during interpolation.
        /// </summary>
        public static NiTweenBuilder<T, IntOptions, TAdapter> WithRoundingMode<T, TAdapter>(this NiTweenBuilder<T, IntOptions, TAdapter> builder, 
            RoundingMode roundingMode)
            where T : unmanaged
            where TAdapter : unmanaged, ITweenAdapter<T, IntOptions>
        {
            builder.Buffer.Data.Options.RoundingMode = roundingMode;
            
            return builder;
        }
    }
}