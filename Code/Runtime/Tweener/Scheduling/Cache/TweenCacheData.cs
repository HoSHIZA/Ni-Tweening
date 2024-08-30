using System.Runtime.CompilerServices;
using NiGames.Scheduling;

namespace NiGames.Tweening.Scheduling
{
    internal sealed class TweenCacheData<T, TOptions, TAdapter>
        where T : unmanaged
        where TOptions : unmanaged, ITweenOptions
        where TAdapter : unmanaged, ITweenAdapter<T, TOptions>
    {
        public NiTweenRepository<T, TOptions, TAdapter> Repository;
        public NiTweenUpdateTask<T, TOptions, TAdapter>? UpdateTask;

        [MethodImpl(256)]
        public NiTweenRepository<T, TOptions, TAdapter> GetOrCreateRepository()
        {
            return Repository ??= new NiTweenRepository<T, TOptions, TAdapter>().Register();
        }

        [MethodImpl(256)]
        public NiTweenUpdateTask<T, TOptions, TAdapter> GetOrCreateUpdateTask(IScheduler scheduler)
        {
            if (UpdateTask.HasValue) return UpdateTask.Value;

            GetOrCreateRepository();

            UpdateTask = new NiTweenUpdateTask<T, TOptions, TAdapter>();
            scheduler.Schedule(UpdateTask.Value);

            return UpdateTask.Value;
        }

        [MethodImpl(256)]
        public void DiscardUpdateTask()
        {
            if (!UpdateTask.HasValue) return;
            
            UpdateTask = null;
        }
    }
}