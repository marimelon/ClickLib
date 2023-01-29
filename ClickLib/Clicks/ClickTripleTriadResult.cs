using System;

using ClickLib.Attributes;
using ClickLib.Bases;
using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks;

/// <summary>
/// Addon TripleTriadResult.
/// </summary>
public sealed unsafe class ClickTripleTriadResult : ClickBase<ClickTripleTriadResult, AddonTripleTriadResult>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ClickTripleTriadResult"/> class.
    /// </summary>
    /// <param name="addon">Addon pointer.</param>
    public ClickTripleTriadResult(IntPtr addon = default)
        : base("TripleTriadResult", addon)
    {
    }

    public static implicit operator ClickTripleTriadResult(IntPtr addon) => new(addon);

    /// <summary>
    /// Instantiate this click using the given addon.
    /// </summary>
    /// <param name="addon">Addon to reference.</param>
    /// <returns>A click instance.</returns>
    public static ClickTripleTriadResult Using(IntPtr addon) => new(addon);

    /// <summary>
    /// Click the rematch button.
    /// </summary>
    [ClickName("triple_triad_result_rematch")]
    public void Rematch()
        => this.ClickAddonButton(this.Addon->RematchButton, 1);

    /// <summary>
    /// Click the quit button.
    /// </summary>
    [ClickName("triple_triad_result_quit")]
    public void Quit()
        => this.ClickAddonButton(this.Addon->QuitButton, 2);
}
