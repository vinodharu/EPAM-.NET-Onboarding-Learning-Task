using System;

namespace ObjectComparison
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public Product(int productId, string productName, decimal price)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Product other = (Product)obj;
            return ProductId == other.ProductId && ProductName == other.ProductName && Price == other.Price;
        }
    }

    class ObjectComparison
    {
        static void Main(string[] args)
        {
            Product product1 = new Product(101, "Laptop", 1500.00m);
            Product product2 = new Product(101, "Laptop", 1500.00m);
            Product product3 = new Product(102, "Smartphone", 800.00m);

            Console.WriteLine("Comparing product1 and product2: " + product1.Equals(product2)); // True
            Console.WriteLine("Comparing product1 and product3: " + product1.Equals(product3)); // False

            // Comparing using == operator (by reference)
            Console.WriteLine("\nComparing product1 and product2 with == operator: " + (product1 == product2)); // False
        }
    }
}