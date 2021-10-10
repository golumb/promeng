using System;
using System.Collections.Generic;

namespace PromotionEngine
{
    public class Cart
    {
        private Dictionary<string, decimal> priceList;

        public Cart()
        {
            priceList = new Dictionary<string, decimal>();
        }

        public void Add(string Id, uint count)
        {
        }


        public decimal CartTotal()
        {
            return 0.0m;
        }

        public void ApplyPromotion(string Id, decimal subtotalAfterPromotion)
        {
        }

        public bool IsPromotionApplied(string Id)
        {
            return false;
        }
    }
}
