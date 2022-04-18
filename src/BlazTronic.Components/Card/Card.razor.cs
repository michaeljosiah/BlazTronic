using BlazTronic.Components.Base;
using Microsoft.AspNetCore.Components;

namespace BlazTronic.Components.Card
{
    public partial class Card : BlazTronicBase
    {
        [Parameter] public string Id { get; set; }
        [Parameter] public string Title { get; set; }
        [Parameter] public RenderFragment Body { get; set; }
        [Parameter] public RenderFragment FooterContent { get; set; }
        [Parameter] public RenderFragment Toolbar { get; set; }
        [Parameter] public bool DisplayFooter { get; set; }
        [Parameter] public bool EnableShadow { get; set; }
        /// <summary>
        /// enable quick collapsible cards
        /// </summary>
        [Parameter] public bool Collapsible { get; set; }
        /// <summary>
        /// remove a card header and footer borders
        /// </summary>
        [Parameter] public bool FlushBorders { get; set; }
        /// <summary>
        /// reset a card header, body and footer's side paddings
        /// </summary>
        [Parameter] public bool ResetSidePaddings { get; set; }
        /// <summary>
        /// remove it's shadow and enable dashed style borders
        /// </summary>
        [Parameter] public bool EnableDashedStyle { get; set; }
        /// <summary>
        /// have a card with scrollable content
        /// </summary>
        [Parameter] public bool EnableCardScroll { get; set; }

        private ClassBuilder _cardClass = new ClassBuilder();
        private ClassBuilder _cardHeaderClass = new ClassBuilder();
        private ClassBuilder _cardBodyClass = new ClassBuilder();

        private void BindClassMapper()
        {
            _cardClass.Add("card")
                .If("shadow-sm", () => this.EnableShadow)
                .If("card-px-0", () => this.ResetSidePaddings)
                .If("card-dashed", () => this.EnableDashedStyle)
                .If("card-scroll", () => this.EnableCardScroll)
                .If("card-flush", () => this.ResetSidePaddings);

            _cardHeaderClass.Add("card-header")
                .If("collapsible cursor-pointer rotate", () => this.Collapsible);

            _cardBodyClass.Add("card-body")
                .If("card-scroll h-200px", () => this.EnableCardScroll);
        }

        protected override void OnInitialized()
        {
            BindClassMapper();
        }
    }
}
