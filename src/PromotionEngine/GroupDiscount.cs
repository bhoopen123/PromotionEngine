
using System.Linq;
using System.Collections.Generic;

namespace PromotionEngine
{
    public class GroupDiscount : IDiscount
    {
        //model to store discounted product details
        private class GroupProduct
        {
            public char[] products;
            public decimal discount;
        }

        private List<GroupProduct> _discountProducts = null;

        public GroupDiscount()
        {
            // fill initial data
            _discountProducts = new List<GroupProduct>();

            _discountProducts.Add(new GroupProduct()
            {
                products = new char[] { 'C', 'D' },
                discount = 5m               // Discounted price for C & D was 30, so discount is 5
            });
        }

        public decimal CalculateDiscount(IDictionary<char, int> productsInCart)
        {
            var discount = decimal.Zero;

            for (int i = 0; i < _discountProducts.Count(); i++)
            {
                var discountDetails = _discountProducts[i];

                bool discountFound = true;

                foreach (var productId in discountDetails.products)
                {
                    if (!productsInCart.Keys.Contains(productId) || productsInCart[productId] < 1)
                    {
                        discountFound = false;
                        break;
                    }
                }

                if (discountFound)
                {
                    discount += discountDetails.discount;

                    foreach (var productId in discountDetails.products)
                    {
                        productsInCart[productId]--;
                    }

                    i--;
                }
            }


            return discount;
        }
    }
}
