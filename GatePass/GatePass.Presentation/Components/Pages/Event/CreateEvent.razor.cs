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
            _event = Id.HasValue ? await EventBusinessProvider.GetAsync(Id.Value) : new();
            _loaded = true;
        }

        private async Task ProcessSubmit(EditContext args)
        {
            // set update date
            _event.LastUpdatedAt = DateTime.Now;

            // send to db
            if (Id.HasValue) _event = await EventBusinessProvider.UpdateAsync(_event);
            else _event = await EventBusinessProvider.AddAsync(_event);
            EventBusinessProvider.SaveChanges();

            // navigate to new page
            NavigationManager.NavigateTo("/");
        }
    }
}