using NiGames.Tweening.Helpers;
using Unity.Collections;

namespace NiGames.Tweening
{
    public readonly struct FixedString32BytesAdapter : ITweenAdapter<FixedString32Bytes, StringOptions>
    {
        public FixedString32Bytes Evaluate(ref FixedString32Bytes from, ref FixedString32Bytes to, ref StringOptions options, in float t)
        {
            var start = from;
            var end = to;
            ref var customCharacters = ref options.CustomScrambleChars;
            ref var randomState = ref options.RandomState;
            
            FixedStringHelper.Interpolate(ref start, ref end, t, out var result, 
                options.ScrambleMode, options.RichText, 
                ref randomState, ref customCharacters);

            return result;
        }
    }
    
    public readonly struct FixedString64BytesAdapter : ITweenAdapter<FixedString64Bytes, StringOptions>
    {
        public FixedString64Bytes Evaluate(ref FixedString64Bytes from, ref FixedString64Bytes to, ref StringOptions options, in float t)
        {
            var start = from;
            var end = to;
            var customCharacters = options.CustomScrambleChars;
            ref var randomState = ref options.RandomState;
            
            FixedStringHelper.Interpolate(ref start, ref end, t, out var result, 
                options.ScrambleMode, options.RichText, 
                ref randomState, ref customCharacters);
            
            return result;
        }
    }
    
    public readonly struct FixedString128BytesAdapter : ITweenAdapter<FixedString128Bytes, StringOptions>
    {
        public FixedString128Bytes Evaluate(ref FixedString128Bytes from, ref FixedString128Bytes to, ref StringOptions options, in float t)
        {
            var start = from;
            var end = to;
            var customCharacters = options.CustomScrambleChars;
            ref var randomState = ref options.RandomState;
            
            FixedStringHelper.Interpolate(ref start, ref end, t, out var result, 
                options.ScrambleMode, options.RichText, 
                ref randomState, ref customCharacters);
            
            return result;
        }
    }
    
    public readonly struct FixedString512BytesAdapter : ITweenAdapter<FixedString512Bytes, StringOptions>
    {
        public FixedString512Bytes Evaluate(ref FixedString512Bytes from, ref FixedString512Bytes to, ref StringOptions options, in float t)
        {
            var start = from;
            var end = to;
            var customCharacters = options.CustomScrambleChars;
            ref var randomState = ref options.RandomState;
            
            FixedStringHelper.Interpolate(ref start, ref end, t, out var result, 
                options.ScrambleMode, options.RichText, 
                ref randomState, ref customCharacters);
            
            return result;
        }
    }
    
    public readonly struct FixedString4096BytesAdapter : ITweenAdapter<FixedString4096Bytes, StringOptions>
    {
        public FixedString4096Bytes Evaluate(ref FixedString4096Bytes from, ref FixedString4096Bytes to, ref StringOptions options, in float t)
        {
            var start = from;
            var end = to;
            var customCharacters = options.CustomScrambleChars;
            ref var randomState = ref options.RandomState;
            
            FixedStringHelper.Interpolate(ref start, ref end, t, out var result, 
                options.ScrambleMode, options.RichText, 
                ref randomState, ref customCharacters);
            
            return result;
        }
    }
}