namespace _005_ShoppingCart
{
    [Serializable]
    public class ShoppingCart : IDisposable
    {
        public List<Product> Products = new List<Product>();

        public int Count
        {
            get { return Products.Count; }
        }

        public void Add(Product item)
        {
            Products.Add(item);
        }

        public void Dispose()
        {
            // cleanup code
        }

        public void Remove(int index)
        {
            Products.RemoveAt(index);
        }
    }

    [Serializable]
    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
