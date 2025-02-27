using _005_ShoppingCart;

// xUnit — це сучасний фреймворк для модульного тестування .NET-додатків,
// який є наступником MSTest та NUnit. Він був розроблений для покращення
// гнучкості та підтримки сучасних підходів до тестування.

// IClassFixture<T> в xUnit використовується для ініціалізації ресурсів один раз для всіх тестів у класі.
// Це аналог[ClassInitialize] і [ClassCleanup] у MSTest.
namespace _006_ShoppingCartTest
{
    // ShoppingCartFixture виконує роль ініціалізації (ClassInitialize) та очищення (ClassCleanup).
    public class ShoppingCartFixture : IDisposable
    {
        public ShoppingCart Cart { get; private set; }

        public ShoppingCartFixture()
        {
            Product product = new Product
            {
                Name = "Unit Test Video Lessons",
                Quantity = 10
            };

            Cart = new ShoppingCart();
            Cart.Add(product);
        }

        // Метод Dispose() викликається після завершення всіх тестів у класі (аналог ClassCleanup).
        public void Dispose()
        {
            Cart.Dispose();
        }
    }

    // Використано IClassFixture<ShoppingCartFixture>,
    // щоб ShoppingCartFixture ініціалізувався один раз для всього класу тестів.
    public class ClassInitAndCleanup :  IClassFixture<ShoppingCartFixture>
    {
        // Тести працюють із екземпляром _cart, який отримуємо через IClassFixture<ShoppingCartFixture>.
        private readonly ShoppingCart _cart;

        public ClassInitAndCleanup(ShoppingCartFixture fixture)
        {
            _cart = fixture.Cart;
        }

        [Fact]
        public void ShoppingCart_AddToCart()
        {
            int expected = _cart.Products.Count + 1;

            _cart.Add(new Product() { Name = "Test", Quantity = 1 });

            Assert.Equal(expected, _cart.Count);
        }

        [Fact]
        public void ShoppingCart_RemoveFromCart()
        {
            int expected = _cart.Products.Count - 1;

            _cart.Remove(0);

            Assert.Equal(expected, _cart.Count);
        }
    }
}
