using System;
using System.Collections.Generic;
using System.Linq;

namespace EcommercePlatformSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new List<Product>
            {
                new Product(1, "Laptop", "Electronics"),
                new Product(2, "Smartphone", "Electronics"),
                new Product(3, "Desk", "Furniture"),
                new Product(4, "Chair", "Furniture"),
                new Product(5, "Headphones", "Electronics"),
                new Product(6, "Coffee Mug", "Kitchen"),
                new Product(7, "Notebook", "Stationery"),
                new Product(8, "Backpack", "Accessories"),
                new Product(9, "Sneakers", "Footwear"),
                new Product(10, "Watch", "Accessories")
            };

            // Linear Search for product id 5
            var linearResult = ProductSearch.LinearSearch(products, 5);
            Console.WriteLine(linearResult != null
                ? $"Linear Search: Found {linearResult.ProductName} (ID {linearResult.ProductId})"
                : "Linear Search: Product not found");

            // Sort by ProductId for binary search
            var sorted = products.OrderBy(p => p.ProductId).ToList();

            // Binary Search for product id 7
            var binaryResult = ProductSearch.BinarySearch(sorted, 7);
            Console.WriteLine(binaryResult != null
                ? $"Binary Search: Found {binaryResult.ProductName} (ID {binaryResult.ProductId})"
                : "Binary Search: Product not found");
        }
    }
}
