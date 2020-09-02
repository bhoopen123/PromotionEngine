
using System.Linq;
using System.Collections.Generic;

namespace PromotionEngine
{
    public class QuantityDiscount : IDiscount
    {
        //model to store discounted product details
        private class DiscountProduct
        {
            public char productId;
            public int quantity;
            public decimal discountedPrice;
        }

        private List<DiscountProduct> _discountProducts = null;

        public QuantityDiscount()
        {
            // fill initail data
            _discountProducts = new List<DiscountProduct>();

            SetQuantityDiscount('A', 3, 130m);
            SetQuantityDiscount('B', 2, 45m);
        }

        public void SetQuantityDiscount(char productId, int quantity, decimal discountedPrice)
        {
            // TODO : need to check if product already exist or not
            _discountProducts.Add(new DiscountProduct()
            {
                productId = productId,
                quantity = quantity,
                discountedPrice = discountedPrice
            });
        }

        public decimal ApplyDiscount(char[] productsInCart)
        {
            // get all products
            var allProducts = ProductManager.GetProducts;

            var discountedPrice = decimal.Zero;

            var productsAndQuantity = productsInCart.GroupBy(p => p).ToDictionary(g => g.Key, g => g.Count());

            foreach (var productId in productsAndQuantity.Keys)
            {
                var discountedProduct = _discountProducts.FirstOrDefault(p => p.productId.Equals(productId));

                var actualProduct = allProducts.First(p => p.Id.Equals(productId));

                if (discountedProduct == null)
                    continue;

                discountedPrice += (productsAndQuantity[productId] / discountedProduct.quantity) * discountedProduct.discountedPrice    // calculate discounted price
                                        + (productsAndQuantity[productId] % discountedProduct.quantity) * actualProduct.Price;          // calculate actule price
            }

            return discountedPrice;
        }
    }
}
