using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPro
{
    public interface ICustomer
    {
         string CustomerName { get; set; }
         int TotlaOrder { get; set; }
         bool IsPlatinium { get; set; }

       public string GreetingCombinationName(string FName, string LName);

        CustomerType.CustomerType GetCustomerType();
    }

    public class Customer:ICustomer
    {
        public string CustomerName { get; set; }
        public bool IsPlatinium { get; set; } = false;
        public int TotlaOrder { get; set; }

        public string GreetingCombinationName(string FName, string LName)
        {
            if (string.IsNullOrWhiteSpace(FName))
            {
                throw new ArgumentException("Fname is Empty");
            }
            CustomerName = $"Hello, {FName} {LName}";
            return CustomerName;
        }

        public CustomerType.CustomerType GetCustomerType()
        {
            if (TotlaOrder < 100)
            {
                return new CustomerType.BasicCustomer();
            }
            return new CustomerType.PleniumCustomer();
        }
    }
}
