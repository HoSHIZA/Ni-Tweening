using System.Runtime.CompilerServices;

namespace NiGames.Tweening
{
    public static class NiTweenManagedDataExtensions
    {
        [MethodImpl(256)]
        public static void InvokeStart<T, TOptions, TAdapter>(this NiTweenManagedData managedData, ref NiTweenData<T, TOptions> data) 
            where T : unmanaged
            where TOptions : unmanaged, ITweenOptions 
            where TAdapter : unmanaged, ITweenAdapter<T, TOptions> 
        {
            managedData
                .InvokeValueUpdate(default(TAdapter)
                .Evaluate(ref data.From, ref data.To, ref data.Options, managedData.Ease.Evaluate(0f)));
        }

        [MethodImpl(256)]
        public static void InvokeEnd<T, TOptions, TAdapter>(this NiTweenManagedData managedData, ref NiTweenData<T, TOptions> data)
            where T : unmanaged
            where TOptions : unmanaged, ITweenOptions 
            where TAdapter : unmanaged, ITweenAdapter<T, TOptions> 
        {
            managedData
                .InvokeValueUpdate(default(TAdapter)
                .Evaluate(ref data.From, ref data.To, ref data.Options, managedData.Ease.Evaluate(1f)));
        }
        
        [MethodImpl(256)]
        public static void InvokeUpdate<T, TOptions, TAdapter>(this NiTweenManagedData managedData, ref NiTweenData<T, TOptions> data, float t)
            where T : unmanaged
            where TOptions : unmanaged, ITweenOptions 
            where TAdapter : unmanaged, ITweenAdapter<T, TOptions> 
        {
            managedData
                .InvokeValueUpdate(default(TAdapter)
                .Evaluate(ref data.From, ref data.To, ref data.Options, managedData.Ease.Evaluate(t)));
        }
    }
}