using _033_InMemory_Cosmos.Models;
using Microsoft.AspNetCore.Mvc;

namespace _033_InMemory_Cosmos.Controller
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(string id)
        {
            var product = await _repository.GetByIdAsync(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create(ProductDto productDto)
        {
            var product = await _repository.AddAsync(productDto);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Update(string id, ProductDto productDto)
        {
            var updatedProduct = await _repository.UpdateAsync(id, productDto);
            return updatedProduct == null ? NotFound() : Ok(updatedProduct);
        }
    }
}
