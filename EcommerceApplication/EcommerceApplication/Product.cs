using System;
public abstract class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public Product(string name, decimal price, string description, int quantity)
    {
        Name = name;
        Price = price;
        Description = description;
        Quantity = quantity;
    }
    public abstract decimal CalculateDiscount();
    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Price: Rs:{Price}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Quantity Available: {Quantity}");
    }
}
