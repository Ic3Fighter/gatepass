using GatePass.Data.Framework;

namespace GatePass.Business.Framework
{
    public abstract class IdBusinessProvider<T, TId, TDataProvider>(TDataProvider dataProvider) : IIdBusinessProvider<T, TId>
        where T : class where TDataProvider : IIdDataProvider<T, TId>
    {
        protected TDataProvider DataProvider { get; } = dataProvider;

        public void SaveChanges() => DataProvider.SaveChanges();

        public virtual async Task<T?> GetAsync(TId id) => await DataProvider.GetAsync(id);

        public virtual async Task<IList<T>> GetAllAsync() => await DataProvider.GetAllAsync();

        public virtual async Task<T> AddAsync(T entity) => await DataProvider.AddAsync(entity);

        public virtual async Task<T> UpdateAsync(T entity) => await Task.FromResult(DataProvider.Update(entity));

        public virtual async Task Delete(TId id) => await DataProvider.Delete(id);
    }
}
