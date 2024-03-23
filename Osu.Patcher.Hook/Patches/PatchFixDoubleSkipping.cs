using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using HarmonyLib;
using JetBrains.Annotations;
using Osu.Stubs;

namespace Osu.Patcher.Hook.Patches;

/// <summary>
///     Fix the double skipping logic for storyboards (skip first to start of storyboard, then map).
///     <br /><br />
///     Changes the following in <c>Player:AllowDoubleSkip.get</c> from
///     <code><![CDATA[
///         int leadIn = leadInTime < 10000 ? -leadInTime : 0;
///     ]]></code>
///     To:
///     <code><![CDATA[
///         if (!EventManager.ShowStoryboard) return;
///         int leadIn = leadInTime < 0 ? -leadInTime : 0;
///     ]]></code>
/// </summary>
[HarmonyPatch]
[UsedImplicitly]
internal class PatchFixDoubleSkipping : BasePatch
{
    [UsedImplicitly]
    [HarmonyTargetMethod]
    private static MethodBase Target() => Player.GetAllowDoubleSkip.Reference;

    /// <summary>
    ///     Prefix patch to disable double skipping if the storyboard is disabled.
    /// </summary>
    [HarmonyPrefix]
    [UsedImplicitly]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    private static bool Before(ref bool __result)
    {
        if (!EventManager.ShowStoryboard.Get())
            return __result = false;

        return true;
    }

    /// <summary>
    ///     Replace the instruction that loads the integer 10000 with one that loads 0.
    /// </summary>
    [UsedImplicitly]
    [HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) =>
        instructions.Manipulator(
            inst => inst.OperandIs(10000),
            inst => inst.operand = 0
        );

    [UsedImplicitly]
    [HarmonyFinalizer]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    private static void Finalizer(Exception? __exception)
    {
        if (__exception != null)
        {
            Console.WriteLine($"Exception due to {nameof(PatchFixDoubleSkipping)}: {__exception}");
        }
    }
}