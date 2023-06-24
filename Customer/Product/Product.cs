using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPro.Product
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }


        public double GetDiscount(Customer customer)
        {
            if (customer.IsPlatinium)
            {
                return Price * 0.8;
            }
            return Price;
        }

        public double GetDiscount(ICustomer customer)
        {
            if (customer.IsPlatinium)
            {
                return Price * 0.8;
            }
            return Price;
        }
    }
}
