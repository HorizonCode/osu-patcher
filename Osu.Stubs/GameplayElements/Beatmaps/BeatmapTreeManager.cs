using JetBrains.Annotations;
using Osu.Stubs.GameModes.Select;
using Osu.Utils.Lazy;

namespace Osu.Stubs.GameplayElements.Beatmaps;

/// <summary>
///     Original: <c>osu.GameplayElements.Beatmaps.BeatmapTreeManager</c>
///     b20240102.2: <c>#=zV51QPv13Z_vZJRxEY28cvGye77gU6YZQsv_F5muuWuN62V5sIQ==</c>
/// </summary>
[PublicAPI]
public static class BeatmapTreeManager
{
    /// <summary>
    ///     Original: <c>CurrentGroupMode</c> of type <c>Bindable{TreeGroupMode}</c>
    ///     b20240102.2: <c>#=zbF4rnAiPRGJl</c>
    /// </summary>
    [Stub]
    public static readonly LazyField<object> CurrentGroupMode = new(
        "osu.GameplayElements.Beatmaps.BeatmapTreeManager::CurrentGroupMode",
        () => SongSelection.FindReferences().CurrentGroupMode
    );
}