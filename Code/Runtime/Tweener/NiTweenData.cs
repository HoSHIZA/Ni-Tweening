using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using NiGames.Essentials;
using NiGames.Essentials.Unsafe;
using UnityEngine;

namespace NiGames.Tweening
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct NiTweenData<T, TOptions>
        where T : unmanaged
        where TOptions : unmanaged, ITweenOptions
    {
        public NiTweenDataCore Core;
        public TOptions Options;
        
        public T From;
        public T To;
        
        public static readonly NiTweenData<T, TOptions> Default = new()
        {
            Core = NiTweenDataCore.Default,
        };
    }
    
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct NiTweenDataCore
    {
        public TweenState State;
        
        public double Time;
        public float Duration;
        public float PlaybackSpeed;
        
        public TimeKind TimeKind;
        
        public DelayType DelayType;
        public DelayMode DelayMode;
        public float Delay;
        
        public LoopType LoopType;
        public bool AffectLoopsOnDuration;
        public int LoopCount;

        public static readonly NiTweenDataCore Default = new()
        {
            PlaybackSpeed = 1,
            AffectLoopsOnDuration = false,
            LoopCount = 1,
        };
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct NiTweenManagedData
    {
        public bool IsCallbackRunning;
        public bool CancelOnError;
        
        public Func<float, float> EaseFunction;
        public delegate*<float, float> EaseFunctionPtr;
        public AnimationCurve EaseAnimationCurve;
        
        public object FromGetter;
        public object ToGetter;
        
        public byte CallbackStates;
        public object State1;
        public object State2;
        public object State3;
        
        public object ValueUpdateAction;
        
        public object OnUpdateAction;
        public Action OnStartAction;
        public Action OnStartDelayedAction;
        public Action OnCancelAction;
        public Action OnCompleteAction;
        public Action OnPauseAction;
        public Action OnResumeAction;
        
        [MethodImpl(256)]
        public T InvokeFromGetter<T>() where T : unmanaged
        {
            return NiUnsafe.As<object, Func<T>>(ref FromGetter).Invoke();
        }
        
        [MethodImpl(256)]
        public T InvokeToGetter<T>() where T : unmanaged
        {
            return NiUnsafe.As<object, Func<T>>(ref ToGetter).Invoke();
        }
        
        [MethodImpl(256)]
        public void InvokeValueUpdate<T>(in T value) where T : unmanaged
        {
            switch (CallbackStates)
            {
                case 0: NiUnsafe.As<object, Action<T>>(ref ValueUpdateAction)?.Invoke(value); break;
                case 1: NiUnsafe.As<object, Action<T, object>>(ref ValueUpdateAction)?.Invoke(value, State1); break;
                case 2: NiUnsafe.As<object, Action<T, object, object>>(ref ValueUpdateAction)?.Invoke(value, State1, State2); break;
                case 3: NiUnsafe.As<object, Action<T, object, object, object>>(ref ValueUpdateAction)?.Invoke(value, State1, State2, State3); break;
            }
            
            NiUnsafe.As<object, Action<T>>(ref OnUpdateAction)?.Invoke(value);
        }
        
        [MethodImpl(256)]
        public void SubscribeToOnUpdateAction<T>(Action<T> callback) where T : unmanaged
        {
            NiUnsafe.As<object, Action<T>>(ref OnUpdateAction) += callback;
        }
        
        public static readonly NiTweenManagedData Default = new()
        {
            EaseFunction = Essentials.Easing.EaseFunction.Linear,
            CancelOnError = true,
        };
    }
    
    [PublicAPI]
    public enum TweenState : byte
    {
        Idle,
        Scheduled,
        Delayed,
        Running,
        Completed,
        Canceled,
    }
    
    [PublicAPI]
    public enum LoopType : byte
    {
        Restart,
        Yoyo,
    }
    
    [PublicAPI]
    public enum DelayType : byte
    {
        FirstLoop,
        EveryLoop,
    }
    
    [PublicAPI]
    public enum DelayMode : byte
    {
        AffectOnDuration,
        SkipValuesDuringDelayed,
    }
}