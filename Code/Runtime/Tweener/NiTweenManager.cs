using System;
using System.Runtime.CompilerServices;
using NiGames.Essentials;
using NiGames.Essentials.Unsafe;
using NiGames.Scheduling;
using NiGames.Scheduling.Dispatchers;
using NiGames.Tweening.Scheduling;

namespace NiGames.Tweening
{
    public static class NiTweenManager
    {
        private static FastList<ITweenRepository> _repositories = new(32);
        
        public static int CurrentId { get; private set; }
        
        #region Repository Management

        /// <summary>
        /// Attempts to get a repository by <c>Id</c>, if successful sets to <c>out repository</c> repository; otherwise <c>null</c>.
        /// </summary>
        public static bool TryGetRepository<T, TOptions, TAdapter>(int id, out NiTweenRepository<T, TOptions, TAdapter> repository)
            where T : unmanaged
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<T, TOptions>
        {
            for (var i = 0; i < _repositories.Count; i++)
            {
                var repo = _repositories.ElementAt(i);
                if (repo.Id == id && repo is NiTweenRepository<T, TOptions, TAdapter> result)
                {
                    repository = result;
                    return true;
                }
            }
            
            repository = null;
            return false;
        }

        /// <summary>
        /// Sets the capacity of the list from the tween repository at the specified scheduler.
        /// </summary>
        public static void EnsureRepositoryCapacity<T, TOptions, TAdapter>(PlayerLoopTiming timing, int capacity)
            where T : unmanaged
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<T, TOptions>
        {
            TweenCache<T, TOptions, TAdapter>.EnsureRepositoryCapacity(PlayerLoopDispatcher.GetTaskRunnerId(timing), capacity);
        }

        /// <summary>
        /// Sets the capacity of the list from the tween repository at the specified scheduler.
        /// </summary>
        public static void EnsureRepositoryCapacity<T, TOptions, TAdapter>(IScheduler scheduler, int capacity)
            where T : unmanaged
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<T, TOptions>
        {
            TweenCache<T, TOptions, TAdapter>.EnsureRepositoryCapacity(scheduler, capacity);
        }

        /// <summary>
        /// Sets the capacity of the list from the tween repository for all scheduler.
        /// </summary>
        public static void EnsureRepositoryCapacity<T, TOptions, TAdapter>(int capacity)
            where T : unmanaged
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<T, TOptions>
        {
            foreach (var runnerId in TweenCache<T, TOptions, TAdapter>.Data.Keys)
            {
                TweenCache<T, TOptions, TAdapter>.EnsureRepositoryCapacity(runnerId, capacity);
            }
        }

        /// <summary>
        /// Registers a repository for management via <c>NiTweenManager</c>.
        /// </summary>
        internal static void RegisterRepository(ref ITweenRepository repository)
        {
            repository.Id = CurrentId++;
            _repositories.Add(repository);
        }
        
        /// <summary>
        /// Registers a repository for management via <c>NiTweenManager</c>.
        /// </summary>
        internal static void RegisterRepository<T>(ref T repository)
            where T : ITweenRepository
        {
            repository.Id = CurrentId++;
            _repositories.Add(NiUnsafe.As<T, ITweenRepository>(ref repository));
        }
        
        #endregion
        
        #region Tween Management
        
        /// <summary>
        /// Return <c>true</c> if the tween is active.
        /// </summary>
        public static bool IsActive(NiTweenHandle handle)
        {
            return _repositories.ElementAt(handle.Id).IsActive(handle);
        }
        
        /// <summary>
        /// Resume tween playback if it has been paused.
        /// </summary>
        public static void Resume(NiTweenHandle handle)
        {
            _repositories.ElementAt(handle.Id).Resume(handle);
        }
        
        /// <summary>
        /// Pause tween playback if active.
        /// </summary>
        public static void Pause(NiTweenHandle handle)
        {
            _repositories.ElementAt(handle.Id).Pause(handle);
        }
        
        /// <summary>
        /// Force complete tween playback.
        /// </summary>
        public static void Complete(NiTweenHandle handle)
        {
            _repositories.ElementAt(handle.Id).Complete(handle);
        }

        /// <summary>
        /// Force cancel tween playback.
        /// </summary>
        public static void Cancel(NiTweenHandle handle)
        {
            _repositories.ElementAt(handle.Id).Cancel(handle);
        }
        
        /// <summary>
        /// Returns a reference to the <c>NiTweenDataCore</c> structure of the specified tween.
        /// </summary>
        public static ref NiTweenDataCore GetDataRef(NiTweenHandle handle)
        {
            return ref _repositories.ElementAt(handle.Id).GetDataCoreRef(handle);
        }
        
        /// <summary>
        /// Returns a reference to the <c>NiTweenManagedData</c> structure of the specified tween.
        /// </summary>
        public static ref NiTweenManagedData GetManagedDataRef(NiTweenHandle handle)
        {
            return ref _repositories.ElementAt(handle.Id).GetManagedDataRef(handle);
        }
        
        /// <summary>
        /// Cancel and clear all working tweens of all types and schedulers.
        /// </summary>
        public static void CancelAll()
        {
            var span = _repositories.AsSpan();
            for (var i = 0; i < span.Length; i++)
            {
                span[i].CancelAll();
            }
        }
        
        /// <summary>
        /// Cancel and clear all running tweens of the specified type and all schedulers.
        /// </summary>
        public static void CancelAll<T, TOptions, TAdapter>()
            where T : unmanaged
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<T, TOptions>
        {
            var span = _repositories.AsSpan();
            for (var i = 0; i < span.Length; i++)
            {
                if (span[i] is NiTweenRepository<T, TOptions, TAdapter> result)
                {
                    result.CancelAll();
                }
            }
        }
        
        /// <summary>
        /// Cancel and clear all running tweens of the specified type and scheduler.
        /// </summary>
        public static void CancelAll<T, TOptions, TAdapter>(IScheduler scheduler)
            where T : unmanaged
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<T, TOptions>
        {
            if (TweenCache<T, TOptions, TAdapter>.Data.TryGetValue(scheduler.GetRunnerId(), out var cache))
            {
                cache.Repository.CancelAll();
            }
        }
        
        /// <summary>
        /// Complete and clear all working tweens of all types and schedulers.
        /// </summary>
        public static void CompleteAll()
        {
            var span = _repositories.AsSpan();
            for (var i = 0; i < span.Length; i++)
            {
                span[i].CompleteAll();
            }
        }
        
        /// <summary>
        /// Cancel and clear all running tweens of the specified type and all schedulers.
        /// </summary>
        public static void CompleteAll<T, TOptions, TAdapter>()
            where T : unmanaged
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<T, TOptions>
        {
            var span = _repositories.AsSpan();
            for (var i = 0; i < span.Length; i++)
            {
                if (span[i] is NiTweenRepository<T, TOptions, TAdapter> result)
                {
                    result.CompleteAll();
                }
            }
        }
        
        /// <summary>
        /// Cancel and clear all running tweens of the specified type and scheduler.
        /// </summary>
        public static void CompleteAll<T, TOptions, TAdapter>(IScheduler scheduler)
            where T : unmanaged
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<T, TOptions>
        {
            if (TweenCache<T, TOptions, TAdapter>.Data.TryGetValue(scheduler.GetRunnerId(), out var cache))
            {
                cache.Repository.CompleteAll();
            }
        }
        
        #endregion
        
        internal static NiTweenHandle Schedule<T, TOptions, TAdapter>(IScheduler scheduler,
            in NiTweenData<T, TOptions> data, in NiTweenManagedData managedData)
            where T : unmanaged
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<T, TOptions>
        {
            var cache = TweenCache<T, TOptions, TAdapter>.GetOrCreate(scheduler);
            
            var repository = cache.GetOrCreateRepository();
            cache.GetOrCreateUpdateTask(scheduler);
            
            return repository.AddTween(data, managedData);
        }
        
        internal static (Type ValueType, Type OptionsType, Type AdapterType) GetTweenType(NiTweenHandle handle)
        {
            CheckRepositoryId(handle);
            
            var storageType = _repositories.ElementAt(handle.RepositoryId).GetType();
            
            var valueType = storageType.GenericTypeArguments[0];
            var optionsType = storageType.GenericTypeArguments[1];
            var adapterType = storageType.GenericTypeArguments[2];
            
            return (valueType, optionsType, adapterType);
        }
        
        [MethodImpl(256)]
        private static void CheckRepositoryId(in NiTweenHandle handle)
        {
            if (handle.RepositoryId < 0 || handle.RepositoryId >= CurrentId)
            {
                throw new ArgumentException("Invalid storage id.");
            }
        }
    }
}