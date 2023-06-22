namespace EvilInsultAPI.Services
{
    public interface ICrudService<T, ID>
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetByIdAsync(ID id);
        Task AddAsync(T obj);
        Task UpdateAsync(T obj);
        Task DeleteByIdAsync(ID id);
    }
}
