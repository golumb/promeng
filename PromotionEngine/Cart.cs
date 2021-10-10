using System;
using System.Linq;
using System.Collections.Generic;
using PromotionEngine.Models;

namespace PromotionEngine
{
    public class Cart
    {
        private Dictionary<string, decimal> priceList;
        public Dictionary<string, CartItem> Items { get; private set; }

        public Cart()
        {
            priceList = DataAccess.GetPrices();
            Items = new Dictionary<string, CartItem>();
        }

        public void Add(string Id, uint count)
        {
            if (!Items.ContainsKey(Id))
            {
                Items.Add(Id,
                    new CartItem()
                    {
                        Sku = new SKU(Id, priceList[Id]),
                        Count = count,
                        PromotionApplied = false
                    });
            }
            else
            {
                Items[Id] = new CartItem()
                {
                    Sku = Items[Id].Sku,
                    Count = Items[Id].Count + count,
                    PromotionApplied = Items[Id].PromotionApplied
                };
            }
        }


        public decimal CartTotal()
        {
            return Items.Sum(i => i.Value.PromotionApplied ? i.Value.SubtotalAfterPromotion : (i.Value.Sku.Price * i.Value.Count));
        }

        public void ApplyPromotion(string Id, decimal subtotalAfterPromotion)
        {
            var item = Items.SingleOrDefault(i => i.Key == Id);
            if (item.Key == Id)
            {
                if (!item.Value.PromotionApplied)
                {
                    Items[Id] = new CartItem()
                    {
                        Sku = Items[Id].Sku,
                        Count = Items[Id].Count,
                        PromotionApplied = true,
                        SubtotalAfterPromotion = subtotalAfterPromotion
                    };
                }
            }
            else
            {
                // log an error
            }
        }

        public bool IsPromotionApplied(string Id)
        {
            var item = Items.SingleOrDefault(i => i.Key == Id);
            if (item.Key == Id)
                return item.Value.PromotionApplied;
            else
                return false;
        }
    }
}
