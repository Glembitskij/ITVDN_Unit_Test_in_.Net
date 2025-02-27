using _005_ShoppingCart;

namespace _006_ShoppingCartTest
{
    public class TestInitAndCleanUp: IDisposable
    {
        private ShoppingCart cart;
        private Product product;

        // Виконується перед запуском кожного тесту
        // [TestInitialize] у MSTest
        public TestInitAndCleanUp()
        {
            product = new Product();
            product.Name = "ITVDN Video Lessons";
            product.Quantity = 10;

            cart = new ShoppingCart();
            cart.Add(product);
        }

        // Звільнення ресурси після кожного тесту, 
        // аналог [TestCleanup] у MSTest.
        public void Dispose()
        {
            cart.Dispose();
        }

        [Fact]
        public void ShopingCart_CheckOut_ContainsItem()
        {
            Assert.Contains(product, cart.Products);
        }

        [Fact]
        public void ShopingCart_RemoveItem_Empty()
        {
            int expected = 0;

            cart.Remove(0);

            Assert.Equal(expected, cart.Count);
        }
    }
}