using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace GatePass.Presentation.Components.Pages.Event
{
    public partial class CreateEvent
    {
        [Parameter]
        public Guid? Id { get; set; }

        private Data.Entities.Event? _event;

        private bool _loaded = false;

        protected override async Task OnInitializedAsync()
        {
            _event = Id.HasValue ? await _eventBusinessProvider.GetAsync(Id.Value) : new();
            _loaded = true;
        }

        private async Task ProcessSubmit(EditContext args)
        {
            _event.LastUpdatedAt = DateTime.Now;
            await _eventBusinessProvider.AddAsync(_event);
            _eventBusinessProvider.SaveChanges();
        }
    }
}