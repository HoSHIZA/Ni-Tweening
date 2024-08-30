using System;
using System.Runtime.CompilerServices;

namespace NiGames.Tweening
{
    public struct NiTweenSharedBuilder<T, TOptions, TAdapter> : IDisposable
        where T : unmanaged
        where TOptions : unmanaged, ITweenOptions
        where TAdapter : unmanaged, ITweenAdapter<T, TOptions>
    {
        private NiTweenBuilder<T, TOptions, TAdapter> _builder;
        private readonly bool _preserved;
        
        public NiTweenSharedBuilder(NiTweenBuilder<T, TOptions, TAdapter> builder, bool preserved)
        {
            _builder = builder;
            _preserved = preserved;
        }
        
        /// <summary>
        /// Converts <c>NiTweenSharedBuilder</c> to <c>NiTweenBuilder</c>.
        /// </summary>
        public NiTweenBuilder<T, TOptions, TAdapter> ToBuilder()
        {
            return _builder.Preserve(_preserved);
        }
        
        #region New
        
        /// <summary>
        /// Creates a new <c>NiTweenBuilder</c> with tween data from <c>NiTweenSharedBuilder</c>.
        /// </summary>
        /// <remarks>All values from original <c>NiTweenSharedBuilder</c> is used, make sure it is greater than zero.</remarks>
        public NiTweenBuilder<T, TOptions, TAdapter> New()
        {
            var builder = NiTweenBuilder<T, TOptions, TAdapter>.Create(
                _builder.Buffer.Data.From, 
                _builder.Buffer.Data.To, 
                _builder.Buffer.Data.Core.Duration);
            
            FillBufferData(ref builder, ref _builder);
            
            return builder;
        }
        
        /// <summary>
        /// Creates a new <c>NiTweenBuilder</c> with tween data from <c>NiTweenSharedBuilder</c>.
        /// </summary>
        public NiTweenBuilder<T, TOptions, TAdapter> New(T to)
        {
            var builder = NiTweenBuilder<T, TOptions, TAdapter>.Create(_builder.Buffer.Data.From, to, _builder.Buffer.Data.Core.Duration);
            
            FillBufferData(ref builder, ref _builder);
            
            builder.Buffer.ManagedData.ToGetter = null;
            
            return builder;
        }
        
        /// <summary>
        /// Creates a new <c>NiTweenBuilder</c> with tween data from <c>NiTweenSharedBuilder</c>.
        /// </summary>
        public NiTweenBuilder<T, TOptions, TAdapter> New(T from, T to)
        {
            var builder = NiTweenBuilder<T, TOptions, TAdapter>.Create(from, to, _builder.Buffer.Data.Core.Duration);
            
            FillBufferData(ref builder, ref _builder);
            
            builder.Buffer.ManagedData.FromGetter = null;
            builder.Buffer.ManagedData.ToGetter = null;
            
            return builder;
        }

        /// <summary>
        /// Creates a new <c>NiTweenBuilder</c> with tween data from <c>NiTweenSharedBuilder</c>.
        /// </summary>
        public NiTweenBuilder<T, TOptions, TAdapter> New(T from, T to, float duration)
        {
            var builder = NiTweenBuilder<T, TOptions, TAdapter>.Create(from, to, duration);
            
            FillBufferData(ref builder, ref _builder);
            
            builder.Buffer.ManagedData.FromGetter = null;
            builder.Buffer.ManagedData.ToGetter = null;
            
            return builder;
        }

        /// <summary>
        /// Creates a new <c>NiTweenBuilder</c> with tween data from <c>NiTweenSharedBuilder</c>.
        /// </summary>
        public NiTweenBuilder<T, TOptions, TAdapter> New(float duration)
        {
            var builder = NiTweenBuilder<T, TOptions, TAdapter>.Create(_builder.Buffer.Data.From, _builder.Buffer.Data.To, duration);
            
            FillBufferData(ref builder, ref _builder);
            
            return builder;
        }

        [MethodImpl(256)]
        private static void FillBufferData(ref NiTweenBuilder<T, TOptions, TAdapter> destination, ref NiTweenBuilder<T, TOptions, TAdapter> source)
        {
            destination.Buffer.Scheduler = source.Buffer.Scheduler;
            destination.Buffer.Data.Options = source.Buffer.Data.Options;
            destination.Buffer.Data.Core = source.Buffer.Data.Core;
            destination.Buffer.ManagedData = source.Buffer.ManagedData;
            destination.Buffer.ScheduleOnBind = source.Buffer.ScheduleOnBind;
        }
        
        #endregion
        
        #region Bind
        
        /// <inheritdoc cref="NiTweenBuilder{T,TOptions,TAdapter}.RunWithoutBinding"/>
        public NiTweenHandle RunWithoutBinding()
        {
            return _builder.RunWithoutBinding();
        }
        
        /// <inheritdoc cref="NiTweenBuilder{T,TOptions,TAdapter}.BindWithState{TState}"/>
        public NiTweenHandle BindWithState<TState>(TState state, Action<T, TState> action) 
            where TState : class
        {
            return _builder.BindWithState(state, action);
        }
        
        /// <inheritdoc cref="NiTweenBuilder{T,TOptions,TAdapter}.BindWithState{TState1, TState2}"/>
        public NiTweenHandle BindWithState<TState1, TState2>(TState1 state1, TState2 state2, Action<T, TState1, TState2> action) 
            where TState1 : class
            where TState2 : class
        {
            return _builder.BindWithState(state1, state2, action);
        }
        
        /// <inheritdoc cref="NiTweenBuilder{T,TOptions,TAdapter}.BindWithState{TState1, TState2, TState3}"/>
        public NiTweenHandle BindWithState<TState1, TState2, TState3>(TState1 state1, TState2 state2, TState3 state3, 
            Action<T, TState1, TState2, TState3> action) 
            where TState1 : class
            where TState2 : class
            where TState3 : class
        {
            return _builder.BindWithState(state1, state2, state3, action);
        }
        
        #endregion
        
        public void Dispose()
        {
            if (!_builder.Buffer.Preserve) return;
            
            _builder.Dispose();
        }
    }
}