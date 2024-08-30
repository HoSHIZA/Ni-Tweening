using System.Runtime.CompilerServices;
using NiGames.Essentials;
using UnityEngine;

namespace NiGames.Tweening
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public sealed class NiTweenObjectLink : MonoBehaviour
    {
        private FastList<NiTweenHandle> _continueAfterDisable;
        
        private FastList<NiTweenHandle> _completeOnDisable;
        private FastList<NiTweenHandle> _cancelOnDisable;
        
        private FastList<NiTweenHandle> _completeOnDestroy;
        private FastList<NiTweenHandle> _cancelOnDestroy;
        
        [MethodImpl(256)]
        public void Link(NiTweenHandle handle, ObjectLinkBehaviour linkBehaviour = ObjectLinkBehaviour.ContinueAfterDisable)
        {
            switch (linkBehaviour)
            {
                case ObjectLinkBehaviour.ContinueAfterDisable: _continueAfterDisable.Add(handle); break;
                case ObjectLinkBehaviour.CompleteOnDisable:    _completeOnDisable.Add(handle); break;
                case ObjectLinkBehaviour.CancelOnDisable:      _cancelOnDisable.Add(handle); break;
                case ObjectLinkBehaviour.CompleteOnDestroy:    _completeOnDestroy.Add(handle); break;
                case ObjectLinkBehaviour.CancelOnDestroy:      _cancelOnDestroy.Add(handle); break;
            }
        }
        
        private void OnEnable()
        {
            var span = _continueAfterDisable.AsSpan();
            for (var i = 0; i < span.Length; i++)
            {
                ref var handle = ref span[i];

                if (NiTweenManager.IsActive(handle))
                {
                    handle.Resume();
                }
            }
        }
        
        private void OnDisable()
        {
            var continueSpan = _continueAfterDisable.AsSpan();
            for (var i = 0; i < continueSpan.Length; i++)
            {
                ref var handle = ref continueSpan[i];

                if (NiTweenManager.IsActive(handle))
                {
                    NiTweenManager.Pause(handle);
                }
            }
            
            var completeSpan = _completeOnDisable.AsSpan();
            for (var i = 0; i < completeSpan.Length; i++)
            {
                ref var handle = ref completeSpan[i];

                if (NiTweenManager.IsActive(handle))
                {
                    NiTweenManager.Complete(handle);
                }
            }
            
            var cancelSpan = _cancelOnDisable.AsSpan();
            for (var i = 0; i < cancelSpan.Length; i++)
            {
                ref var handle = ref cancelSpan[i];

                if (NiTweenManager.IsActive(handle))
                {
                    NiTweenManager.Cancel(handle);
                }
            }
        }
        
        private void OnDestroy()
        {
            var completeSpan = _completeOnDestroy.AsSpan();
            for (var i = 0; i < completeSpan.Length; i++)
            {
                ref var handle = ref completeSpan[i];

                if (NiTweenManager.IsActive(handle))
                {
                    NiTweenManager.Complete(handle);
                }
            }
            
            var cancelSpan = _cancelOnDestroy.AsSpan();
            for (var i = 0; i < cancelSpan.Length; i++)
            {
                ref var handle = ref cancelSpan[i];

                if (NiTweenManager.IsActive(handle))
                {
                    NiTweenManager.Cancel(handle);
                }
            }
        }
    }
}