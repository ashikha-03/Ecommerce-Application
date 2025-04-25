using System;
using System.Collections.Generic;
public class Clothes : Product
{
    public List<string> AvailableSizes { get; set; }  
    public Clothes(string name, decimal price, string description, int quantity, List<string> availableSizes)
        : base(name, price, description, quantity)
    {
        AvailableSizes = availableSizes;
    }
    public override decimal CalculateDiscount()
    {
        return Price * 0.15m; 
    }
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("Category: Clothes");
        Console.WriteLine("Available Sizes: " + string.Join(", ", AvailableSizes));
    }
}
