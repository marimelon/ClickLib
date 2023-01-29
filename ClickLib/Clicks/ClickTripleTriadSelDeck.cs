using System;

using ClickLib.Attributes;
using ClickLib.Bases;
using ClickLib.Enums;
using ClickLib.Structures;
using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks;

/// <summary>
/// Addon AddonTripleTriadSelDeck.
/// </summary>
public sealed unsafe class ClickTripleTriadSelDeck : ClickBase<ClickTripleTriadSelDeck, AddonTripleTriadSelDeck>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ClickTripleTriadSelDeck"/> class.
    /// </summary>
    /// <param name="addon">Addon pointer.</param>
    public ClickTripleTriadSelDeck(IntPtr addon = default)
        : base("TripleTriadSelDeck", addon)
    {
    }

    public static implicit operator ClickTripleTriadSelDeck(IntPtr addon) => new(addon);

    /// <summary>
    /// Instantiate this click using the given addon.
    /// </summary>
    /// <param name="addon">Addon to reference.</param>
    /// <returns>A click instance.</returns>
    public static ClickTripleTriadSelDeck Using(IntPtr addon) => new(addon);

    /// <summary>
    /// Select the item at the given index.
    /// </summary>
    /// <param name="index">Index to select.</param>
    public void Select(uint index)
    {
        var type = EventType.LIST_INDEX_CHANGE;
        var targetList = this.Addon->AtkComponentList220;

        if (index < 0 || index >= targetList->ListLength)
            throw new ArgumentOutOfRangeException(nameof(index), "List index is out of range");

        var inputData = InputData.Empty();
        inputData.Data[0] = targetList->ItemRendererList[index].AtkComponentListItemRenderer;
        inputData.Data[2] = (void*)(index | ((ulong)index << 48));

        this.ClickAddonComponent(targetList->AtkComponentBase.OwnerNode, 1, type, inputData: inputData);
    }

#pragma warning disable SA1134, SA1516, SA1600
    [ClickName("triple_triad_deck_select1")]
    public void Select1() => this.Select(0);

    [ClickName("triple_triad_deck_select2")]
    public void Select2() => this.Select(1);

    [ClickName("triple_triad_deck_select3")]
    public void Select3() => this.Select(2);

    [ClickName("triple_triad_deck_select4")]
    public void Select4() => this.Select(3);

    [ClickName("triple_triad_deck_select5")]
    public void Select5() => this.Select(4);
#pragma warning restore SA1134, SA1516, SA1600
}