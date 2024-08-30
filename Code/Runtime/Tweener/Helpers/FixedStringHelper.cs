using System.Runtime.CompilerServices;
using NiGames.Essentials.Unsafe;
using Unity.Collections;
using Unity.Mathematics;
using Random = Unity.Mathematics.Random;

namespace NiGames.Tweening.Helpers
{
    internal static class FixedStringHelper
    {
        public static unsafe void Interpolate<T>(ref T from, ref T to, float t, out T result, ScrambleMode scrambleMode, 
            bool richText, ref Random random, ref FixedString64Bytes customScrambleCharacters)
            where T : unmanaged, INativeList<byte>, IUTF8Bytes
        {
            result = new T();
            
            // if (richText)
            {
                // TODO: Not Implemented
            }
            // else
            {
                var fromOffset = 0;
                var fromPtr = from.GetUnsafePtr();
                var fromLength = UTF8Helper.GetUTF8CharCount(fromPtr, from.Length);
                
                var toOffset = 0;
                var toPtr = to.GetUnsafePtr();
                var toLength = UTF8Helper.GetUTF8CharCount(toPtr, to.Length);
                
                var resultLength = math.max(fromLength, toLength);
                var currentTextLength = (int)math.round(resultLength * t);
                
                for (var i = 0; i < resultLength; i++)
                {
                    var fromRune = from.Read(ref fromOffset);
                    var toRune = to.Read(ref toOffset);
                    
                    if (i < currentTextLength)
                    {
                        if (toRune.value != 0)
                        {
                            result.Append(toRune);
                        }
                    }
                    else
                    {
                        if (fromRune.value != 0)
                        {
                            result.Append(fromRune);
                        }
                    }
                }

                FillScrambleChars(ref result, scrambleMode, ref random, ref customScrambleCharacters, resultLength - currentTextLength);
            }
        }

        [MethodImpl(256)]
        private static unsafe void FillScrambleChars<T>(ref T target, ScrambleMode scrambleMode, 
            ref Random random, ref FixedString64Bytes customScrambleCharacters, int count)
            where T : unmanaged, INativeList<byte>, IUTF8Bytes
        {
            if (scrambleMode is ScrambleMode.None) return;
            
            if (random.state == 0)
            {
                random.InitState();
            }
            
            if (scrambleMode is ScrambleMode.Custom)
            {
                var ptr = customScrambleCharacters.GetUnsafePtr();
                var customCharactersLength = UTF8Helper.GetUTF8CharCount(ptr, customScrambleCharacters.Length);
                
                var enumerator = customScrambleCharacters.GetEnumerator();
                for (var i = 0; i < count; i++)
                {
                    var index = random.NextInt(0, customCharactersLength);
                    for (var j = 0; j < customCharactersLength; j++)
                    {
                        if (enumerator.MoveNext() && j == index)
                        {
                            target.Append(enumerator.Current);
                            break;
                        }
                    }
                }
            }
            else
            {
                for (var i = 0; i < count; i++)
                {
                    var chr = (char)GetScrambledChar(scrambleMode, ref random, ref customScrambleCharacters);
                    
                    target.Append(chr);
                }
            }
        }
        
        private static byte GetScrambledChar(ScrambleMode mode, ref Random random, ref FixedString64Bytes customChars)
        {
            return mode switch
            {
                ScrambleMode.Uppercase => (byte)random.NextInt('A', 'Z' + 1),
                ScrambleMode.Lowercase => (byte)random.NextInt('a', 'z' + 1),
                ScrambleMode.Numerals => (byte)random.NextInt('0', '9' + 1),
                ScrambleMode.All => (byte)random.NextInt(33, 127),
                ScrambleMode.Custom => customChars.Length > 0 
                    ? customChars[random.NextInt(0, customChars.Length)] 
                    : default,
                _ => default,
            };
        }
    }
}