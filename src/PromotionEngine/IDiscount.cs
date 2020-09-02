using System.Collections.Generic;

namespace PromotionEngine
{
    public interface IDiscount
    {
        decimal CalculateDiscount(IDictionary<char, int> products);
    }
}
