using System;
public class Electronics : Product
{
    public Electronics(string name, decimal price, string description, int quantity)
        : base(name, price, description, quantity)
    {
    }
    public override decimal CalculateDiscount()
    {
        return Price * 0.10m; 
    }
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("Category: Electronics");
    }
}