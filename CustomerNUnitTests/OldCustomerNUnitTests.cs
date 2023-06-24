using CustomerPro;
using CustomerPro.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerNUnitTests
{
    [TestFixture]
    [Ignore("This test depricated")]
    internal class OldCustomerNUnitTests
    {
        private Customer customer; 
        [OneTimeSetUp]
        public void OneTime()
        {
            customer = new Customer() { IsPlatinium = true };
        }

        [Test, Order(2)]
        public void GetProductPrice_CustomerPlatinium_Return20PercentDiscount()
        {
            //arrange
            Product _product = new() { Price = 80 };
            //act
            var result = _product.GetDiscount(customer);
            //assert
            Assert.That(result, Is.EqualTo(64));
        }
    }
}
