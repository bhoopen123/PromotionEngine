
using System.Linq;
using System.Collections.Generic;

namespace PromotionEngine
{
    public class PercentageDiscount : IDiscount
    {
        private Dictionary<char, int> _discountProducts = null;

        public PercentageDiscount()
        {
            // added a fictious product and its discount in percent
            _discountProducts = new Dictionary<char, int>() { { 'E', 5 } };
        }

        public decimal CalculateDiscount(IDictionary<char, int> productsInCart)
        {
            var discount = decimal.Zero;
            var allProducts = ProductManager.GetProducts;

            foreach (var productId in _discountProducts.Keys)
            {
                if (productsInCart.Keys.Contains(productId))
                    discount += productsInCart[productId] *                     // quantity of a product
                                    _discountProducts[productId] * 0.01m *      // discount in percentage    
                                    allProducts.First(p => p.Id.Equals(productId)).Price;
            }

            return discount;
        }
    }
}
