using GatePass.Business.BusinessProviders.Entities;
using Microsoft.AspNetCore.Components;

namespace GatePass.Presentation.Components.Pages.Ticket
{
    public partial class Index
    {
        [Inject] public TicketBusinessProvider TicketBusinessProvider { get; set; }

        [Parameter]
        public Guid Id { get; set; }

        private Data.Entities.Ticket? _ticket;

        protected override async Task OnInitializedAsync()
        {
            _ticket = await TicketBusinessProvider.GetAsync(Id);
        }
    }
}
