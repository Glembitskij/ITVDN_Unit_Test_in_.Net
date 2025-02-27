using _033_InMemory_Cosmos;
using Moq;
using _033_InMemory_Cosmos.Controller;
using _033_InMemory_Cosmos.Models;
using Microsoft.AspNetCore.Mvc;

namespace _034_InMemory_CosmosTest
{
    [TestClass]
    public class ProductsControllerTest
    {
        private Mock<IProductRepository> _repositoryMock;
        private ProductsController _controller;

        [TestInitialize]
        public void Setup()
        {
            _repositoryMock = new Mock<IProductRepository>();
            _controller = new ProductsController(_repositoryMock.Object);
        }

        [TestMethod]
        public async Task GetAll_ReturnsOk_WithProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Id = "1", Name = "Test1", Price = 10 },
                new Product { Id = "2", Name = "Test2", Price = 20 }
            };

            _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(products);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);

            var returnedProducts = okResult.Value as List<Product>;

            Assert.IsNotNull(returnedProducts);
            Assert.AreEqual(2, returnedProducts.Count);
        }

        [TestMethod]
        public async Task GetById_ProductExists_ReturnsOk()
        {
            // Arrange
            var product = new Product { Id = "1", Name = "Test", Price = 10 };
            _repositoryMock.Setup(repo => repo.GetByIdAsync("1")).ReturnsAsync(product);

            // Act
            var result = await _controller.GetById("1");

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var returnedProduct = okResult.Value as Product;
            Assert.IsNotNull(returnedProduct);
            Assert.AreEqual("Test", returnedProduct.Name);
        }

        [TestMethod]
        public async Task GetById_ProductDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            _repositoryMock.Setup(repo => repo.GetByIdAsync("999")).ReturnsAsync((Product)null);

            // Act
            var result = await _controller.GetById("999");

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task Create_ValidProduct_ReturnsCreatedAtAction()
        {
            // Arrange
            var productDto = new ProductDto { Name = "Test", Price = 10 };
            var product = new Product { Id = "1", Name = "Test", Price = 10 };
            _repositoryMock.Setup(repo => repo.AddAsync(productDto)).ReturnsAsync(product);

            // Act
            var result = await _controller.Create(productDto);

            // Assert
            var createdResult = result.Result as CreatedAtActionResult;
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("GetById", createdResult.ActionName);
        }

        [TestMethod]
        public async Task Update_ExistingProduct_ReturnsOk()
        {
            // Arrange
            var productDto = new ProductDto { Name = "Updated", Price = 15 };
            var product = new Product { Id = "1", Name = "Updated", Price = 15 };
            _repositoryMock.Setup(repo => repo.UpdateAsync("1", productDto)).ReturnsAsync(product);

            // Act
            var result = await _controller.Update("1", productDto);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);

            var updatedProduct = okResult.Value as Product;

            Assert.IsNotNull(updatedProduct);
            Assert.AreEqual("Updated", updatedProduct.Name);
        }

        [TestMethod]
        public async Task Update_NonExistingProduct_ReturnsNotFound()
        {
            // Arrange
            var productDto = new ProductDto { Name = "Updated", Price = 15 };
            _repositoryMock.Setup(repo => repo.UpdateAsync("999", productDto)).ReturnsAsync((Product)null);

            // Act
            var result = await _controller.Update("999", productDto);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }
    }
}
