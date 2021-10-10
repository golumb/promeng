using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Models
{
    public struct SKU
    {
        public string Id { get; set; }
        public decimal Price { get; set; }

        public SKU(string id, decimal price)
        {
            Id = id;
            Price = price;
        }
    }
}
