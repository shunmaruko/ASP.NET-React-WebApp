namespace Backend.Infrastructure.Repository
{
    public interface IRepository<T>
    {
        Task<T?> GetByIdAsync(long id);
        Task<List<T>?> ListAsync();
        Task AddAsync(T model);
        Task UpdateAsync(T model);
        Task DeleteAsync(T model);
        bool Exist(long id);
    }
}
