using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public static class DataAccess
    {
        public static Dictionary<string, decimal> GetPrices()
        {
            return new Dictionary<string, decimal>()
            {
                {"A", 50.0m },
                {"B", 30.0m },
                {"C", 20.0m },
                {"D", 15.0m }
            };
        }
    }
}
