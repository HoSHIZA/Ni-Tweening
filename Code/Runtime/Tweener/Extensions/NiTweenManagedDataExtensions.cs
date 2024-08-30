using System.Runtime.CompilerServices;
using NiGames.Essentials.Easing;

namespace NiGames.Tweening
{
    public static class NiTweenManagedDataExtensions
    {
        [MethodImpl(256)]
        public static unsafe float Ease(this NiTweenManagedData managedData, float t)
        {
            return managedData.EaseFunction?.Invoke(t) ?? (
                managedData.EaseAnimationCurve?.Evaluate(t) ?? (
                    managedData.EaseFunctionPtr != null 
                        ? managedData.EaseFunctionPtr(t) 
                        : EaseFunction.Linear(t)));
        }
        
        [MethodImpl(256)]
        public static void InvokeStart<T, TOptions, TAdapter>(this NiTweenManagedData managedData, ref NiTweenData<T, TOptions> data) 
            where T : unmanaged
            where TOptions : unmanaged, ITweenOptions 
            where TAdapter : unmanaged, ITweenAdapter<T, TOptions> 
        {
            managedData
                .InvokeValueUpdate(default(TAdapter)
                .Evaluate(ref data.From, ref data.To, ref data.Options, managedData.Ease(0f)));
        }

        [MethodImpl(256)]
        public static void InvokeEnd<T, TOptions, TAdapter>(this NiTweenManagedData managedData, ref NiTweenData<T, TOptions> data)
            where T : unmanaged
            where TOptions : unmanaged, ITweenOptions 
            where TAdapter : unmanaged, ITweenAdapter<T, TOptions> 
        {
            managedData
                .InvokeValueUpdate(default(TAdapter)
                .Evaluate(ref data.From, ref data.To, ref data.Options, managedData.Ease(1f)));
        }
        
        [MethodImpl(256)]
        public static void InvokeUpdate<T, TOptions, TAdapter>(this NiTweenManagedData managedData, ref NiTweenData<T, TOptions> data, float t)
            where T : unmanaged
            where TOptions : unmanaged, ITweenOptions 
            where TAdapter : unmanaged, ITweenAdapter<T, TOptions> 
        {
            managedData
                .InvokeValueUpdate(default(TAdapter)
                .Evaluate(ref data.From, ref data.To, ref data.Options, managedData.Ease(t)));
        }
    }
}