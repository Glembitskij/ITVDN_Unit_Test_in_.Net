namespace _034_Console_Test
{
    public class ProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task PrintProducts()
        {
            var products = await _repository.GetAllAsync();

            foreach (var product in products)
            {
                Console.WriteLine($"Product: {product.Name}, Price: {product.Price:C}");
            }
        }
    }
}
