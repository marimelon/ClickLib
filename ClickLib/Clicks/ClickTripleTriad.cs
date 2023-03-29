﻿using System;
using System.Runtime.InteropServices;

using ClickLib.Bases;
using ClickLib.Enums;
using ClickLib.Structures;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace ClickLib.Clicks;

/// <summary>
/// Addon ContentsFinderConfirm.
/// </summary>
public sealed unsafe class ClickTripleTriad : ClickBase<ClickTripleTriad, AddonTripleTriad>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ClickTripleTriad"/> class.
    /// </summary>
    /// <param name="addon">Addon pointer.</param>
    public ClickTripleTriad(IntPtr addon = default)
        : base("TripleTriad", addon)
    {
    }

    public static implicit operator ClickTripleTriad(IntPtr addon) => new(addon);

    /// <summary>
    /// Instantiate this click using the given addon.
    /// </summary>
    /// <param name="addon">Addon to reference.</param>
    /// <returns>A click instance.</returns>
    public static ClickTripleTriad Using(IntPtr addon) => new(addon);

    public void Pick(uint which)
    {
        var type = EventType.DD_DROP;
        var addonBase = &this.Addon->AtkUnitBase;
        var target = &this.Addon->AtkUnitBase.AtkEventListener;

        var eventData = EventData.ForNormalTarget(target, addonBase);
        var inputData = InputData.Empty();

        inputData.Data[1] = &this.Addon->AtkUnitBase.AtkEventListener;
        this.InvokeReceiveEvent(&addonBase->AtkEventListener, type, which, eventData, inputData);
    }

    public void Drop(uint which)
    {
        var type = EventType.DD_ROLL_OVER;
        var addonBase = &this.Addon->AtkUnitBase;
        var target = &this.Addon->AtkUnitBase.AtkEventListener;

        var eventData = EventData.ForNormalTarget(target, addonBase);
        var inputData = InputData.Empty();

        inputData.Data[1] = &this.Addon->AtkUnitBase.AtkEventListener;
        this.InvokeReceiveEvent(&addonBase->AtkEventListener, type, which, eventData, inputData);
    }
}

#pragma warning disable SA1025, SA1134, SA1600
[StructLayout(LayoutKind.Explicit, Size = 0x1000)]              // no idea what size, last entries seems to be around +0xfc0? 
public unsafe struct AddonTripleTriad
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x220)] public byte TurnState;                 // 0: waiting, 1: normal move, 2: masked move (order/chaos)

    [FieldOffset(0x228)] public AddonTripleTriadCard BlueDeck0;
    [FieldOffset(0x2d0)] public AddonTripleTriadCard BlueDeck1;
    [FieldOffset(0x378)] public AddonTripleTriadCard BlueDeck2;
    [FieldOffset(0x420)] public AddonTripleTriadCard BlueDeck3;
    [FieldOffset(0x4c8)] public AddonTripleTriadCard BlueDeck4;

    [FieldOffset(0x570)] public AddonTripleTriadCard RedDeck0;
    [FieldOffset(0x618)] public AddonTripleTriadCard RedDeck1;
    [FieldOffset(0x6c0)] public AddonTripleTriadCard RedDeck2;
    [FieldOffset(0x768)] public AddonTripleTriadCard RedDeck3;
    [FieldOffset(0x810)] public AddonTripleTriadCard RedDeck4;

    [FieldOffset(0x8b8)] public AddonTripleTriadCard Board0;
    [FieldOffset(0x960)] public AddonTripleTriadCard Board1;
    [FieldOffset(0xa08)] public AddonTripleTriadCard Board2;
    [FieldOffset(0xab0)] public AddonTripleTriadCard Board3;
    [FieldOffset(0xb58)] public AddonTripleTriadCard Board4;
    [FieldOffset(0xc00)] public AddonTripleTriadCard Board5;
    [FieldOffset(0xca8)] public AddonTripleTriadCard Board6;
    [FieldOffset(0xd50)] public AddonTripleTriadCard Board7;
    [FieldOffset(0xdf8)] public AddonTripleTriadCard Board8;

    [FieldOffset(0xf88)] public byte NumCardsBlue;
    [FieldOffset(0xf89)] public byte NumCardsRed;

    // 0xFCA - int timer blue?
    // 0xFB0 - int timer red?
    // 0xFB4 - idk, 4-ish bytes of something changing
}

[StructLayout(LayoutKind.Explicit, Size = 0xA8)]
public unsafe struct AddonTripleTriadCard
{
    [FieldOffset(0x8)] public AtkComponentBase* CardDropControl;
    [FieldOffset(0x80)] public byte CardRarity;                 // 1..5
    [FieldOffset(0x81)] public byte CardType;                   // 0: no type, 1: primal, 2: scion, 3: beastman, 4: garland
    [FieldOffset(0x82)] public byte CardOwner;                  // 0: empty, 1: blue, 2: red
    [FieldOffset(0x83)] public byte NumSideU;
    [FieldOffset(0x84)] public byte NumSideD;
    [FieldOffset(0x85)] public byte NumSideR;
    [FieldOffset(0x86)] public byte NumSideL;
    [FieldOffset(0xA4)] public bool HasCard;

    // 0x87 - constant per card, changes between npcs
    // 0x88 - fixed per card, not ID
    // 0x89 - fixed per card, 40/41 ?
}
#pragma warning restore SA1025, SA1134, SA1600