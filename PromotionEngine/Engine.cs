﻿using System;
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
            var newCart = cart;
            var minTotal = cart.CartTotal();
            var bestIndex = -1;

            var arr = Promotions.ToArray();
            var permutations = EngineMaths.GetAllPermutaions(arr.Length);

            for (var p = 0; p < permutations.Length; ++p)
            {
                var __cart = cart;
                for (var i = 0; i < permutations.Length; ++i)
                {
                    arr[i].Apply(ref newCart);
                }
            }

            return newCart;
        }
    }
}
