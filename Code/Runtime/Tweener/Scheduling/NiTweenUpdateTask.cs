using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NiGames.Essentials;
using NiGames.Scheduling;
using Unity.Collections;
using UnityEngine;

namespace NiGames.Tweening.Scheduling
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NiTweenUpdateTask<T, TOptions, TAdapter> : IScheduledTask
        where T : unmanaged
        where TOptions : unmanaged, ITweenOptions
        where TAdapter : unmanaged, ITweenAdapter<T, TOptions>
    {
        public bool IsCompleted { get; private set; }
        public int UpdaterId { get; private set; }
        public TimeKind TimeKind => default;
        
        private double _lastTime;
        private double _lastUnscaledTime;
        private double _lastRealtime;
        
        public void Init(ref TaskWrapper wrapper, TimeKind timeKind = TimeKind.Time)
        {
            UpdaterId = wrapper.UpdaterId;
            
            wrapper.GetTimeValuesAsDouble(out _lastTime, out _lastUnscaledTime, out _lastRealtime);
        }
        
        public void Update(in double time, in double unscaledTime, in double realtime, in double _)
        {
            if (UpdaterId < 0) return;
            
            if (!TweenCache<T, TOptions, TAdapter>.Data.TryGetValue(UpdaterId, out var cache))
            {
                IsCompleted = true;
                throw new NullReferenceException($"[NiTween] NiTween Cache does not exist for the passed updater type.");
            }
            
            var repository = cache.Repository;
            var tweenCount = repository.Count;
            
            if (tweenCount == 0)
            {
                cache.DiscardUpdateTask();
                
                IsCompleted = true;
                return;
            }
            
            var dataSpan = repository.DataSpan;
            var managedDataSpan = repository.ManagedDataSpan;
            
            var deltaTime = time - _lastTime;
            var unscaledDeltaTime = unscaledTime - _lastUnscaledTime;
            var realDeltaTime = realtime - _lastRealtime;
            
            using var toRemove = new NativeList<int>(tweenCount, Allocator.Temp);
            
            for (var i = 0; i < tweenCount; i++)
            {
                ref var data = ref dataSpan[i];
                
                switch (data.Core.State)
                {
                    case TweenState.Idle: continue;
                    case TweenState.Completed or TweenState.Canceled:
                        toRemove.AddNoResize(i);
                        continue;
                }
                
                ref var managedData = ref managedDataSpan[i];
                
                var delta = data.Core.TimeKind switch
                {
                    TimeKind.Time => deltaTime,
                    TimeKind.UnscaledTime => unscaledDeltaTime,
                    _ => realDeltaTime
                };
                
                if (data.Core.State is TweenState.Scheduled)
                {
                    InitializeTween(ref data, ref managedData);
                }
                
                UpdateTween(ref data, ref managedData, delta);
            }
            
            for (var i = 0; i < toRemove.Length; i++)
            {
                repository.RemoveTweenAt(toRemove[i]);
            }
            
            _lastTime = time;
            _lastUnscaledTime = unscaledTime;
            _lastRealtime = realtime;
        }
        
        public void Dispose()
        {
            UpdaterId = default;

            _lastTime = 0;
            _lastUnscaledTime = 0;
            _lastRealtime = 0;
        }

        #region Update

        [MethodImpl(256)]
        private static void UpdateTween(ref NiTweenData<T, TOptions> data, ref NiTweenManagedData managedData, double delta)
        {
            data.Core.Time += delta * data.Core.PlaybackSpeed;

            if (data.Core.State is TweenState.Delayed)
            {
                if (data.Core.Time >= data.Core.Delay)
                {
                    RunTween(ref data, ref managedData);
                }

                return;
            }
            
            var totalDuration = data.Core.LoopCount > 0
                ? data.Core.AffectLoopsOnDuration
                    ? data.Core.Duration * data.Core.LoopCount 
                    : data.Core.Duration
                : double.PositiveInfinity;
            
            var loopDuration = data.Core.AffectLoopsOnDuration
                ? data.Core.Duration
                : data.Core.Duration / data.Core.LoopCount;
            
            if (data.Core.Time >= totalDuration)
            {
                CompleteTween(ref data, ref managedData, totalDuration, loopDuration);
                return;
            }
            
            UpdateTweenValue(ref data, ref managedData, loopDuration);
        }

        [MethodImpl(256)]
        private static void InitializeTween(ref NiTweenData<T, TOptions> data, ref NiTweenManagedData managedData)
        {
            data.Core.State = data.Core.Delay > 0
                ? TweenState.Delayed
                : TweenState.Running;

            managedData.OnStartAction?.Invoke();

            if (data.Core.State is TweenState.Running)
            {
                RunTween(ref data, ref managedData);
            }
        }

        [MethodImpl(256)]
        private static void RunTween(ref NiTweenData<T, TOptions> data, ref NiTweenManagedData managedData)
        {
            if (managedData.FromGetter is Action<T>)
            {
                data.From = managedData.InvokeFromGetter<T>();
            }

            if (managedData.ToGetter is Action<T>)
            {
                data.To = managedData.InvokeToGetter<T>();
            }

            data.Core.State = TweenState.Running;
            managedData.OnStartDelayedAction?.Invoke();

            if (data.Core.DelayMode is DelayMode.AffectOnDuration)
            {
                data.Core.Time -= data.Core.Delay;
            }
        }

        [MethodImpl(256)]
        private static void UpdateTweenValue(ref NiTweenData<T, TOptions> data, ref NiTweenManagedData managedData, in float duration)
        {
            var currentLoop = Mathf.FloorToInt((float)(data.Core.Time / duration));
            var timeInCurrentLoop = data.Core.Time % duration;

            var t = (float)(timeInCurrentLoop / duration);

            if (data.Core.LoopType is LoopType.Yoyo && currentLoop % 2 == 1)
            {
                t = 1 - t;
            }

            managedData.InvokeUpdate<T, TOptions, TAdapter>(ref data, t);
        }

        [MethodImpl(256)]
        private static void CompleteTween(ref NiTweenData<T, TOptions> data, ref NiTweenManagedData managedData, double totalDuration, in float duration)
        {
            data.Core.Time = totalDuration;

            UpdateTweenValue(ref data, ref managedData, duration);

            data.Core.State = TweenState.Completed;
            managedData.OnCompleteAction?.Invoke();
        }

        #endregion
    }
}