using NiGames.Scheduling;

namespace NiGames.Tweening
{
    public sealed class NiTweenBuilderBuffer<T, TOptions>
        where T : unmanaged
        where TOptions : unmanaged, ITweenOptions
    {
        private static NiTweenBuilderBuffer<T, TOptions> _poolRoot = new();
        
        public ushort Revision;
        public NiTweenBuilderBuffer<T, TOptions> Next;
        
        public IScheduler Scheduler = NiGames.Scheduling.Scheduler.Default;
        
        public NiTweenData<T, TOptions> Data = NiTweenData<T, TOptions>.Default;
        public NiTweenManagedData ManagedData = NiTweenManagedData.Default;
        
        public bool ScheduleOnBind = true;
        public bool BindOnSchedule = true;
        
        public bool Preserve;
        
        public static NiTweenBuilderBuffer<T, TOptions> GetPooled()
        {
            if (_poolRoot == null) return new NiTweenBuilderBuffer<T, TOptions>();
            
            var result = _poolRoot;
            _poolRoot = _poolRoot.Next;
            result.Next = null;
            
            return result;
        }
        
        public static void Release(NiTweenBuilderBuffer<T, TOptions> buffer)
        {
            buffer.Revision++;
            
            buffer.Scheduler = NiGames.Scheduling.Scheduler.Default;
            
            buffer.Data = NiTweenData<T, TOptions>.Default;
            buffer.ManagedData = NiTweenManagedData.Default;
            
            buffer.ScheduleOnBind = true;
            buffer.BindOnSchedule = true;
            
            buffer.Preserve = default;
            
            if (buffer.Revision != ushort.MaxValue)
            {
                buffer.Next = _poolRoot;
                _poolRoot = buffer;
            }
        }
    }
}