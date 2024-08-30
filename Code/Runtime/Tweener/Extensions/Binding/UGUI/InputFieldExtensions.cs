using JetBrains.Annotations;
using UnityEngine.UI;

namespace NiGames.Tweening
{
    public static class InputFieldExtensions
    {
        /// <summary>
        /// Bind to <c>InputField.caretPosition</c>.
        /// </summary>
        public static NiTweenHandle BindToCaretPosition<TOptions, TAdapter>(this NiTweenBuilder<int, TOptions, TAdapter> builder,
            [NotNull] InputField inputField) 
            where TOptions : unmanaged, ITweenOptions
            where TAdapter : unmanaged, ITweenAdapter<int, TOptions>
        {
            Error.IsNull(inputField);

            return builder.BindWithState(inputField, static (v, target) =>
            {
                target.caretPosition = v;
            });
        }
    }
}