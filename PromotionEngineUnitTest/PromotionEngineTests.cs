using PromotionEngine;
using System;
using System.Collections.Generic;
using Xunit;

namespace PromotionEngineUnitTest
{
    public class PromotionEngineTests
    {
        readonly Cart _sut;
        public PromotionEngineTests()
        {
            _sut = new Cart();
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void TestCheckout(decimal amount, Dictionary<string, int> _cartItems, Dictionary<string, decimal> _products)
        {
            _sut.CartItemsQty = _cartItems;
            _sut.ProductValues = _products;
            Assert.Equal(amount, _sut.Checkout());
        }
        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] {100,new Dictionary<string, int>() {{"A",1 },{"B",1},{"C",1}}, new Dictionary<string, decimal>() { { "A", 50 }, { "B", 30 }, { "C", 20 } } };
        }
    }
}
