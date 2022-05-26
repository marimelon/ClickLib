using System;

using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks
{
    /// <summary>
    /// Addon TripleTriadRequest.
    /// </summary>
    public sealed class ClickTripleTriadRequest : ClickAddonBase<AddonTripleTriadRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClickTripleTriadRequest"/> class.
        /// </summary>
        /// <param name="addon">Addon pointer.</param>
        public ClickTripleTriadRequest(IntPtr addon = default)
            : base(addon)
        {
        }

        /// <inheritdoc/>
        protected override string AddonName => "TripleTriadRequest";

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
        public unsafe void Rematch()
        {
            ClickAddonButton(&this.Addon->AtkUnitBase, this.Addon->ChallengeButton, 0x1);
        }

        /// <summary>
        /// Click the quit button.
        /// </summary>
        [ClickName("triple_triad_request_quit")]
        public unsafe void Quit()
        {
            ClickAddonButton(&this.Addon->AtkUnitBase, this.Addon->QuitButton, 0x2);
        }
    }
}
