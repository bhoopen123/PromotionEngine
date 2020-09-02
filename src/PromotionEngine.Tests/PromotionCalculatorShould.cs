using System;
using Xunit;

namespace PromotionEngine.Tests
{
    public class PromotionCalculatorShould
    {
        private PromotionCalculator _promotionCalculator = null;

        public PromotionCalculatorShould()
        {
            _promotionCalculator = new PromotionCalculator();
        }

        [Fact]
        public void CalulateWith_NoPromotion()
        {
            var actual = _promotionCalculator.Calculate(new char[] { 'A', 'B', 'C' });

            var expected = 100m;

            Assert.Equal(actual, expected, 2);
        }

        [Fact]
        public void CalulateWith_QuantityPromotions()
        {
            var actual = _promotionCalculator.Calculate(new char[] { 'A', 'A', 'A', 'A', 'A', 'B', 'B', 'B', 'B', 'B', 'C' });

            var expected = 370m;

            Assert.Equal(actual, expected, 2);
        }

        [Fact]
        public void CalulateWith_QuantityAndGroupPromotions()
        {
            var actual = _promotionCalculator.Calculate(new char[] { 'A', 'A', 'A', 'B', 'B', 'B', 'B', 'B', 'C', 'D' });

            var expected = 280m;

            Assert.Equal(actual, expected, 2);
        }
    }
}
