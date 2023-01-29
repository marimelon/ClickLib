using System;

using ClickLib.Attributes;
using ClickLib.Bases;
using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks;

/// <summary>
/// Addon TripleTriadRequest.
/// </summary>
public sealed unsafe class ClickTripleTriadRequest : ClickBase<ClickTripleTriadRequest, AddonTripleTriadRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ClickTripleTriadRequest"/> class.
    /// </summary>
    /// <param name="addon">Addon pointer.</param>
    public ClickTripleTriadRequest(IntPtr addon = default)
        : base("TripleTriadRequest", addon)
    {
    }

    public static implicit operator ClickTripleTriadRequest(IntPtr addon) => new(addon);

    /// <summary>
    /// Instantiate this click using the given addon.
    /// </summary>
    /// <param name="addon">Addon to reference.</param>
    /// <returns>A click instance.</returns>
    public static ClickTripleTriadRequest Using(IntPtr addon) => new(addon);

    /// <summary>
    /// Click the challenge button.
    /// </summary>
    [ClickName("triple_triad_request_challenge")]
    public void Rematch()
        => this.ClickAddonButton(this.Addon->ChallengeButton, 1);

    /// <summary>
    /// Click the quit button.
    /// </summary>
    [ClickName("triple_triad_request_quit")]
    public void Quit()
        => this.ClickAddonButton(this.Addon->QuitButton, 2);
}
