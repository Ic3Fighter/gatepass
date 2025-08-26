using GatePass.Data.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
namespace GatePass.Presentation.Components.Pages.Event
{
    public partial class Category
    {
        [Parameter]
        public Guid? Id { get; set; }
        [Parameter]
        public Guid EventId { get; set; }

        private Data.Entities.Event? _event;
        private TicketCategory? _category;

        protected async override Task OnInitializedAsync()
        {
            // make async
            _event = await _eventBusinessProvider.GetAsync(EventId);
            _category = Id.HasValue ? await _ticketCategoryBusinessProvider.GetAsync(Id.Value) : new();
        }

        private async Task ProcessSubmit(EditContext args)
        {
            // setup foreign key relationship
            _category.EventId = _event.Id;

            if (Id.HasValue) await _ticketCategoryBusinessProvider.UpdateAsync(_category); // update existing
            else await _ticketCategoryBusinessProvider.AddAsync(_category); // add new
            _ticketCategoryBusinessProvider.SaveChanges();
        }
    }
}