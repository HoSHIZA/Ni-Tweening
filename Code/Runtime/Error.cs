using System;
using System.Runtime.CompilerServices;

namespace NiGames.Tweening
{
    public static class Error
    {
        [MethodImpl(256)]
        public static void IsNull<T>(T target)
            where T : class
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }
        }
        
        [MethodImpl(256)]
        public static void IsNull<T>(T target, string message)
            where T : class
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target), message);
            }
        }
        
        [MethodImpl(256)]
        public static void IsNullOrEmpty(string target)
        {
            if (string.IsNullOrEmpty(target))
            {
                throw new ArgumentNullException(nameof(target));
            }
        }
    }
}