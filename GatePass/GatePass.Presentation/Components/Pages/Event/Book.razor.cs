using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace GatePass.Presentation.Components.Pages.Event
{
    public partial class Book
    {
        [Parameter]
        public Guid Id { get; set; }

        private Data.Entities.Event? _event;
        private readonly Data.Entities.Ticket _ticket = new();

        protected override async Task OnInitializedAsync()
        {
            _event = await EventBusinessProvider.GetAsync(Id);
        }

        private async Task ProcessSubmit(EditContext args)
        {
            var result = await SaleBusinessProvider.PurchaseTicket(_ticket); // TODO return?

            if (result is not null)
            {
                NavigationManager.NavigateTo($"/ticket/{_ticket.Id}"); // redirect to ticket details page
            }
        }
    }
}