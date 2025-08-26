using Microsoft.EntityFrameworkCore;

namespace GatePass.Data.Framework
{
    public abstract class IdDataProvider<T, TId>(DatabaseContext context) : IIdDataProvider<T, TId>
        where T : class
    {
        protected DatabaseContext Context { get; set; } = context;

        public void SaveChanges() => Context.SaveChanges();

        public virtual async Task<T?> GetAsync(TId id) => await Context.Set<T>().FindAsync(id);

        public virtual async Task<IList<T>> GetAllAsync() => await Context.Set<T>().ToListAsync();

        public virtual async Task<T> AddAsync(T entity) => (await Context.Set<T>().AddAsync(entity)).Entity;

        public virtual T Update(T entity) => Context.Set<T>().Update(entity).Entity;

        public virtual async Task Delete(TId id)
        {
            var entity = await GetAsync(id);
            if (entity != null)
                Context.Set<T>().Remove(entity);
        }
    }
}
