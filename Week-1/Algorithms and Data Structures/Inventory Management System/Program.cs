using System;

namespace InventoryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new InventoryManager();

            // Add products
            manager.AddProduct(new Product(1, "Laptop", 10, 999.99));
            manager.AddProduct(new Product(2, "Smartphone", 20, 499.50));
            manager.AddProduct(new Product(3, "Desk", 5, 199.99));
            manager.AddProduct(new Product(4, "Chair", 15, 79.95));
            manager.AddProduct(new Product(5, "Headphones", 30, 59.99));

            // Display all
            Console.WriteLine("--- Initial Inventory ---");
            manager.DisplayAllProducts();

            // Search for a product
            manager.SearchProduct(3);

            // Update a product (change quantity and price of product 2)
            manager.UpdateProduct(2, new Product(2, "Smartphone", 25, 479.99));

            // Delete a product (remove product 4)
            manager.DeleteProduct(4);

            // Final inventory display
            Console.WriteLine("--- Final Inventory ---");
            manager.DisplayAllProducts();
        }
    }
}
