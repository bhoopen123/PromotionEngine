
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
            public decimal discount;
        }

        private List<DiscountProduct> _discountProducts = null;

        public QuantityDiscount()
        {
            // fill initail data
            _discountProducts = new List<DiscountProduct>();

            SetQuantityDiscount('A', 3, 20m);   // 130 was the discounted price, so discount is 20
            SetQuantityDiscount('B', 2, 15m);   // 45 was the discounted price, so discount is 15
        }

        public void SetQuantityDiscount(char productId, int quantity, decimal discount)
        {
            // TODO : need to check if product already exist or not
            _discountProducts.Add(new DiscountProduct()
            {
                productId = productId,
                quantity = quantity,
                discount = discount
            });
        }

        public decimal CalculateDiscount(IDictionary<char, int> products)
        {
            var discount = decimal.Zero;

            foreach (var productId in products.Keys)
            {
                var discountDetails = _discountProducts.FirstOrDefault(p => p.productId.Equals(productId));

                if (discountDetails == null)
                    continue;

                discount += (products[productId] / discountDetails.quantity) * discountDetails.discount; // calculate discounted price
            }

            return discount;
        }
    }
}
