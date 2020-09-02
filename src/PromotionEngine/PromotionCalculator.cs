
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
            
            // any new dicsountCalculator
        }

        public decimal Calculate(char[] productsInCart)
        {
            decimal discountedPrice = decimal.Zero;
            
            // applying discount or promotions on products
            foreach (var discountCalculator in _discountCalculators)
            {
                discountedPrice += discountCalculator.ApplyDiscount(productsInCart);
            }

            return discountedPrice;
        }
    }
}
