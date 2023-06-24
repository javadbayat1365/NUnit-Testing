
using CustomerPro;
using CustomerPro.Product;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerNUnitTests;

[TestFixture]
public class ProductNUnitTesting
{
    [Test,Order(2)]
    public void GetProductPrice_CustomerPlatinium_Return20PercentDiscount()
    {
        //arrange
        Customer customer = new Customer() { IsPlatinium = true };
        Product _product = new() { Price = 80 };
        //act
       var result = _product.GetDiscount(customer);

        //assert
        Assert.That(result,Is.EqualTo(64));
    }
    [Test,Order(1)]
    public void GetProductPriceMoqAbuse_CustomerPlatinium_Return20PercentDiscount()
    {
        //arrange
        var moqCustomer = new Mock<ICustomer>();
        moqCustomer.Setup(s => s.IsPlatinium).Returns(true);
        Product _product = new() {Price = 80 };
        //act
        var result = _product.GetDiscount(moqCustomer.Object);

        //assert
        Assert.That(result, Is.EqualTo(64));
    }
}
