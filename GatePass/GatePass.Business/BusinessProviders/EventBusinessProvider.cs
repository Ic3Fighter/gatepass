using GatePass.Core.Framework;
using GatePass.Data.DataProviders;
using GatePass.Data.Entities;

namespace GatePass.Business.BusinessProviders
{
    public class EventBusinessProvider(EventDataProvider dataProvider) : IBusinessProvider
    {
        private EventDataProvider DataProvider { get; } = dataProvider;

        public void SaveChanges() => DataProvider.SaveChanges();

        public async Task<Event?> GetAsync(Guid id) => await DataProvider.GetAsync(id);

        public async Task<Event> AddAsync(Event ev) => await DataProvider.AddAsync(ev);

        public Event Update(Event ev) => DataProvider.Update(ev);

        public async Task Delete(Guid id) => await DataProvider.Delete(id);
    }
}
