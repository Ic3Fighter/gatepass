using Microsoft.AspNetCore.Components;

namespace GatePass.Presentation.Components.Pages.Ticket
{
    public partial class Index
    {
        [Parameter]
        public Guid Id { get; set; }

        private Data.Entities.Ticket? _ticket;

        protected override async Task OnInitializedAsync()
        {
            _ticket = await TicketBusinessProvider.GetAsync(Id);
        }
    }
}
