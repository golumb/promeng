using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Models
{
    public class CartItem
    {
        public SKU Sku { get; set; }
        public uint Count { get; set; }
        public bool PromotionApplied { get; set; } = false;
        public decimal? SubtotalAfterPromotion { get; set; }
    }
}
