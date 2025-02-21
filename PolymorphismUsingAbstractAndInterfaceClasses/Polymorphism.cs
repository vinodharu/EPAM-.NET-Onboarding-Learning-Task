using System;
using System.Collections.Generic;

namespace Polymorphism
{
    public interface IProduct
    {
        void ProcessOrder();
    }

    public abstract class Product : IProduct
    {
        public string _productName;
        public double _price;
        public string _category;

        public Product(string productName, double price, string category)
        {
            _productName = productName;
            _price = price;
            _category = category;
        }

        public abstract void ProcessOrder();

        public void ShowProductDetails()
        {
            Console.WriteLine($"Product: {_productName}");
            Console.WriteLine($"Price: {_price}");
            Console.WriteLine($"Category: {_category}");
        }
    }

    public class Book : Product
    {
        public Book(string productName, double price) : base(productName, price, "Book") { }

        public override void ProcessOrder()
        {
            Console.WriteLine("\nProcessing Book Order...");
            ShowProductDetails();
            Console.WriteLine("Book order processed");
        }
    }

    public class Electronics : Product
    {
        public Electronics(string productName, double price) : base(productName, price, "Electronics") { }

        public override void ProcessOrder()
        {
            Console.WriteLine("\nProcessing Electronics Order...");
            ShowProductDetails();
            Console.WriteLine("Electronics order processed");
        }
    }

    public class Cloth: Product
    {
        public Cloth(string productName, double price) : base(productName, price, "Clothing") { }

        public override void ProcessOrder()
        {
            Console.WriteLine("\nProcessing Clothing Order...");
            ShowProductDetails();
            Console.WriteLine("Clothing order processed");
        }
    }

    class Polymorphism
    {
        static void Main()
        {
            List<IProduct> products = new List<IProduct>
            {
                new Book("C# Programming Guide", 10.99),
                new Electronics("Smartphone", 498.00),
                new Cloth("Kurta", 79.56)
            };

            foreach (var product in products)
            {
                product.ProcessOrder();
            }

            Console.WriteLine("\nOrder Processing Completed!");
        }
    }
}