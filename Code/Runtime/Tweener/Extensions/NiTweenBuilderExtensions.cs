using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace NiGames.Tweening
{
    public static partial class NiTweenBuilderExtensions
    {
        /// <summary>
        /// Outputs the current value every update using <c>Debug.Log</c>.
        /// </summary>
        public static NiTweenBuilder<T, TOptions, TAdapter> WithUnityLogger<T, TOptions, TAdapter>(this NiTweenBuilder<T, TOptions, TAdapter> builder, 
            LogType logType = LogType.Log, Object context = null)
            where T : unmanaged
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<T, TOptions>
        {
            return builder.OnUpdate(v =>
            {
                var message = v.ToString();
                
                switch (logType)
                {
                    case LogType.Log:        Debug.Log(message, context); break;
                    case LogType.Warning:    Debug.LogWarning(message, context); break;
                    case LogType.Assert:     Debug.LogAssertion(message, context); break;
                    case LogType.Exception:
                    case LogType.Error:      Debug.LogError(message, context); break;
                }
            });
        }

        /// <summary>
        /// Outputs a message every update using <c>Debug.Log</c>.
        /// </summary>
        public static NiTweenBuilder<T, TOptions, TAdapter> WithUnityLogger<T, TOptions, TAdapter>(this NiTweenBuilder<T, TOptions, TAdapter> builder, 
            Func<T, string> message, LogType logType = LogType.Log, Object context = null)
            where T : unmanaged
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<T, TOptions>
        {
            return builder.OnUpdate(v =>
            {
                var messageText = message.Invoke(v);
                
                switch (logType)
                {
                    case LogType.Log:        Debug.Log(messageText, context); break;
                    case LogType.Warning:    Debug.LogWarning(messageText, context); break;
                    case LogType.Assert:     Debug.LogAssertion(messageText, context); break;
                    case LogType.Exception:
                    case LogType.Error:      Debug.LogError(messageText, context); break;
                }
            });
        }

        /// <summary>
        /// Enables forced repaint of the editor on every update.
        /// </summary>
        public static NiTweenBuilder<T, TOptions, TAdapter> WithForceEditorRepaint<T, TOptions, TAdapter>(this NiTweenBuilder<T, TOptions, TAdapter> builder)
            where T : unmanaged
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<T, TOptions>
        {
#if UNITY_EDITOR
            return builder.OnUpdate(v =>
            {
                UnityEditor.EditorApplication.QueuePlayerLoopUpdate();
                UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
            });
#endif
        }
        
#if KDEBUGGER
        public static NiTweenBuilder<T, TOptions, TAdapter> WithOnScreenLogger<T, TOptions, TAdapter>(this NiTweenBuilder<T, TOptions, TAdapter> builder)
            where T : unmanaged
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<T, TOptions>
        {
            return builder;
        }
#endif
    }
}