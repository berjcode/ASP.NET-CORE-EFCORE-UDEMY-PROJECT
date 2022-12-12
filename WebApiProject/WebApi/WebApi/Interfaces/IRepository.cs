using WebApi.Data;

namespace WebApi.Interfaces
{
    public interface IRepository
    {
        Task<List<Product>> GetAllAsync();

        Task<Product> GetByIdAsync(int id);
        Task<Product> Create(Product product);

        Task UpdateAsync(Product product);
        Task RemoveAsync(int id);
    }
}
