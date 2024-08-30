using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NiGames.Scheduling;

namespace NiGames.Tweening.Scheduling
{
    internal static class TweenCache<T, TOptions, TAdapter>
        where T : unmanaged
        where TOptions : unmanaged, ITweenOptions
        where TAdapter : unmanaged, ITweenAdapter<T, TOptions>
    {
        public static readonly Dictionary<int, TweenCacheData<T, TOptions, TAdapter>> Data = new(2);
        
        [MethodImpl(256)]
        public static bool TryGet(int runnerId, out TweenCacheData<T, TOptions, TAdapter> cache)
        {
            return Data.TryGetValue(runnerId, out cache);
        }
        
        public static TweenCacheData<T, TOptions, TAdapter> GetOrCreate(int runnerId)
        {
            if (TryGet(runnerId, out var cache)) return cache;
            
            Data.Add(runnerId, new TweenCacheData<T, TOptions, TAdapter>());
            
            return Data[runnerId];
        }
        
        public static TweenCacheData<T, TOptions, TAdapter> GetOrCreate(IScheduler scheduler)
        {
            var runnerId = scheduler.GetRunnerId();
            
            if (TryGet(runnerId, out var cache)) return cache;
            
            Data.Add(runnerId, new TweenCacheData<T, TOptions, TAdapter>());
            
            return Data[runnerId];
        }
        
        [MethodImpl(256)]
        public static void EnsureRepositoryCapacity(IScheduler scheduler, int capacity)
        {
            var cache = GetOrCreate(scheduler);
            var repository = cache.GetOrCreateRepository();
            repository.EnsureCapacity(capacity);
        }
        
        [MethodImpl(256)]
        public static void EnsureRepositoryCapacity(int runnerId, int capacity)
        {
            var cache = GetOrCreate(runnerId);
            var repository = cache.GetOrCreateRepository();
            repository.EnsureCapacity(capacity);
        }
    }
}