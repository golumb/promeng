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
    public class EngineMathsShould
    {
        [Test]
        [TestCase(3, ExpectedResult = 6)]
        [TestCase(4, ExpectedResult = 24)]
        [TestCase(5, ExpectedResult = 120)]
        [TestCase(6, ExpectedResult = 720)]
        public int NumberofPermutationIsFactorial(int n)
        {
            return EngineMaths.GetAllPermutaions(n).Length;
        }
    }
}
