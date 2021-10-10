using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class Promotion_N_for_Fixed_Price : IPromotion
    {
        private string _id;
        private uint _N;
        private decimal _fixedPrice;

        public Promotion_N_for_Fixed_Price(string id, uint N, decimal fixedPrice)
        {
            _id = id;
            _N = N;
            _fixedPrice = fixedPrice;
        }

        public bool Apply(ref Cart cart)
        {
            bool result = false;
            foreach(var i in cart.Items)
            {
                if (i.Key == _id && !i.Value.PromotionApplied)
                {
                    var promotionResult = TryApply(i.Value.Count, _N);
                    if (promotionResult.NumberOfTimesApplied>0)
                    {
                        cart.ApplyPromotion(
                            _id,
                            (promotionResult.NumberOfTimesApplied * _fixedPrice) + (promotionResult.NotIncluded * i.Value.Sku.Price)
                            );
                        result = true;
                    }
                    break;
                }
            };

            return result;
        }

        public (uint NumberOfTimesApplied, uint NotIncluded) TryApply(uint NumberInCart, uint NforFixedPrice)
        {
            var notIncluded = NumberInCart % NforFixedPrice;
            var numberOfTimesApplied = (NumberInCart - notIncluded) / NforFixedPrice;
            return (NumberOfTimesApplied: numberOfTimesApplied, NotIncluded: notIncluded);
        }

    }
}
