using CustomerPro;

namespace CustomerMsTest;

[TestClass]
public class CalculatorMSTests
{
    [TestMethod]
    public void AddNumbers_InputTwoInt_GetCorrectAddition()
    {
        //arrage
        Calculator cal = new Calculator();
        //act
        var result = cal.AddNumbers(30, 40);
        //assert
        Assert.AreEqual(70, result);
    }
}