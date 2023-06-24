using CustomerPro;
using CustomerPro.Bank;
using CustomerPro.Log;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerNUnitTests;

[TestFixture]
public class BankAccountNUnitTesting
{
    private BankAccount account;
    [SetUp]
    public void Setup()
    {

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

    #region Fack Class
    //[Test]
    //public void BankDeposit_LogFakker_Add100_ReturnTrue()
    //{
    //    //arrange
    //   var bankAccount = new BankAccount(new LogBankFakker());
    //    //act 
    //    var result = bankAccount.Deposit(100);

    //    //assert
    //    Assert.IsTrue(result);
    //    Assert.That(bankAccount.BankBalance,Is.EqualTo(100));
    //}
    #endregion

    [TestCase(100)]
    public void BankDeposit_Add100_ReturnTrue(int a)
    {
        //arrange
        var logmock = new Mock<ILogBank>();
        var bankAccount = new BankAccount(logmock.Object);
        //act 
        var result = bankAccount.Deposit(a);

        //assert
        Assert.IsTrue(result);
        Assert.That(bankAccount.BankBalance, Is.EqualTo(100));
    }

    [Test]
    [TestCase(400, 370)]
    public void BankWithdrow_100From200Balance_ReturnTrue(int Balance, int Withdrow)
    {
        //arrange
        var logMock = new Mock<ILogBank>();
        logMock.Setup(s => s.LogToDB(It.IsAny<string>())).Returns(true);
        logMock.Setup(s => s.BankAccountAfterWithdrow(It.Is<int>(a => a >= 0))).Returns(true);
        BankAccount bankAccount = new BankAccount(logMock.Object);
        //act
        bankAccount.Deposit(Balance);
        var result = bankAccount.Withdrow(Withdrow);
        //assert
        Assert.IsTrue(result);
    }

    [Test]
    public void BankWithdrow_300From200Balance_ReturnFalse()
    {
        //arrange
        var mock = new Mock<ILogBank>();
        mock.Setup(s => s.BankAccountAfterWithdrow(It.Is<int>(a => a < 0)))
            .Returns(false);
        //act
        BankAccount bankAccount = new(mock.Object);
        bankAccount.Deposit(200);
        var result = bankAccount.Withdrow(300);

        //assert
        Assert.IsFalse(result);
    }

    [Test]
    public void BankLogDummy_ILogBankReturnStr_ReturnTrue()
    {
        //arrange
        var mock = new Mock<ILogBank>();
        mock.Setup(s => s.LogAndReturnStr(It.IsAny<string>()))
            .Returns((string str) => str.ToLower());
        //act

        //assert
        Assert.That(mock.Object.LogAndReturnStr("Hello"), Is.EqualTo("hello"));
    }

    [Test]
    public void Bank_OutputParametersWithoutMoQ_ReturnTrue()
    {
        //arrange
        //var mock = new Mock<ILogBank>();
        var log = new LogBank();
        //string DesireOutput;
        //mock.Setup(s => s.LogWithOutputResult(It.IsAny<string>(),out DesireOutput));
        //act

        //assert
        string result;
        log.LogWithOutputResult("javad", out result);
        Assert.That(result, Is.EqualTo("Hello javad"));
    }
    [Test]
    public void Bank_OutputParametersWithMoQ_ReturnTrue()
    {
        //arrange
        var mock = new Mock<ILogBank>();
        string DesireOutput;
        mock.Setup(s => s.LogWithOutputResult(It.IsAny<string>(), out DesireOutput));
        //act
        string result;
        mock.Object.LogWithOutputResult("javad", out result);
        //assert
        Assert.That(result, Is.EqualTo("Hello javad"));
    }
    [Test]
    public void BankLogDummy_ReturnRefParam_ReturnTrue()
    {
        //arrange
        var mock = new Mock<ILogBank>();
        Customer customer = new();
        Customer customerNoThing = new();
        mock.Setup(a => a.LogWithRef(ref customer)).Returns(true);

        //act
        Assert.IsFalse(mock.Object.LogWithRef(ref customerNoThing));
        Assert.IsTrue(mock.Object.LogWithRef(ref customer));
    }

    [Test]
    public void BankLogDummy_SetAllProperties_ReturnTrue()
    {
        //arrange
        var mock = new Mock<ILogBank>();


        mock.Setup(a => a.Count).Returns(17);
        mock.Setup(a => a.BankName).Returns("Bayat");

        mock.SetupAllProperties();
        mock.Object.Count = 20;
        mock.Object.BankName = "Javad";
        //act
        Assert.That(mock.Object.Count, Is.EqualTo(20));
        Assert.That(mock.Object.BankName, Is.EqualTo("Javad"));
    }

    [Test]
    [TestCase("Javad")]
    public void BankLogDummy_CallbackMoq_ReturnTrue(string FName)
    {
        //arrange
        var mock = new Mock<ILogBank>();
        string name = "Hello, ";
        int count = 5;
        mock.Setup(u => u.LogToDB(It.IsAny<string>()))
            .Callback((string str) =>  name += str)
            .Returns(true)
            .Callback(()=> count++);
        Assert.Multiple(() => { 
            Assert.That(mock.Object.LogToDB(FName),Is.EqualTo(true));
            Assert.That(name, Is.EqualTo($"Hello, {FName}"));
            Assert.That(count, Is.EqualTo(6));
        });

    }
}
