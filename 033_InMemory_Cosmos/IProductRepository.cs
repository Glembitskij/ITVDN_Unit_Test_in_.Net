using _033_InMemory_Cosmos.Models;

namespace _033_InMemory_Cosmos
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(string id);
        Task<Product> AddAsync(ProductDto productDto);
        Task<Product?> UpdateAsync(string id, ProductDto productDto);
    }
}
