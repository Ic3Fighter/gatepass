using GatePass.Data.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace GatePass.Presentation.Components.Pages.Event
{
    public partial class Book
    {
        [Parameter]
        public Guid Id { get; set; }

        private Data.Entities.Event? _event;
        private Ticket _ticket = new();

        protected async override Task OnInitializedAsync()
        {
            _event = await _eventBusinessProvider.GetAsync(Id);
        }

        private async Task ProcessSubmit(EditContext args)
        {
            await _saleBusinessProvider.PurchaseTicket(_ticket); // TODO return?
        }
    }
}