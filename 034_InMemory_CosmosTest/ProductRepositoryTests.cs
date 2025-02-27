using _033_InMemory_Cosmos;
using _033_InMemory_Cosmos.Cosmos;
using _033_InMemory_Cosmos.Models;
using _033_InMemory_Cosmos.Options;
using Microsoft.EntityFrameworkCore;

namespace _034_InMemory_CosmosTest
{
    [TestClass]
    public class ProductRepositoryTests
    {
        private AppDbContext _dbContext;
        private ProductRepository _repository;

        [TestInitialize]
        public void Setup()
        {
            string databaseName = GenerateUniqueDatabaseName();
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: databaseName)
                .Options;

            _dbContext = new AppDbContext(options, new CosmosDbOptions { DatabaseName = databaseName, ContainerName = "Products" });
            _repository = new ProductRepository(_dbContext);
        }

        [TestMethod]
        public async Task GetAllAsync_ReturnsAllProducts()
        {
            // Arrange
            _dbContext.Products.Add(new Product { Name = "Test1", Price = 10 });
            _dbContext.Products.Add(new Product { Name = "Test2", Price = 20 });
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public async Task GetByIdAsync_ExistingProduct_ReturnsProduct()
        {
            // Arrange
            var product = new Product { Id = "1", Name = "Test", Price = 10 };
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _repository.GetByIdAsync("1");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Test", result.Name);
        }

        [TestMethod]
        public async Task AddAsync_AddsProductToDatabase()
        {
            // Arrange
            var productDto = new ProductDto { Name = "New Product", Price = 30 };

            // Act
            var result = await _repository.AddAsync(productDto);
            var retrievedProduct = await _dbContext.Products.FindAsync(result.Id);

            // Assert
            Assert.IsNotNull(retrievedProduct);
            Assert.AreEqual("New Product", retrievedProduct.Name);
        }

        [TestMethod]
        public async Task UpdateAsync_ExistingProduct_UpdatesProduct()
        {
            // Arrange
            var product = new Product { Id = "1", Name = "Old Name", Price = 10 };
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();

            var updateDto = new ProductDto { Name = "Updated Name", Price = 20 };

            // Act
            var updatedProduct = await _repository.UpdateAsync("1", updateDto);

            // Assert
            Assert.IsNotNull(updatedProduct);
            Assert.AreEqual("Updated Name", updatedProduct.Name);
        }

        private static string GenerateUniqueDatabaseName()
        {
            return $"TestDb_{Guid.NewGuid()}";
        }

    }
}