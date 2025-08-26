namespace GatePass.Business.Framework
{
    public interface IIdBusinessProvider<T, TId> : IBusinessProvider
        where T : class
    {
        public void SaveChanges();

        public Task<T?> GetAsync(TId entity);

        public Task<IList<T>> GetAllAsync();

        public Task<T> AddAsync(T entity);

        public Task<T> UpdateAsync(T entity);

        public Task Delete(TId id);
    }
}
