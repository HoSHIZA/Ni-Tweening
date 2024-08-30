using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NiGames.Essentials;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

#if NI_TWEEN_LOGGING
using UnityEngine;
#endif

namespace NiGames.Tweening
{
    public interface ITweenRepository
    {
        int Id { get; set; }
        int Count { get; }
        
        bool IsActive(NiTweenHandle handle);
        void Resume(NiTweenHandle handle);
        void Pause(NiTweenHandle handle);
        void Cancel(NiTweenHandle handle);
        void Complete(NiTweenHandle handle);
        void CancelAll();
        void CompleteAll();
        ref NiTweenDataCore GetDataCoreRef(NiTweenHandle handle);
        ref NiTweenManagedData GetManagedDataRef(NiTweenHandle handle);
        void Reset();
    }
    
    [StructLayout(LayoutKind.Sequential)]
    internal struct Entry
    {
        public int Next;
        public int DenseIndex;
        public int Version;
        
        public static Entry Default = new()
        {
            Next = -1,
            DenseIndex = -1,
            Version = 0,
        };
    }
    
    public sealed class NiTweenRepository<T, TOptions, TAdapter> : ITweenRepository, IDisposable
        where T : unmanaged
        where TOptions : unmanaged, ITweenOptions
        where TAdapter : unmanaged, ITweenAdapter<T, TOptions>
    {
        public int Id { get; set; }
        public int Count { get; private set; }
        
        private UnsafeList<Entry> _entries;
        private UnsafeList<int> _denseToSparseMapping;
        private FastList<NiTweenData<T, TOptions>> _tweenDataList;
        private FastList<NiTweenManagedData> _tweenManagedDataList;
        
        private int _freeEntry = -1;
        
        public Span<NiTweenData<T, TOptions>> DataSpan => _tweenDataList.AsSpan();
        public Span<NiTweenManagedData> ManagedDataSpan => _tweenManagedDataList.AsSpan();
        
        public NiTweenRepository(int initialCapacity = 8)
        {
            _entries = new UnsafeList<Entry>(initialCapacity, Allocator.Persistent);
            _denseToSparseMapping = new UnsafeList<int>(initialCapacity, Allocator.Persistent);
            _tweenDataList = new FastList<NiTweenData<T, TOptions>>(initialCapacity);
            _tweenManagedDataList = new FastList<NiTweenManagedData>(initialCapacity);
        }
        
        public NiTweenRepository<T, TOptions, TAdapter> Register()
        {
            var repository = this;
            NiTweenManager.RegisterRepository(ref repository);
            return this;
        }
        
        internal NiTweenHandle AddTween(in NiTweenData<T, TOptions> data, in NiTweenManagedData managedData)
        {
            int index;
            if (_freeEntry != -1)
            {
                index = _freeEntry;
                _freeEntry = _entries.ElementAt(index).Next;
            }
            else
            {
                index = _entries.Length;
                _entries.Add(Entry.Default);
            }
            
            var denseIndex = Count;
            Count++;
            
            _entries[index] = new Entry
            {
                Next = -1,
                DenseIndex = denseIndex,
                Version = _entries.ElementAt(index).Version + 1,
            };
            
            _denseToSparseMapping.Add(index);
            
            _tweenDataList.Add(data);
            _tweenManagedDataList.Add(managedData);
            
#if NI_TWEEN_LOGGING
            Debug.Log($"[NiTween<{typeof(T).Name}>] Tween added. Count: {Count}, Entries: {_entries.Length}, EntryIndex: {index}, DenseIndex: {denseIndex}");
#endif
            
            return new NiTweenHandle(index, Id, _entries.ElementAt(index).Version);
        }
        
        /// <summary>
        /// Removes a tween from a list of tweens using an index in a sparse list.
        /// </summary>
        internal void RemoveTweenAtSparse(int index)
        {
            if (index < 0) return;
            
            ref var entry = ref _entries.ElementAt(index);
            
            var denseIndex = entry.DenseIndex;
            
            Count--;
            
            if (denseIndex < Count)
            {
                _denseToSparseMapping[denseIndex] = _denseToSparseMapping[Count];
                _tweenDataList[denseIndex] = _tweenDataList[Count];
                _tweenManagedDataList[denseIndex] = _tweenManagedDataList[Count];
                
                for (var i = 0; i < _entries.Length; i++)
                {
                    ref var ent = ref _entries.ElementAt(i);
                    
                    if (ent.DenseIndex != Count) continue;
                    
                    ent.DenseIndex = denseIndex;
                    break;
                }
            }
            
            _denseToSparseMapping.RemoveAt(Count);
            _tweenDataList.RemoveAt(Count);
            _tweenManagedDataList.RemoveAt(Count);
            
            entry.Next = _freeEntry;
            entry.DenseIndex = -1;
            entry.Version++;
            _freeEntry = index;
            
#if NI_TWEEN_LOGGING
            Debug.Log($"[NiTween<{typeof(T).Name}>] Tween removed. Count: {Count}, Entries: {_entries.Length}, EntryIndex: {index}, DenseIndex: {denseIndex}");
#endif
        }
        
        /// <summary>
        /// Removes a tween from a list of tweens using an index in a dense list.
        /// </summary>
        internal void RemoveTweenAt(int denseIndex)
        {
            if (denseIndex < 0 || denseIndex >= Count) return;
            
            var sparseIndex = _denseToSparseMapping[denseIndex];
            
            ref var entry = ref _entries.ElementAt(sparseIndex);
            
            Count--;
            
            if (denseIndex < Count)
            {
                _denseToSparseMapping[denseIndex] = _denseToSparseMapping[Count];
                _tweenDataList[denseIndex] = _tweenDataList[Count];
                _tweenManagedDataList[denseIndex] = _tweenManagedDataList[Count];
                
                for (var i = 0; i < _entries.Length; i++)
                {
                    ref var ent = ref _entries.ElementAt(i);
                    
                    if (ent.DenseIndex != Count) continue;
                    
                    ent.DenseIndex = denseIndex;
                    break;
                }
            }
            
            _denseToSparseMapping.RemoveAt(Count);
            _tweenDataList.RemoveAt(Count);
            _tweenManagedDataList.RemoveAt(Count);
            
            entry.Next = _freeEntry;
            entry.DenseIndex = -1;
            entry.Version++;
            _freeEntry = sparseIndex;
            
#if NI_TWEEN_LOGGING
            Debug.Log($"[NiTween<{typeof(T).Name}>] Tween removed. Count: {Count}, Entries: {_entries.Length}, EntryIndex: {sparseIndex}, DenseIndex: {denseIndex}");
#endif
        }

        public void EnsureCapacity(int capacity)
        {
            if (capacity <= _entries.Length) return;
            
            var oldCapacity = _entries.Length;
            
            _entries.Resize(capacity);
            _denseToSparseMapping.SetCapacity(capacity);
            _tweenDataList.EnsureCapacity(capacity);
            _tweenManagedDataList.EnsureCapacity(capacity);
            
            for (var i = oldCapacity; i < capacity; i++)
            {
                _entries[i] = new Entry
                {
                    Next = i == capacity - 1 ? _freeEntry : i + 1,
                    DenseIndex = -1,
                    Version = 1,
                };
            }

            _freeEntry = oldCapacity;
        }

        public bool IsActive(NiTweenHandle handle)
        {
            if (!IsValidHandle(handle)) return false;
            
            ref var data = ref GetDataRef(handle);
            
            return data.Core.State is not TweenState.Completed and not TweenState.Canceled;
        }
        
        public void Resume(NiTweenHandle handle)
        {
            if (!IsValidHandle(handle)) return;
            
            ref var data = ref GetDataRef(handle);
            ref var managedData = ref GetManagedDataRef(handle);
            
            if (data.Core.State is not TweenState.Idle) return;
            
            data.Core.State = TweenState.Running;
            managedData.OnResumeAction?.Invoke();
        }
        
        public void Pause(NiTweenHandle handle)
        {
            if (!IsValidHandle(handle)) return;
            
            ref var data = ref GetDataRef(handle);
            ref var managedData = ref GetManagedDataRef(handle);
            
            if (data.Core.State is not TweenState.Running) return;
            
            data.Core.State = TweenState.Idle;
            managedData.OnPauseAction?.Invoke();
        }
        
        public void Cancel(NiTweenHandle handle)
        {
            if (!IsValidHandle(handle)) return;
            
            ref var data = ref GetDataRef(handle);
            ref var managedData = ref GetManagedDataRef(handle);
            
            data.Core.State = TweenState.Canceled;
            managedData.OnCancelAction?.Invoke();
            
            RemoveTweenAt(handle.Id);
        }
        
        public void Complete(NiTweenHandle handle)
        {
            if (!IsValidHandle(handle)) return;
            
            ref var data = ref GetDataRef(handle);
            ref var managedData = ref GetManagedDataRef(handle);
            
            data.Core.Time = data.Core.Duration;
            managedData.InvokeEnd<T, TOptions, TAdapter>(ref data);
            
            data.Core.State = TweenState.Completed;
            managedData.OnCompleteAction?.Invoke();
            
            RemoveTweenAt(handle.Id);
        }
        
        public void CancelAll()
        {
            for (var i = 0; i < Count; i++)
            {
                ref var data = ref _tweenDataList.ElementAt(i);
                ref var managedData = ref _tweenManagedDataList.ElementAt(i);
                
                data.Core.State = TweenState.Canceled;
                managedData.OnCancelAction?.Invoke();
            }
            
            Reset();
        }
        
        public void CompleteAll()
        {
            for (var i = 0; i < Count; i++)
            {
                ref var data = ref _tweenDataList.ElementAt(i);
                ref var managedData = ref _tweenManagedDataList.ElementAt(i);
                
                data.Core.Time = data.Core.Duration;
                managedData.InvokeEnd<T, TOptions, TAdapter>(ref data);
                
                data.Core.State = TweenState.Completed;
                managedData.OnCompleteAction?.Invoke();
            }
            
            Reset();
        }
        
        public ref NiTweenData<T, TOptions> GetDataRef(NiTweenHandle handle)
        {
            ThrowIfHandleInvalid(handle);

            return ref _tweenDataList.ElementAt(_entries.ElementAt(handle.Id).DenseIndex);
        }

        public ref NiTweenDataCore GetDataCoreRef(NiTweenHandle handle)
        {
            ThrowIfHandleInvalid(handle);
            
            return ref _tweenDataList.ElementAt(_entries.ElementAt(handle.Id).DenseIndex).Core;
        }
        
        public ref NiTweenManagedData GetManagedDataRef(NiTweenHandle handle)
        {
            ThrowIfHandleInvalid(handle);
            
            return ref _tweenManagedDataList.ElementAt(_entries.ElementAt(handle.Id).DenseIndex);
        }
        
        public void Reset()
        {
            for (int i = 0, length = _entries.Length; i < length; i++)
            {
                _entries[i] = new Entry
                {
                    Next = i == length - 1 ? -1 : i + 1,
                    DenseIndex = -1,
                    Version = _entries.ElementAt(i).Version + 1,
                };
            }

            _freeEntry = 0;
            Count = 0;
        }
        
        public void Dispose()
        {
            _entries.Dispose();
            _tweenDataList.Clear();
            _tweenManagedDataList.Clear();
        }

        [MethodImpl(256)]
        private void ThrowIfHandleInvalid(in NiTweenHandle handle)
        {
            if (!IsValidHandle(handle))
            {
                throw new InvalidOperationException("[NiTween] Invalid handle.");
            }
        }
        
        [MethodImpl(256)]
        private bool IsValidHandle(in NiTweenHandle handle)
        {
            return handle.RepositoryId == Id 
                && handle.Id >= 0 
                && handle.Id < _entries.Length 
                && _entries.ElementAt(handle.Id).Version == handle.Version;
        }
    }
}