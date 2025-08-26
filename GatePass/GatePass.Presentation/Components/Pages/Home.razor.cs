namespace GatePass.Presentation.Components.Pages
{
    public partial class Home
    {
        private IList<Data.Entities.Event>? _events;

        protected async override Task OnInitializedAsync()
        {
            _events = await _eventBusinessProvider.GetAllAsync();
        }
    }
}
