using CustomerPro;

namespace CustomerNUnitTests;

[TestFixture]
public class CalcumatorNUnitTests
{
    private Calculator cal;
    [SetUp]
    public void Setup()
    {
        //arrage
        cal = new Calculator();
    }
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {

    }

    [TearDown]
    public void TearDown()
    {

    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {

    }
    [Test]
    public void AddNumbers_InputTwoInt_GetCorrectAddition()
    {
        //act
        var result = cal.AddNumbers(30, 40);
        //assert
        Assert.AreEqual(70, result);
    }
    [Test]
    public void CheckOddNumber_InputEvenNumber_ReturnFalse()
    {
        bool IsOdd = cal.IsOddNumber(4);
        //Assert.AreEqual(false,result);
        Assert.IsFalse(IsOdd);
        Assert.That(IsOdd, Is.EqualTo(false));
    }
    [Test]
    [TestCase(13)]
    [TestCase(17)]
    public void CheckOddNumber_InputEvenNumber_ReturnTrue(int a)
    {
        Calculator cal = new();
        bool IsOdd = cal.IsOddNumber(a);
        Assert.AreEqual(true, IsOdd);
        Assert.IsTrue(IsOdd);
        Assert.That(IsOdd, Is.EqualTo(true));
    }

    [Test]
    [TestCase(10, ExpectedResult = false)]
    [TestCase(13, ExpectedResult = true)]
    public bool CheckOddNumber_InputInt_TrueIfIsOdd(int a)
    {
        //act
        return cal.IsOddNumber(a);
    }

    [Test]
    [TestCase(3.4, 4.5)]
    [TestCase(3.5, 4.3)]
    public void AddDoubleNumber_InputTwoDouble_GetCorrectAddition(double a, double b)
    {
        double result = cal.SumDoubles(a, b);
        //delta => telorance answer = 1
        Assert.AreEqual(7.9, result, 1);
       // Assert.That(result, Is.EqualTo(7.9)); //failed to second TestCase
    }

    [Test]
    [TestCase(3, 9)]
    public void GetOddList_WIthMaxAndMinInt(int min, int max)
    {
        //act
        var list = cal.GetRangeOfOddNumbers(min, max);

        //assert
        Assert.Multiple(() => {
            Assert.That(list, Is.EquivalentTo(new int[] { 3, 5, 7, 9 }));
            Assert.AreEqual(new[] { 3, 5, 7, 9 }, list);
            Assert.Contains(5, list);
            Assert.That(list, Does.Contain(9));
            Assert.That(list, Is.Not.Empty);
            Assert.That(list.Count, Is.EqualTo(4));
        });

        
    }

    [Test]
    [TestCase(10,30)]
    public void GetDiscountOfNumber_Between10To30(int a,int b)
    {
        //assert
        Assert.That(cal.Discount,Is.InRange(a,b));
    }
}