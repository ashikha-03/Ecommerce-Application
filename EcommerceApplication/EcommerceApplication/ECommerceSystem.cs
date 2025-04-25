using System;
using System.Collections.Generic;
public class ECommerceSystem
{
    private List<Product> products = new List<Product>();
    public void AddProduct(Product product)
    {
        products.Add(product);
    }
    public void UpdateProductPrice(string productName, decimal newPrice)
    {
        var product = products.Find(p => p.Name == productName);
        if (product != null)
        {
            product.Price = newPrice;
            Console.WriteLine($"Price of '{productName}' updated to Rs:{newPrice}");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }
    public void DisplayProductsByCategory(string category)
    {
        var filteredProducts = products.FindAll(p => p.GetType().Name == category);
        foreach (var product in filteredProducts)
        {
            product.DisplayDetails();
        }
    }
    public void CheckAvailability(string productName)
    {
        var product = products.Find(p => p.Name == productName);
        if (product != null)
        {
            Console.WriteLine($"Product {productName} is available with {product.Quantity} items.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }
    public void PurchaseProduct(string productName, int quantity, string size = null)
    {
        var product = products.Find(p => p.Name == productName);
        if (product != null && product.Quantity >= quantity)
        {
            if (product is Clothes && size == null)
            {
                Console.WriteLine("For clothes, you must select a size.");
                return;
            }
            product.Quantity -= quantity;
            decimal discount = product.CalculateDiscount();
            decimal total = product.Price * quantity - discount * quantity;
            Console.WriteLine($"You purchased {quantity} {productName}(s).");

            if (product is Clothes && size != null)
            {
                Console.WriteLine($"Size: {size} selected.");
            }

            Console.WriteLine($"Total price after discount: Rs:{total}");
        }
        else
        {
            Console.WriteLine("Product not available in sufficient quantity.");
        }
    }
}
