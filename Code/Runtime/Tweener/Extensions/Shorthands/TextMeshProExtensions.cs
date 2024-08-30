#if HAS_TEXT_MESH_PRO
using System;
using TMPro;
using Unity.Collections;
using UnityEngine;

namespace NiGames.Tweening.Shorthands
{
    public static class TextMeshProExtensions
    {
        public static NiTweenHandle TweenText32Bytes(this TMP_Text target, 
            FixedString32Bytes to, float duration,
            Func<NiTweenBuilder<FixedString32Bytes, StringOptions, FixedString32BytesAdapter>, NiTweenBuilder<FixedString32Bytes, StringOptions, FixedString32BytesAdapter>> builder = null)
        {
            var b = NiTweenBuilder<FixedString32Bytes, StringOptions, FixedString32BytesAdapter>
                .Create(target.text, to, duration);
            
            builder?.Invoke(b);
            
            return b.BindToText(target);
        }
        
        public static NiTweenHandle TweenText64Bytes(this TMP_Text target, 
            FixedString64Bytes to, float duration,
            Func<NiTweenBuilder<FixedString64Bytes, StringOptions, FixedString64BytesAdapter>, NiTweenBuilder<FixedString64Bytes, StringOptions, FixedString64BytesAdapter>> builder = null)
        {
            var b = NiTweenBuilder<FixedString64Bytes, StringOptions, FixedString64BytesAdapter>
                .Create(target.text, to, duration);
            
            builder?.Invoke(b);
            
            return b.BindToText(target);
        }
        
        public static NiTweenHandle TweenColor(this TMP_Text target, 
            Color to, float duration,
            Func<NiTweenBuilder<Color, ColorOptions, ColorAdapter>, NiTweenBuilder<Color, ColorOptions, ColorAdapter>> builder = null)
        {
            var b = NiTweenBuilder<Color, ColorOptions, ColorAdapter>
                .Create(target.color, to, duration);
            
            builder?.Invoke(b);
            
            return b.BindToColor(target);
        }
    }
}
#endif
