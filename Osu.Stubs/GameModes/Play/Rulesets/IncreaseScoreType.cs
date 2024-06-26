using JetBrains.Annotations;
using Osu.Stubs.GameplayElements.Scoring.Processors;
using Osu.Utils.Lazy;

namespace Osu.Stubs.GameModes.Play.Rulesets;

[PublicAPI]
public class IncreaseScoreType
{
    // For HitCircles, the only IST emitted is the final hit result (Osu50, Osu100, Osu300, OsuMiss)

    // For OsuSliders, an IST is emitted for the slider head, slider ticks, slider end, and the overall hit result.
    // Slider head values: If hit within any timing window, then OsuSliderHead, otherwise OsuSliderHeadMiss
    // Slider ticks: If properly tracked, then OsuSliderTick, otherwise OsuSliderTickMiss
    // Slider end: If properly tracked, then OsuSliderEnd, otherwise OsuSliderEndMiss
    // Final result: Any of the values that are emitted by HitCircle. This is the only IST from sliders that is tracked in scores.

    // This can be combined with any Osu300,Osu100,Osu50 if a significant amount of the combo
    // was missed but the combo end object was hit
    public const int OsuComboEndSmall = 1 << 0;
    public const int OsuComboEndMedium = 1 << 1; // Same as above but more of the combo was hit
    public const int OsuComboEndFull = 1 << 2; // Same as above but the entire combo was 300s
    public const int OsuComboModifiers = OsuComboEndSmall | OsuComboEndMedium | OsuComboEndFull;

    public const int OsuSliderTick = 1 << 3;
    public const int OsuSliderHead = 1 << 6;
    public const int OsuSliderEnd = 1 << 7;
    public const int OsuSliderHeadMiss = -0x40000;
    public const int OsuSliderTickMiss = -0x40000;
    public const int OsuSliderEndMiss = -0x80000;

    public const int Osu50 = 1 << 8;
    public const int Osu100 = 1 << 9;
    public const int Osu300 = 1 << 10;
    public const int OsuMiss = -0x20000;

    /// <summary>
    ///     Used as the first parameter in another method: <c>ScoreChange::ScoreChange(IncreaseScoreType, ...)</c>
    ///     Original: <c>osu.GameModes.Play.Rulesets.IncreaseScoreType</c>
    ///     b20240123: <c>#=zGMiEmtRx7tdNjrx8B18dVB33Br1S9OJ2_XDs0XJSAtWZ</c>
    /// </summary>
    [Stub]
    public static readonly LazyType Class = new(
        "osu.GameModes.Play.Rulesets.IncreaseScoreType",
        () => ScoreChange.Constructor.Reference
            .GetParameters()[0]
            .ParameterType
    );
}