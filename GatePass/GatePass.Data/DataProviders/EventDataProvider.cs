using GatePass.Core.Framework;
using GatePass.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GatePass.Data.DataProviders
{
    public class EventDataProvider(DatabaseContext context) : IDataProvider
    {
        private DatabaseContext Context { get; set; } = context;

        public void SaveChanges() => Context.SaveChanges();

        public async Task<Event?> GetAsync(Guid id)
        {
            return await Context.Set<Event>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Event> AddAsync(Event ev)
            => (await Context.Set<Event>().AddAsync(ev)).Entity;

        public Event Update(Event ev) => Context.Set<Event>().Update(ev).Entity;

        public async Task Delete(Guid id)
        {
            var entity = await GetAsync(id);
            if (entity != null)
                Context.Set<Event>().Remove(entity);
        }
    }
}
