using System;
public class Book : Product
{
    public Book(string name, decimal price, string description, int quantity)
        : base(name, price, description, quantity)
    {
    }
    public override decimal CalculateDiscount()
    {
        return Price * 0.05m; 
    }
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("Category: Books");
    }
}
