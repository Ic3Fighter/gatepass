namespace GatePass.Data.Framework
{
    public interface IIdDataProvider<T, TId> : IDataProvider
        where T : class
    {
        public void SaveChanges();

        public Task<T?> GetAsync(TId id);

        public Task<IList<T>> GetAllAsync();

        public Task<T> AddAsync(T entity);

        public T Update(T entity);

        public Task Delete(TId id);
    }
}
