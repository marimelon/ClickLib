using System;

using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks
{
    /// <summary>
    /// Addon TripleTriadResult.
    /// </summary>
    public sealed class ClickTripleTriadResult : ClickAddonBase<AddonTripleTriadResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClickTripleTriadResult"/> class.
        /// </summary>
        /// <param name="addon">Addon pointer.</param>
        public ClickTripleTriadResult(IntPtr addon = default)
            : base(addon)
        {
        }

        /// <inheritdoc/>
        protected override string AddonName => "TripleTriadResult";

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
        public unsafe void Rematch()
        {
            ClickAddonButton(&this.Addon->AtkUnitBase, this.Addon->RematchButton, 0x1);
        }

        /// <summary>
        /// Click the quit button.
        /// </summary>
        [ClickName("triple_triad_result_quit")]
        public unsafe void Quit()
        {
            ClickAddonButton(&this.Addon->AtkUnitBase, this.Addon->QuitButton, 0x2);
        }
    }
}
