using System.Collections.Generic;

namespace EcommercePlatformSearch
{
    public static class ProductSearch
    {
        // Linear search: returns product or null
        public static Product? LinearSearch(List<Product> products, int productId)
        {
            foreach (var p in products)
            {
                if (p.ProductId == productId)
                    return p;
            }
            return null;
        }

        // Binary search: assumes products are sorted by ProductId
        public static Product? BinarySearch(List<Product> products, int productId)
        {
            int left = 0;
            int right = products.Count - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int midId = products[mid].ProductId;
                if (midId == productId)
                    return products[mid];
                if (midId < productId)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return null;
        }
    }
}
