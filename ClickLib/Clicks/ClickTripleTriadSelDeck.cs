using System;

using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks
{
    /// <summary>
    /// Addon AddonTripleTriadSelDeck.
    /// </summary>
    public sealed class ClickTripleTriadSelDeck : ClickAddonBase<AddonTripleTriadSelDeck>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClickTripleTriadSelDeck"/> class.
        /// </summary>
        /// <param name="addon">Addon pointer.</param>
        public ClickTripleTriadSelDeck(IntPtr addon = default)
            : base(addon)
        {
        }

        /// <inheritdoc/>
        protected override string AddonName => "TripleTriadSelDeck";

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
        public unsafe void Select(uint index)
        {
            var type = EventType.LIST_INDEX_CHANGE;
            var targetList = this.Addon->AtkComponentList220;

            if (index < 0 || index >= targetList->ListLength)
                throw new ArgumentOutOfRangeException(nameof(index), "List index is out of range");

            var inputData = InputData.Empty();
            inputData.Data[0] = targetList->ItemRendererList[index].AtkComponentListItemRenderer;
            inputData.Data[2] = (void*)(index | ((ulong)index << 48));

            ClickAddonComponent(&this.Addon->AtkUnitBase, targetList->AtkComponentBase.OwnerNode, 1, type, inputData: inputData);
        }

        /// <summary>
        /// Click the item in index 1.
        /// </summary>
        [ClickName("triple_triad_deck_select1")]
        public unsafe void Select1() => this.Select(0);

        /// <summary>
        /// Click the item in index 2.
        /// </summary>
        [ClickName("triple_triad_deck_select2")]
        public unsafe void Select2() => this.Select(1);

        /// <summary>
        /// Click the item in index 3.
        /// </summary>
        [ClickName("triple_triad_deck_select3")]
        public unsafe void Select3() => this.Select(2);

        /// <summary>
        /// Click the item in index 4.
        /// </summary>
        [ClickName("triple_triad_deck_select4")]
        public unsafe void Select4() => this.Select(3);

        /// <summary>
        /// Click the item in index 5.
        /// </summary>
        [ClickName("triple_triad_deck_select5")]
        public unsafe void Select5() => this.Select(4);
    }
}
