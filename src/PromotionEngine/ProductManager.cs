
using System.Collections.Generic;

namespace PromotionEngine
{
    public sealed class ProductManager
    {
        // for in-memory collection
        private static List<Product> _products = new List<Product>()
        {
            new Product() { Id = 'A', Price = 50 },
            new Product() { Id = 'B', Price = 30 },
            new Product() { Id = 'C', Price = 20 },
            new Product() { Id = 'D', Price = 15 },
        };

        public static List<Product> GetProducts => _products;

        // TODO: 
        public static void AddProduct(char productId, decimal price)
        {
            _products.Add(new Product() { Id = productId, Price = price });
        }

        // TODO: 
        public static void RemoveProduct(char productId)
        {

        }
    }
}

