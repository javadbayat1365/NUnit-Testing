using CustomerPro;
using CustomerPro.CustomerType;


namespace CustomerNUnitTests;

[TestFixture]
public class CustomerNUnitTests
{
    private Customer customer;
    [SetUp]
    public void setUp()
    {
        customer = new Customer();
    }
    public CustomerNUnitTests()
    {
        //this.customer = customer;
    }
    [Test]
    [TestCase("Javad", "Bayat")]
    public void CombineName_InputFNameAndLName_ReturnFullName(string FName, string LName)
    {
        customer.GreetingCombinationName(FName, LName);
        Assert.Multiple(() => {
            Assert.That(customer.CustomerName, Is.EqualTo("Hello, javaD baYat").IgnoreCase);
            Assert.That(customer.CustomerName, Does.StartWith("Hello,"));
            Assert.That(customer.CustomerName, Does.Contain(","));
            Assert.That(customer.CustomerName, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        });

        
    }

    [Test]
    public void GreetingMessage_NoGreeting_returnNull()
    {
        //customer.GreetingCombinationName("Hamid","Bayat");
        Assert.IsNull(customer.CustomerName);
    }

    [Test]
    public void GreetingMessage_WithoutLastName_ReturnNotNull()
    {
        customer.GreetingCombinationName("javad","");
        Assert.IsNotNull(customer.CustomerName);
        Assert.IsFalse(string.IsNullOrWhiteSpace(customer.CustomerName));
    }


    [Test]
    public void GreetingMessage_WithoutFname_ReturnException()
    {
        var exception = Assert.Throws<ArgumentException>(() =>
        customer.GreetingCombinationName("", "bayat"));
        Assert.AreEqual("Fname is plenty", exception.Message);

        //OR 

        Assert.That(()=>customer.GreetingCombinationName("","bayat"),
            Throws.Exception.Message.EqualTo("Fname is plenty"));
    }

    [Test]
    public void GreetingMessage_WithoutFname_ArgumentExceptionReturn()
    {
        Assert.Throws<ArgumentException>(() =>
        customer.GreetingCombinationName("", "bayat"));

        //OR 

        Assert.That(() => customer.GreetingCombinationName("", "bayat"),
            Throws.Exception);
    }

    [Test]
    public void CustomerType_OrderIdLessThan100_ReturnBasicCustomer()
    {
        customer.TotlaOrder = 10;
        Assert.That(customer.GetCustomerType(), Is.TypeOf<BasicCustomer>());
    }

    [Test]
    [TestCase(110)]
    public void CustomerType_OrderIdMoreThan100_ReturnPleniumCustomer(int a)
    {
        customer.TotlaOrder = a;
        var result = customer.GetCustomerType();
        Assert.That(result, Is.TypeOf<PleniumCustomer>());
    }
}
