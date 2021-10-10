using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotionEngine;

namespace PromotionEngineTests
{
    [TestFixture]
    public class EngineShould
    {
        private Cart cart;
        private Engine sut;

        [SetUp]
        public void Setup()
        {
            cart = new Cart();
            sut = new Engine();
        }

        private static IEnumerable<object[]> CartSource_A()
        {
            var cart = new Dictionary<string, uint>()
            {
                {"A", 1},
                {"B", 1},
                {"C", 1}
            };
            return new[] { new object[] { cart } };
        }

        [Test]
        [TestCaseSource(nameof(CartSource_A))]
        public void Scenario_A(Dictionary<string, uint> itemsToAdd)
        {
            itemsToAdd
                .Where(i => i.Value > 0)
                .ToList()
                .ForEach(i => cart.Add(i.Key, i.Value));

            sut.Promotions.Add(new Promotion_N_for_Fixed_Price("A", 3, 130.0m));
            sut.Promotions.Add(new Promotion_N_for_Fixed_Price("B", 2, 45.0m));
            sut.Promotions.Add(new Promotion_Two_for_Fixed_Price("C", "D", 30.0m));

            Assert.That(sut.ApplyPromotions(cart).CartTotal(), Is.EqualTo(100.0m));  // nothing should be changed
        }


        private static IEnumerable<object[]> CartSource_B()
        {
            var cart = new Dictionary<string, uint>()
            {
                {"A", 5},
                {"B", 5},
                {"C", 1}
            };
            return new[] { new object[] { cart } };
        }
        [Test]
        [TestCaseSource(nameof(CartSource_B))]
        public void Scenario_B(Dictionary<string, uint> itemsToAdd)
        {
            itemsToAdd
                .Where(i => i.Value > 0)
                .ToList()
                .ForEach(i => cart.Add(i.Key, i.Value));

            sut.Promotions.Add(new Promotion_N_for_Fixed_Price("A", 3, 130.0m));
            sut.Promotions.Add(new Promotion_N_for_Fixed_Price("B", 2, 45.0m));
            sut.Promotions.Add(new Promotion_Two_for_Fixed_Price("C", "D", 30.0m));

            Assert.That(sut.ApplyPromotions(cart).CartTotal(), Is.EqualTo(370.0m));
        }

        private static IEnumerable<object[]> CartSource_C()
        {
            var cart = new Dictionary<string, uint>()
            {
                {"A", 3},
                {"B", 5},
                {"C", 1},
                {"D", 1}
            };
            return new[] { new object[] { cart } };
        }
        [Test]
        [TestCaseSource(nameof(CartSource_C))]
        public void Scenario_C(Dictionary<string, uint> itemsToAdd)
        {
            itemsToAdd
                .Where(i => i.Value > 0)
                .ToList()
                .ForEach(i => cart.Add(i.Key, i.Value));

            sut.Promotions.Add(new Promotion_N_for_Fixed_Price("A", 3, 130.0m));
            sut.Promotions.Add(new Promotion_N_for_Fixed_Price("B", 2, 45.0m));
            sut.Promotions.Add(new Promotion_Two_for_Fixed_Price("C", "D", 30.0m));

            Assert.That(sut.ApplyPromotions(cart).CartTotal(), Is.EqualTo(280.0m));
        }



    }
}
