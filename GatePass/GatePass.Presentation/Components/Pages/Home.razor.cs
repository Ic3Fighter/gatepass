namespace GatePass.Presentation.Components.Pages
{
    public partial class Home
    {
        private IList<Data.Entities.Event>? _events;

        protected override async Task OnInitializedAsync()
        {
            _events = await EventBusinessProvider.GetAllAsync();
        }
    }
}
