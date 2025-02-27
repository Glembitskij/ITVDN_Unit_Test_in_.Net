// See https://aka.ms/new-console-template for more information

using _005_ShoppingCart;

Product pen = new Product() 
{
    Name = "Pen",
    Quantity = 1
};

Product pencil = new Product()
{
    Name = "Pen",
    Quantity = 1
};

ShoppingCart shoppingCart = new ShoppingCart();
shoppingCart.Add(pen);
shoppingCart.Add(pencil);

Console.WriteLine(shoppingCart.Count);

shoppingCart.Remove(0);

Console.WriteLine(shoppingCart.Count);