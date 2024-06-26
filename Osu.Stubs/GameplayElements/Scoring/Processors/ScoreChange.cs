using System.Linq;
using JetBrains.Annotations;
using Osu.Stubs.GameModes.Play.Rulesets;
using Osu.Utils.Lazy;

namespace Osu.Stubs.GameplayElements.Scoring.Processors;

[PublicAPI]
public static class ScoreChange
{
    /// <summary>
    ///     Used as the first parameter to another method: <c>ScoreProcessor::Add(ScoreChange, ...)</c>
    ///     Original: <c>osu.GameplayElements.Scoring.Processors.ScoreChange</c>
    ///     b20240123: <c>#=zLpbYBJJuhPuc612JcL6v88v6458xNWATpDbhSpQKC6L_</c>
    /// </summary>
    [Stub]
    public static readonly LazyType Class = new(
        "osu.GameplayElements.Scoring.Processors.ScoreChange",
        () => ScoreProcessor.AddScoreChange.Reference
            .GetParameters()[0]
            .ParameterType
    );

    /// <summary>
    ///     Original: <c>ScoreChange(...)</c>
    ///     b20240123: Same as class
    /// </summary>
    [Stub]
    public static readonly LazyConstructor Constructor = new(
        "osu.GameplayElements.Scoring.Processors.ScoreChange::ScoreChange(...)",
        () => Class.Reference
            .GetConstructors()
            .Single(ctor => ctor.GetParameters().Length == 3)
    );

    /// <summary>
    ///     Original: <c>HitValue</c>
    ///     b20240123: <c>#=zifzkx$8=</c>
    /// </summary>
    [Stub]
    public static readonly LazyField<int> HitValue = new(
        "osu.GameplayElements.Scoring.Processors.ScoreChange::HitValue",
        () => Class.Reference
            .GetFields()
            .First(field => field.FieldType == IncreaseScoreType.Class.Reference)
    );
}