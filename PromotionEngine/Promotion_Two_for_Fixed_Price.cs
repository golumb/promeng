using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotionEngine.Models;

namespace PromotionEngine
{
    public class Promotion_Two_for_Fixed_Price : IPromotion
    {
        private string _id1;
        private string _id2;
        private decimal _fixedPrice;
        public Promotion_Two_for_Fixed_Price(string id1, string id2, decimal fixedPrice)
        {
            _id1 = id1;
            _id2 = id2;
            _fixedPrice = fixedPrice;
        }

        bool IPromotion.Apply(ref Cart cart)
        {
            bool result = false;

            var i1 = cart.Items.SingleOrDefault(i => i.Key == _id1);
            var i2 = cart.Items.SingleOrDefault(i => i.Key == _id2);

            if (i1.Value != null && i2.Value != null && !i1.Value.PromotionApplied && !i2.Value.PromotionApplied)
            {
                var numberOfTimesApplied = TryApply(i1.Value.Count, i2.Value.Count);

                cart.Items[_id1] = new CartItem()
                {
                    Sku = i1.Value.Sku,
                    Count = i1.Value.Count,
                    PromotionApplied = true,
                    SubtotalAfterPromotion = 0m  // one of them is free, kind of
                };
                cart.Items[_id2] = new CartItem()
                {
                    Sku = i2.Value.Sku,
                    Count = i2.Value.Count,
                    PromotionApplied = true,
                    SubtotalAfterPromotion = _fixedPrice * numberOfTimesApplied
                };
                result = true;
            }

            return result;
        }

        private uint TryApply(uint count1, uint count2)
        {
            return Math.Min(count1, count2);  // this is the number of times the promotion is applied
        }
    }
}
