using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public interface IPromotion
    {
        /// <summary>
        /// applies promotion to a cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns>true if the total is reduced</returns>
        public bool Apply(ref Cart cart);
    }
}
