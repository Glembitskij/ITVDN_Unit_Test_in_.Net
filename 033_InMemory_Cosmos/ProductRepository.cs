using _033_InMemory_Cosmos.Cosmos;
using _033_InMemory_Cosmos.Models;
using Microsoft.EntityFrameworkCore;

namespace _033_InMemory_Cosmos
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(string id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<Product> AddAsync(ProductDto productDto)
        {
            var product = new Product { Name = productDto.Name, Price = productDto.Price };
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> UpdateAsync(string id, ProductDto productDto)
        {
            var existingProduct = await _dbContext.Products.FindAsync(id);
            if (existingProduct == null) return null;

            existingProduct.Name = productDto.Name;
            existingProduct.Price = productDto.Price;

            await _dbContext.SaveChangesAsync();
            return existingProduct;
        }
    }
}
