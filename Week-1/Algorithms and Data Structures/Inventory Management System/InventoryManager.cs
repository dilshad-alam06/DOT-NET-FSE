using System;
using System.Collections.Generic;

namespace InventoryManagementSystem
{
    public class InventoryManager
    {
        private readonly Dictionary<int, Product> _products = new();

        public void AddProduct(Product product)
        {
            if (_products.ContainsKey(product.ProductId))
            {
                Console.WriteLine($"AddProduct: Product with ID {product.ProductId} already exists. Skipping addition.");
                return;
            }
            _products[product.ProductId] = product;
            Console.WriteLine($"AddProduct: Added product {product.ProductName} (ID {product.ProductId}).");
        }

        public void UpdateProduct(int productId, Product updatedProduct)
        {
            if (!_products.ContainsKey(productId))
            {
                Console.WriteLine($"UpdateProduct: No product with ID {productId} found. Cannot update.");
                return;
            }
            _products[productId] = updatedProduct;
            Console.WriteLine($"UpdateProduct: Updated product ID {productId}.");
        }

        public void DeleteProduct(int productId)
        {
            if (!_products.Remove(productId))
            {
                Console.WriteLine($"DeleteProduct: No product with ID {productId} found. Cannot delete.");
                return;
            }
            Console.WriteLine($"DeleteProduct: Removed product with ID {productId}.");
        }

        public Product? SearchProduct(int productId)
        {
            _products.TryGetValue(productId, out var product);
            if (product != null)
            {
                Console.WriteLine($"SearchProduct: Found product {product.ProductName} (ID {product.ProductId}).");
            }
            else
            {
                Console.WriteLine($"SearchProduct: No product with ID {productId} found.");
            }
            return product;
        }

        public void DisplayAllProducts()
        {
            Console.WriteLine("--- Inventory List ---");
            if (_products.Count == 0)
            {
                Console.WriteLine("(empty)");
                return;
            }
            foreach (var p in _products.Values)
            {
                Console.WriteLine($"ID: {p.ProductId}, Name: {p.ProductName}, Qty: {p.Quantity}, Price: {p.Price:C}");
            }
            Console.WriteLine("--- End of List ---");
        }
    }
}
