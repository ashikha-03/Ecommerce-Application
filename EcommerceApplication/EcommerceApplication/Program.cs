using System;
using System.Collections.Generic;
public class Program
{
    public static void Main(string[] args)
    {
        ECommerceSystem system = new ECommerceSystem();
        //Added products to respective category
        system.AddProduct(new Electronics("Laptop", 40000, "High-performance laptop", 100));
        system.AddProduct(new Electronics("Smartphone", 18000, "Latest model smartphone", 150));
        system.AddProduct(new Electronics("Headphones", 1500, "Noise-cancelling headphones", 250));

        system.AddProduct(new Clothes("T-shirt", 500, "Cotton T-shirt", 100, new List<string> { "S", "M", "L", "XL" }));
        system.AddProduct(new Clothes("Jeans", 900, "Denim jeans", 200, new List<string> { "M", "L", "XL" }));
        system.AddProduct(new Clothes("Jacket", 1000, "Winter jacket", 150, new List<string> { "M", "L" }));

        system.AddProduct(new Book("C# Programming", 900, "Learn C# programming", 100));
        system.AddProduct(new Book("JavaScript Basics", 250, "Introduction to JavaScript", 50));
        system.AddProduct(new Book("The Great Gatsby", 1500, "Classic novel", 70));
     
        while (true)
        {
            Console.WriteLine("Welcome to the E-Commerce System");
            Console.WriteLine("1. User Menu");
            Console.WriteLine("2. Admin Menu");
            Console.WriteLine("3. Exit");
            Console.Write("Select your role (1/2/3): ");
            string roleChoice = Console.ReadLine();

            if (roleChoice == "1")
            {
                Console.WriteLine("User Menu");
                Console.WriteLine("1. Browse Products by Category");
                Console.WriteLine("2. Purchase Product");
                Console.WriteLine("3. Check Availability");
                Console.WriteLine("4. Exit");

                while (true)
                {
                    Console.Write("Select an action: ");
                    string userChoice = Console.ReadLine();

                    if (userChoice == "1")
                    {
                        Console.WriteLine("Select a category:");
                        Console.WriteLine("1. Electronics");
                        Console.WriteLine("2. Clothes");
                        Console.WriteLine("3. Books");

                        string categoryChoice = Console.ReadLine();

                        if (categoryChoice == "1")
                        {
                            system.DisplayProductsByCategory("Electronics");
                        }
                        else if (categoryChoice == "2")
                        {
                            system.DisplayProductsByCategory("Clothes");
                        }
                        else if (categoryChoice == "3")
                        {
                            system.DisplayProductsByCategory("Book");
                        }
                        else
                        {
                            Console.WriteLine("Invalid category choice.");
                        }
                    }
                    else if (userChoice == "2")
                    {
                        Console.Write("Enter product name to purchase: ");
                        string productName = Console.ReadLine();
                        Console.Write("Enter quantity: ");
                        int quantity = int.Parse(Console.ReadLine());

                        if (productName.ToLower().Contains("t-shirt") || productName.ToLower().Contains("jeans") || productName.ToLower().Contains("jacket"))
                        {
                            Console.WriteLine("Available Sizes: S, M, L, XL");
                            Console.Write("Select size: ");
                            string size = Console.ReadLine();

                            system.PurchaseProduct(productName, quantity, size);
                        }
                        else
                        {
                            system.PurchaseProduct(productName, quantity);
                        }
                    }
                    else if (userChoice == "3")
                    {
                        Console.Write("Enter product name to check availability: ");
                        string productName = Console.ReadLine();
                        system.CheckAvailability(productName);
                    }
                    else if (userChoice == "4")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Try again.");
                    }
                }
            }
           
            else if (roleChoice == "2")
            {
                Console.WriteLine("Admin Menu");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product Price");
                Console.WriteLine("3. Check Product Availability");
                Console.WriteLine("4. Exit");

                while (true)
                {
                    Console.Write("Select an action: ");
                    string adminChoice = Console.ReadLine();

                    if (adminChoice == "1")
                    {
                        Console.Write("Enter product name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter product price: ");
                        decimal price = decimal.Parse(Console.ReadLine());
                        Console.Write("Enter product description: ");
                        string description = Console.ReadLine();
                        Console.Write("Enter product quantity: ");
                        int quantity = int.Parse(Console.ReadLine());

                        Console.WriteLine("Select category: 1. Electronics 2. Clothes 3. Book");
                        string categoryChoice = Console.ReadLine();
                        Product product = null;

                        if (categoryChoice == "1")
                        {
                            product = new Electronics(name, price, description, quantity);
                        }
                        else if (categoryChoice == "2")
                        {
                            Console.WriteLine("Enter available sizes (comma separated):");
                            string sizesInput = Console.ReadLine();
                            List<string> availableSizes = new List<string>(sizesInput.Split(','));
                            product = new Clothes(name, price, description, quantity, availableSizes);
                        }
                        else if (categoryChoice == "3")
                        {
                            product = new Book(name, price, description, quantity);
                        }

                        if (product != null)
                        {
                            system.AddProduct(product);
                            Console.WriteLine("Product added successfully.");
                        }
                    }
                    else if (adminChoice == "2")
                    {
                        Console.Write("Enter product name to update price: ");
                        string productName = Console.ReadLine();
                        Console.Write("Enter new price: ");
                        decimal newPrice = decimal.Parse(Console.ReadLine());

                        system.UpdateProductPrice(productName, newPrice);
                    }
                    else if (adminChoice == "3")
                    {
                        Console.Write("Enter product name to check availability: ");
                        string productName = Console.ReadLine();
                        system.CheckAvailability(productName);
                    }
                    else if (adminChoice == "4")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Try again.");
                    }
                }
            }
            else if (roleChoice == "3")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Try again.");
            }
        }
    }
}
