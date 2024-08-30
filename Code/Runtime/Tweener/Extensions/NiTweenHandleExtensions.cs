using System.Collections;
using UnityEngine;

namespace NiGames.Tweening
{
    public static class NiTweenHandleExtensions
    {
        public static bool IsActive(this NiTweenHandle handle)
        {
            return NiTweenManager.IsActive(handle);
        }
        
        public static void Complete(this NiTweenHandle handle)
        {
            NiTweenManager.Complete(handle);
        }
        
        public static void Cancel(this NiTweenHandle handle)
        {
            NiTweenManager.Cancel(handle);
        }
        
        public static void Pause(this NiTweenHandle handle)
        {
            NiTweenManager.Pause(handle);
        }
        
        public static void Resume(this NiTweenHandle handle)
        {
            NiTweenManager.Resume(handle);
        }
        
        public static void Link(this NiTweenHandle handle, GameObject target, 
            ObjectLinkBehaviour behaviour = ObjectLinkBehaviour.ContinueAfterDisable)
        {
            target.GetOrAddComponent<NiTweenObjectLink>().Link(handle, behaviour);
        }
        
        public static void Link(this NiTweenHandle handle, Component target, 
            ObjectLinkBehaviour behaviour = ObjectLinkBehaviour.ContinueAfterDisable)
        {
            target.gameObject.GetOrAddComponent<NiTweenObjectLink>().Link(handle, behaviour);
        }
        
        public static IEnumerator ToYield(this NiTweenHandle handle)
        {
            while (NiTweenManager.IsActive(handle))
            {
                yield return null;
            }
        }
        
        private static T GetOrAddComponent<T>(this GameObject gameObject) 
            where T : Component
        {
            if (gameObject.TryGetComponent<T>(out var component)) return component;
            
            component = gameObject.AddComponent<T>();

            return component;
        }
    }
}