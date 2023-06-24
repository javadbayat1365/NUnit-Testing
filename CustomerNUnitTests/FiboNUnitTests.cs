using CustomerPro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerNUnitTests;

[TestFixture]
public class FiboNUnitTests
{
    Fibo fibo;
    [SetUp]
    public void Setup()
    {
        //arrange
        fibo = new Fibo();
    }

    [Test]
    public void Fibo_SetNumber_ReturnFibo()
    {
        //act
        var result = fibo.ReturnFiboSeries(5);
        var expected = new[] { 0, 1, 1, 2, 3 };
        //assert
        Assert.Multiple(() => {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(5));
            Assert.IsTrue(result.Contains(3));
            Assert.That(result,Does.Contain(3));
            Assert.That(result,Is.Ordered);
            Assert.That(result, Is.EqualTo(new[] {0,1,1,2,3 }));
            Assert.That(result, Is.EquivalentTo(expected));
            Assert.IsTrue(!result.Contains(4));
        });
        
    }
}
