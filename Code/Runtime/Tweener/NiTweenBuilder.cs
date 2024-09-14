using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using NiGames.Essentials;
using NiGames.Essentials.Easing;
using NiGames.Essentials.Pooling.Buffer;
using NiGames.Scheduling;
using UnityEngine;

namespace NiGames.Tweening
{
    internal sealed class NiTweenBuilderBuffer<T, TOptions> : AbstractPooledBuffer<NiTweenBuilderBuffer<T, TOptions>>
        where T : unmanaged
        where TOptions : unmanaged, ITweenOptions
    {
        public IScheduler Scheduler;
        
        public NiTweenData<T, TOptions> Data;
        public NiTweenManagedData ManagedData;
        
        public bool ScheduleOnBind;
        public bool BindOnSchedule;
        
        public bool Preserve;
        
        protected override void Reset()
        {
            Scheduler = NiGames.Scheduling.Scheduler.Default;
            
            Data = NiTweenData<T, TOptions>.Default;
            ManagedData = NiTweenManagedData.Default;
            
            ScheduleOnBind = true;
            BindOnSchedule = true;
            
            Preserve = false;
        }
    }
    
    [PublicAPI]
    public struct NiTweenBuilder<T, TOptions, TAdapter> : IDisposable
        where T : unmanaged
        where TOptions : unmanaged, ITweenOptions
        where TAdapter : unmanaged, ITweenAdapter<T, TOptions>
    {
        internal ushort Revision;
        internal NiTweenBuilderBuffer<T, TOptions> Buffer;
        
        internal NiTweenBuilder(NiTweenBuilderBuffer<T, TOptions> buffer)
        {
            Revision = buffer.Revision;
            Buffer = buffer;
        }
        
        #region Creation
        
        [MethodImpl(256)]
        public static NiTweenBuilder<T, TOptions, TAdapter> Create(float duration)
        {
            var buffer = NiTweenBuilderBuffer<T, TOptions>.GetPooled();
            buffer.Data.Core.Duration = duration;
            
            return new NiTweenBuilder<T, TOptions, TAdapter>(buffer);
        }

        [MethodImpl(256)]
        public static NiTweenBuilder<T, TOptions, TAdapter> Create(T to, float duration)
        {
            var buffer = NiTweenBuilderBuffer<T, TOptions>.GetPooled();
            buffer.Data.To = to;
            buffer.Data.Core.Duration = duration;
            
            return new NiTweenBuilder<T, TOptions, TAdapter>(buffer);
        }

        [MethodImpl(256)]
        public static NiTweenBuilder<T, TOptions, TAdapter> Create(T from, T to, float duration)
        {
            var buffer = NiTweenBuilderBuffer<T, TOptions>.GetPooled();
            buffer.Data.From = from;
            buffer.Data.To = to;
            buffer.Data.Core.Duration = duration;
            
            return new NiTweenBuilder<T, TOptions, TAdapter>(buffer);
        }
        
        #endregion
        
        #region Building - From, To
        
        /// <summary>
        /// Sets the value of <c>From</c>.
        /// </summary>
        [MethodImpl(256)]
        public readonly NiTweenBuilder<T, TOptions, TAdapter> From(T value)
        {
            ValidateBuffer();

            Buffer.ManagedData.FromGetter = null;
            Buffer.Data.From = value;
            
            return this;
        }
        
        /// <summary>
        /// Sets the <c>From</c> value using <c>getter</c> at the time the tween starts after the delay.
        /// </summary>
        [MethodImpl(256)]
        public readonly NiTweenBuilder<T, TOptions, TAdapter> From(Func<T> getter)
        {
            ValidateBuffer();
            
            Buffer.ManagedData.FromGetter = getter;
            Buffer.Data.From = default;
            
            return this;
        }
        
        /// <summary>
        /// Sets the value of <c>To</c>.
        /// </summary>
        [MethodImpl(256)]
        public readonly NiTweenBuilder<T, TOptions, TAdapter> To(T value)
        {
            ValidateBuffer();

            Buffer.ManagedData.ToGetter = null;
            Buffer.Data.To = value;
            
            return this;
        }
        
        /// <summary>
        /// Sets the <c>To</c> value using <c>getter</c> at the time the tween starts after the delay.
        /// </summary>
        [MethodImpl(256)]
        public readonly NiTweenBuilder<T, TOptions, TAdapter> To(Func<T> getter)
        {
            ValidateBuffer();
            
            Buffer.ManagedData.ToGetter = getter;
            Buffer.Data.To = default;
            
            return this;
        }
        
        #endregion
        
        #region Building - With{...}
        
        /// <summary>
        /// Sets <c>Ease</c> using Enum.
        /// </summary>
        [MethodImpl(256)]
        public readonly NiTweenBuilder<T, TOptions, TAdapter> WithEase(Ease ease)
        {
            ValidateBuffer();

            Buffer.ManagedData.Ease = ease;
            
            return this;
        }
        
        /// <summary>
        /// Sets <c>Ease</c> with Enum, using type and power.
        /// </summary>
        [MethodImpl(256)]
        public readonly NiTweenBuilder<T, TOptions, TAdapter> WithEase(EaseType type, EasePower power)
        {
            ValidateBuffer();
            
            Buffer.ManagedData.Ease = EaseUtility.GetFunction(type, power);
            
            return this;
        }
        
        /// <summary>
        /// Sets <c>Ease</c> with <see cref="EaseData"/>.
        /// </summary>
        [MethodImpl(256)]
        public readonly NiTweenBuilder<T, TOptions, TAdapter> WithEase(EaseData ease)
        {
            ValidateBuffer();
            
            Buffer.ManagedData.Ease = ease;
            
            return this;
        }
        
        /// <summary>
        /// Sets <c>Ease</c> with AnimationCurve.
        /// </summary>
        [MethodImpl(256)]
        public readonly NiTweenBuilder<T, TOptions, TAdapter> WithEase(AnimationCurve curve)
        {
            ValidateBuffer();

            Buffer.ManagedData.Ease = curve;
            
            return this;
        }
        
        /// <summary>
        /// Sets <c>Ease</c> using the easing function.
        /// </summary>
        [MethodImpl(256)]
        public readonly NiTweenBuilder<T, TOptions, TAdapter> WithEase(Func<float, float> easeFunction)
        {
            ValidateBuffer();
            
            Buffer.ManagedData.Ease = easeFunction;
            
            return this;
        }
        
        /// <summary>
        /// Sets the delay duration and delay type.
        /// </summary>
        [MethodImpl(256)]
        public readonly NiTweenBuilder<T, TOptions, TAdapter> WithDelay(float delay, DelayType delayType = DelayType.FirstLoop, 
            DelayMode delayMode = DelayMode.AffectOnDuration)
        {
            ValidateBuffer();
            
            Buffer.Data.Core.Delay = delay;
            Buffer.Data.Core.DelayType = delayType;
            Buffer.Data.Core.DelayMode = delayMode;
            
            return this;
        }
        
        /// <summary>
        /// Sets the count and type of loops.
        /// </summary>
        /// <param name="loops">Loop count.</param>
        /// <param name="loopType">Loop Type.</param>
        /// <param name="affectOnDuration">If <c>true</c>, the <c>duration</c> is incremented by the number of <c>loops</c>, otherwise the <c>duration</c> is the <c>total duration</c>.</param>
        [MethodImpl(256)]
        public readonly NiTweenBuilder<T, TOptions, TAdapter> WithLoops(int loops, LoopType loopType = LoopType.Restart,
            bool affectOnDuration = true)
        {
            ValidateBuffer();
            
            Buffer.Data.Core.LoopCount = Math.Max(0, loops);
            Buffer.Data.Core.LoopType = loopType;
            Buffer.Data.Core.AffectLoopsOnDuration = affectOnDuration;
            
            return this;
        }
        
        /// <summary>
        /// Sets the playback speed. Can be changed dynamically via <c>NiTweenHandle</c>.
        /// </summary>
        [MethodImpl(256)]
        public readonly NiTweenBuilder<T, TOptions, TAdapter> WithPlaybackSpeed(float speed)
        {
            ValidateBuffer();
            
            Buffer.Data.Core.PlaybackSpeed = Mathf.Max(speed, 0f);
            
            return this;
        }
        
        /// <summary>
        /// Sets custom options.
        /// </summary>
        [MethodImpl(256)]
        public readonly NiTweenBuilder<T, TOptions, TAdapter> WithOptions(TOptions options)
        {
            ValidateBuffer();
            
            Buffer.Data.Options = options;

            return this;
        }


        /// <summary>
        /// Sets up a scheduler that specifies how to update the tween.
        /// </summary>
        [MethodImpl(256)]
        public readonly NiTweenBuilder<T, TOptions, TAdapter> WithScheduler([NotNull] IScheduler scheduler)
        {
            ValidateBuffer();
            
            Buffer.Scheduler = scheduler;
            
            return this;
        }

        [MethodImpl(256)]
        public readonly NiTweenBuilder<T, TOptions, TAdapter> WithPlayerLoopScheduler(PlayerLoopTiming timing, 
            TimeKind timeKind = TimeKind.Time)
        {
            ValidateBuffer();
            
            Buffer.Scheduler = Scheduler.GetScheduler(timing, timeKind);
            
            return this;
        }

        [MethodImpl(256)]
        public readonly NiTweenBuilder<T, TOptions, TAdapter> WithEditorScheduler()
        {
#if UNITY_EDITOR
            ValidateBuffer();
            
            Buffer.Scheduler = Scheduler.Editor;
#endif
            
            return this;
        }

        /// <summary>
        /// Specifies whether to set the <c>From</c> value after binding.
        /// </summary>
        [MethodImpl(256)]
        public NiTweenBuilder<T, TOptions, TAdapter> WithBindOnSchedule(bool enable)
        {
            ValidateBuffer();
            
            Buffer.BindOnSchedule = enable;
            
            return this;
        }
        
        /// <summary>
        /// Specifies whether to start the tween immediately after binding.
        /// </summary>
        [MethodImpl(256)]
        public NiTweenBuilder<T, TOptions, TAdapter> WithScheduleOnBind(bool enable)
        {
            ValidateBuffer();

            Buffer.ScheduleOnBind = enable;
            
            return this;
        }
        
        /// <summary>
        /// Does not call <c>Dispose()</c> on binding if <c>true</c>.
        /// </summary>
        /// <remarks>
        /// <c>Dispose()</c> must be called manually to return the buffer to the pool.
        /// </remarks>
        [MethodImpl(256)]
        public readonly NiTweenBuilder<T, TOptions, TAdapter> Preserve(bool preserve = true)
        {
            ValidateBuffer();
            
            Buffer.Preserve = preserve;
            
            return this;
        }
        
        #endregion
        
        #region Building - On{...}
        
        /// <summary>
        /// Subscribes to <c>OnUpdateAction</c>. Called every time the tween is updated. Does not consider the delay.
        /// </summary>
        [MethodImpl(256)]
        public readonly NiTweenBuilder<T, TOptions, TAdapter> OnUpdate([NotNull] Action<T> callback)
        {
            ValidateBuffer();
            
            Buffer.ManagedData.SubscribeToOnUpdateAction(callback);
            
            return this;
        }
        
        /// <summary>
        /// Subscribes to <c>OnStartAction</c>. Called when the tween prepared to start.
        /// </summary>
        [MethodImpl(256)]
        public readonly NiTweenBuilder<T, TOptions, TAdapter> OnStart([NotNull] Action callback)
        {
            ValidateBuffer();
            
            Buffer.ManagedData.OnStartAction += callback;
            
            return this;
        }
        
        /// <summary>
        /// Subscribes to <c>OnStartDelayedAction</c>. Called when the tween starts after delay.
        /// </summary>
        [MethodImpl(256)]
        public readonly NiTweenBuilder<T, TOptions, TAdapter> OnStartDelayed([NotNull] Action callback)
        {
            ValidateBuffer();
            
            Buffer.ManagedData.OnStartDelayedAction += callback;
            
            return this;
        }
        
        /// <summary>
        /// Subscribes to <c>OnCancelAction</c>. Called when the tween is canceled.
        /// </summary>
        [MethodImpl(256)]
        public readonly NiTweenBuilder<T, TOptions, TAdapter> OnCancel([NotNull] Action callback)
        {
            ValidateBuffer();
            
            Buffer.ManagedData.OnCancelAction += callback;
            
            return this;
        }

        /// <summary>
        /// Subscribes to <c>OnCompleteAction</c>. Called when the tween completes.
        /// </summary>
        [MethodImpl(256)]
        public readonly NiTweenBuilder<T, TOptions, TAdapter> OnComplete([NotNull] Action callback)
        {
            ValidateBuffer();
            
            Buffer.ManagedData.OnCompleteAction += callback;
            
            return this;
        }
        
        /// <summary>
        /// Subscribes to <c>OnPauseAction</c>. Called when the tween is paused.
        /// </summary>
        [MethodImpl(256)]
        public readonly NiTweenBuilder<T, TOptions, TAdapter> OnPause([NotNull] Action callback)
        {
            ValidateBuffer();
            
            Buffer.ManagedData.OnPauseAction += callback;
            
            return this;
        }
        
        /// <summary>
        /// Subscribes to <c>OnPauseAction</c>. Called when the tween is resumed.
        /// </summary>
        [MethodImpl(256)]
        public readonly NiTweenBuilder<T, TOptions, TAdapter> OnResume([NotNull] Action callback)
        {
            ValidateBuffer();
            
            Buffer.ManagedData.OnResumeAction += callback;
            
            return this;
        }

        #endregion
        
        #region Conversions
        
        /// <summary>
        /// Converts to <c>NiTweenBuilder</c>. Used to create new <c>NiTweenBuilder</c> using settings from <c>NiTweenSharedBuilder</c>.
        /// </summary>
        [MethodImpl(256)]
        public readonly NiTweenSharedBuilder<T, TOptions, TAdapter> ToSharedBuilder()
        {
            ValidateBuffer();
            
            var preserved = Buffer.Preserve;
            var builder = Preserve();
            
            return new NiTweenSharedBuilder<T, TOptions, TAdapter>(builder, preserved);
        }

        #endregion
        
        #region Bind
        
        /// <summary>
        /// Run tween without binding.
        /// </summary>
        public NiTweenHandle RunWithoutBinding()
        {
            ValidateBuffer();
            
            if (Buffer.ScheduleOnBind)
            {
                Buffer.Data.Core.State = TweenState.Scheduled;
            }
            
            return Schedule();
        }
        
        /// <summary>
        /// Run tween with data binding.
        /// </summary>
        public NiTweenHandle Bind(Action<T> action)
        {
            ValidateBuffer();
            
            if (Buffer.ScheduleOnBind)
            {
                Buffer.Data.Core.State = TweenState.Scheduled;
            }
            
            SetCallbackData(action);
            
            return Schedule();
        }
        
        /// <summary>
        /// Run tween with data binding. Does not allocate garbage when binding.
        /// </summary>
        public NiTweenHandle BindWithState<TState>(TState state, Action<T, TState> action) 
            where TState : class
        {
            ValidateBuffer();
            
            if (Buffer.ScheduleOnBind)
            {
                Buffer.Data.Core.State = TweenState.Scheduled;
            }
            
            SetCallbackData(state, action);
            
            return Schedule();
        }
        
        /// <summary>
        /// Run tween with data binding. Does not allocate garbage when binding.
        /// </summary>
        public NiTweenHandle BindWithState<TState1, TState2>(TState1 state1, TState2 state2, Action<T, TState1, TState2> action) 
            where TState1 : class
            where TState2 : class
        {
            ValidateBuffer();
            
            if (Buffer.ScheduleOnBind)
            {
                Buffer.Data.Core.State = TweenState.Scheduled;
            }

            SetCallbackData(state1, state2, action);
            
            return Schedule();
        }
        
        /// <summary>
        /// Run tween with data binding. Does not allocate garbage when binding.
        /// </summary>
        public NiTweenHandle BindWithState<TState1, TState2, TState3>(TState1 state1, TState2 state2, TState3 state3, 
            Action<T, TState1, TState2, TState3> action) 
            where TState1 : class
            where TState2 : class
            where TState3 : class
        {
            ValidateBuffer();
            
            if (Buffer.ScheduleOnBind)
            {
                Buffer.Data.Core.State = TweenState.Scheduled;
            }
            
            SetCallbackData(state1, state2, state3, action);
            
            return Schedule();
        }
        
        [MethodImpl(256)]
        internal readonly void SetCallbackData(Action<T> action)
        {
            Buffer.ManagedData.ValueUpdateAction = action;
        }
        
        [MethodImpl(256)]
        internal readonly void SetCallbackData<TState>(TState state, Action<T, TState> action)
            where TState : class
        {
            Buffer.ManagedData.CallbackStates = 1;
            Buffer.ManagedData.State1 = state;
            Buffer.ManagedData.ValueUpdateAction = action;
        }
        
        [MethodImpl(256)]
        internal readonly void SetCallbackData<TState1, TState2>(TState1 state1, TState2 state2, Action<T, TState1, TState2> action)
            where TState1 : class
            where TState2 : class
        {
            Buffer.ManagedData.CallbackStates = 2;
            Buffer.ManagedData.State1 = state1;
            Buffer.ManagedData.State2 = state2;
            Buffer.ManagedData.ValueUpdateAction = action;
        }
        
        [MethodImpl(256)]
        internal readonly void SetCallbackData<TState1, TState2, TState3>(TState1 state1, TState2 state2, TState3 state3, 
            Action<T, TState1, TState2, TState3> action)
            where TState1 : class
            where TState2 : class
            where TState3 : class
        {
            Buffer.ManagedData.CallbackStates = 3;
            Buffer.ManagedData.State1 = state1;
            Buffer.ManagedData.State2 = state2;
            Buffer.ManagedData.State3 = state3;
            Buffer.ManagedData.ValueUpdateAction = action;
        }
        
        #endregion

        public void Dispose()
        {
            if (Buffer == null) return;
            
            NiTweenBuilderBuffer<T, TOptions>.Release(Buffer);
            
            Buffer = null;
        }

        private NiTweenHandle Schedule()
        {
            if (Buffer.BindOnSchedule && Buffer.ManagedData.ValueUpdateAction != null)
            {
                Buffer.ManagedData.InvokeStart<T, TOptions, TAdapter>(ref Buffer.Data);
            }
            
            var handle = Buffer.Scheduler != null 
                ? NiTweenManager.Schedule<T, TOptions, TAdapter>(Buffer.Scheduler, Buffer.Data, Buffer.ManagedData) 
                : NiTweenHandle.Invalid;
            
            if (!Buffer.Preserve)
            {
                Dispose();
            }
            
            return handle;
        }

        [MethodImpl(256)]
        private readonly void ValidateBuffer()
        {
            if (Buffer == null || Buffer.Revision != Revision)
            {
                throw new InvalidOperationException($"[NiTween] NiTweenBuilder<{typeof(T).Name}, {typeof(TOptions).Name}, {typeof(TAdapter).Name}> is not initialized before execution, or binding has already been done. Use Preserve() to reuse the builder.");
            }
        }
    }
}