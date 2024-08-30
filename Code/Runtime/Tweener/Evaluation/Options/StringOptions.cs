using System;
using Unity.Collections;
using Random = Unity.Mathematics.Random;

namespace NiGames.Tweening
{
    public enum ScrambleMode : byte
    {
        None,
        /// <summary>A-Z</summary>
        Uppercase,
        /// <summary>a-z</summary>
        Lowercase,
        /// <summary>0-9</summary>
        Numerals,
        /// <summary>A-Z, a-z, 0-9</summary>
        All,
        Custom,
    }
    
    [Serializable]
    public struct StringOptions : ITweenOptions
    {
        public ScrambleMode ScrambleMode;
        public FixedString64Bytes CustomScrambleChars;
        public Random RandomState;
        public bool RichText;
    }
    
    public static partial class NiTweenBuilderExtensions
    {
        /// <summary>
        /// Specify the random number seed used to display scramble characters.
        /// </summary>
        public static NiTweenBuilder<T, StringOptions, TAdapter> WitHRichText<T, TAdapter>(this NiTweenBuilder<T, StringOptions, TAdapter> builder, 
            bool enabled = true)
            where T : unmanaged
            where TAdapter : unmanaged, ITweenAdapter<T, StringOptions>
        {
            builder.Buffer.Data.Options.RichText = enabled;
            
            return builder;
        }
        
        /// <summary>
        /// Specify the random number seed used to display scramble characters.
        /// </summary>
        public static NiTweenBuilder<T, StringOptions, TAdapter> WithRandomSeed<T, TAdapter>(this NiTweenBuilder<T, StringOptions, TAdapter> builder, 
            uint seed)
            where T : unmanaged
            where TAdapter : unmanaged, ITweenAdapter<T, StringOptions>
        {
            builder.Buffer.Data.Options.RandomState = new Random(seed);
            
            return builder;
        }
        
        /// <summary>
        /// Fills in characters not yet displayed with random characters, based on <c>ScrambleMode</c>.
        /// </summary>
        public static NiTweenBuilder<T, StringOptions, TAdapter> WithScrambleMode<T, TAdapter>(this NiTweenBuilder<T, StringOptions, TAdapter> builder, 
            ScrambleMode scrambleMode)
            where T : unmanaged
            where TAdapter : unmanaged, ITweenAdapter<T, StringOptions>
        {
            builder.Buffer.Data.Options.ScrambleMode = scrambleMode;
            
            return builder;
        }
        
        /// <summary>
        /// Fills in characters not yet displayed with random characters, based on <c>ScrambleMode</c>.
        /// </summary>
        public static NiTweenBuilder<T, StringOptions, TAdapter> WithScrambleMode<T, TAdapter>(this NiTweenBuilder<T, StringOptions, TAdapter> builder, 
            ScrambleMode scrambleMode, FixedString64Bytes customScrambleCharacters)
            where T : unmanaged
            where TAdapter : unmanaged, ITweenAdapter<T, StringOptions>
        {
            builder.Buffer.Data.Options.ScrambleMode = scrambleMode;
            builder.Buffer.Data.Options.CustomScrambleChars = customScrambleCharacters;
            
            return builder;
        }
    }
}