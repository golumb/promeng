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
    public class CartShould
    {
        private Cart sut;

        [SetUp]
        public void Setup()
        {
            sut = new Cart();
        }

        [Test]
        public void AddItems()
        {
            sut.Add("A", 1);
            Assert.That(sut.CartTotal(), Is.EqualTo(50.0m));
        }

        [Test]
        public void ApplyPromotion()
        {
            sut.Add("A", 1);
            sut.Add("B", 1);
            sut.Add("C", 1);
            sut.ApplyPromotion("A", 30.0m);   // not in the scenario, just testing

            Assert.That(sut.CartTotal(), Is.EqualTo(80.0m));
        }

        [Test]
        public void IsPromotionApplied()
        {
            sut.Add("A", 1);
            sut.Add("B", 1);
            sut.Add("C", 1);
            sut.ApplyPromotion("A", 30.0m);  // not in the scenario, just testing

            Assert.That(sut.IsPromotionApplied("A"), Is.True);
            Assert.That(sut.IsPromotionApplied("B"), Is.False);
        }

        [Test]
        public void DeepClone()
        {
            sut.Add("A", 1);
            sut.Add("B", 1);
            sut.Add("C", 1);

            var newCart = sut.DeepClone();
            newCart.ApplyPromotion("A", 30.0m); // not in the scenario, just testing

            Assert.That(sut.IsPromotionApplied("A"), Is.False);
            Assert.That(newCart.IsPromotionApplied("A"), Is.True);
            Assert.That(sut.CartTotal(), Is.EqualTo(100.0m));
            Assert.That(newCart.CartTotal(), Is.EqualTo(80.0m));

        }
    }
}
