using System.Runtime.CompilerServices;

namespace NiGames.Essentials.Unsafe
{
    internal static class UTF8Helper
    {
        public static unsafe int GetUTF8CharCount(byte* ptr, int bytes)
        {
            var end = ptr + bytes;
            var charCount = 0;
            
            while (ptr < end)
            {
                if ((*ptr & 0xC0) != 0x80)
                {
                    charCount++;
                }

                ptr++;
            }

            return charCount;
        }
        
        [MethodImpl(256)]
        public static unsafe int GetUTF8CharSize(byte* ptr)
        {
            if ((*ptr & 0x80) == 0) return 1;
            if ((*ptr & 0xE0) == 0xC0) return 2;
            if ((*ptr & 0xF0) == 0xE0) return 3;
            if ((*ptr & 0xF8) == 0xF0) return 4;
            return 1; // Invalid UTF-8
        }
    }
}