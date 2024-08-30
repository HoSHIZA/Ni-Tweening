using System.Runtime.CompilerServices;
using Unity.Collections;

namespace NiGames.Tweening
{
    public static partial class NiTween
    {
        public static class String
        {
            [MethodImpl(256)]
            public static NiTweenBuilder<FixedString32Bytes, StringOptions, FixedString32BytesAdapter> Create32Bytes(
                FixedString32Bytes from, FixedString32Bytes to, float duration, ScrambleMode scrambleMode = ScrambleMode.None)
            {
                return NiTweenBuilder<FixedString32Bytes, StringOptions, FixedString32BytesAdapter>.Create(from, to, duration)
                    .WithOptions(new StringOptions() { ScrambleMode = scrambleMode });
            }

            [MethodImpl(256)]
            public static NiTweenBuilder<FixedString64Bytes, StringOptions, FixedString64BytesAdapter> Create64Bytes(
                FixedString64Bytes from, FixedString64Bytes to, float duration, ScrambleMode scrambleMode = ScrambleMode.None)
            {
                return NiTweenBuilder<FixedString64Bytes, StringOptions, FixedString64BytesAdapter>.Create(from, to, duration)
                    .WithOptions(new StringOptions() { ScrambleMode = scrambleMode });
            }

            [MethodImpl(256)]
            public static NiTweenBuilder<FixedString128Bytes, StringOptions, FixedString128BytesAdapter> Create128Bytes(
                FixedString64Bytes from, FixedString64Bytes to, float duration, ScrambleMode scrambleMode = ScrambleMode.None)
            {
                return NiTweenBuilder<FixedString128Bytes, StringOptions, FixedString128BytesAdapter>.Create(from, to, duration)
                    .WithOptions(new StringOptions() { ScrambleMode = scrambleMode });
            }

            [MethodImpl(256)]
            public static NiTweenBuilder<FixedString512Bytes, StringOptions, FixedString512BytesAdapter> Create512Bytes(
                FixedString64Bytes from, FixedString64Bytes to, float duration, ScrambleMode scrambleMode = ScrambleMode.None)
            {
                return NiTweenBuilder<FixedString512Bytes, StringOptions, FixedString512BytesAdapter>.Create(from, to, duration)
                    .WithOptions(new StringOptions() { ScrambleMode = scrambleMode });
            }

            [MethodImpl(256)]
            public static NiTweenBuilder<FixedString4096Bytes, StringOptions, FixedString4096BytesAdapter> Create4096Bytes(
                FixedString64Bytes from, FixedString64Bytes to, float duration, ScrambleMode scrambleMode = ScrambleMode.None)
            {
                return NiTweenBuilder<FixedString4096Bytes, StringOptions, FixedString4096BytesAdapter>.Create(from, to, duration)
                    .WithOptions(new StringOptions() { ScrambleMode = scrambleMode });
            }
        }
    }
}
