using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class Engine
    {
        public List<IPromotion> Promotions { get; private set; }
        public Engine()
        {
            Promotions = new List<IPromotion>();
        }
        public Cart ApplyPromotions(Cart cart)
        {
            return cart;
        }
    }
}
