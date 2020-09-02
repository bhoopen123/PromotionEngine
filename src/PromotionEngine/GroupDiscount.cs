
using System.Linq;
using System.Collections.Generic;

namespace PromotionEngine
{
    public class GroupDiscount : IDiscount
    {
        //model to store discounted product details
        private class GroupProduct
        {
            public char[] productGroup;
            public decimal discountedPrice;
        }

        private List<GroupProduct> _discountProducts = null;

        public GroupDiscount()
        {
            // fill initial data
            _discountProducts = new List<GroupProduct>();

            _discountProducts.Add(new GroupProduct()
            {
                productGroup = new char[] { 'C', 'D' },
                discountedPrice = 30m
            });
        }

        public decimal ApplyDiscount(char[] productsInCart)
        {
            // get all products
            var allProducts = ProductManager.GetProducts;

            var discountedPrice = decimal.Zero;

            var productsAndQuantity = productsInCart.GroupBy(p => p).ToDictionary(g => g.Key, g => g.Count());

            for (int i = 0; i < _discountProducts.Count(); i++)
            {
                var discountProduct = _discountProducts[i];

                bool discountFound = true;

                foreach (var groupProductId in discountProduct.productGroup)
                {
                    if (!productsAndQuantity.Keys.Contains(groupProductId))
                    {
                        discountFound = false;
                        break;
                    }
                }

                if (discountFound)
                {
                    discountedPrice += discountProduct.discountedPrice;
                    foreach (var groupProductId in discountProduct.productGroup)
                    {
                        productsAndQuantity[groupProductId]--;
                    }

                    i--;
                }
            }


            return discountedPrice;
        }
    }
}
