namespace NiGames.Tweening
{
    public interface ITweenAdapter<T, TOptions>
        where T : unmanaged
        where TOptions : unmanaged, ITweenOptions
    {
        T Evaluate(ref T from, ref T to, ref TOptions options, in float t);
    }
}