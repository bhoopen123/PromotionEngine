
using System.Linq;
using System.Collections.Generic;

namespace PromotionEngine
{
    public class PromotionCalculator
    {
        private List<IDiscount> _discountCalculators = null;

        public PromotionCalculator()
        {
            _discountCalculators = new List<IDiscount>();

            // adding all types of discount calculator
            _discountCalculators.Add(new QuantityDiscount());
            _discountCalculators.Add(new GroupDiscount());

            // any new discountCalculator
            //_discountCalculators.Add(new PercentageDiscount());
        }

        public decimal Calculate(char[] products)
        {
            decimal discountedPrice = decimal.Zero;

            var productsAndQuantity = products.GroupBy(p => p).ToDictionary(g => g.Key, g => g.Count());

            // calculate the price without discounts
            var allProducts = ProductManager.GetProducts;
            
            foreach (var productId in productsAndQuantity.Keys)
            {
                discountedPrice += allProducts.Find(p => p.Id.Equals(productId)).Price
                                        * productsAndQuantity[productId];
            }

            // applying discount or promotions on products
            foreach (var discountCalculator in _discountCalculators)
            {
                discountedPrice -= discountCalculator.CalculateDiscount(productsAndQuantity);
            }

            return discountedPrice;
        }
    }
}
