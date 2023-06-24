using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPro
{
    public class Fibo
    {
        public IEnumerable<int>? ReturnFiboSeries(int count)
        {
            int a =0,c;
            int b = 1;
            var resutl = new List<int>();
            if (count == 0)
            {
                 return null;
            }
            if (count == 1)
            {
                return new List<int>() { 0 };
            }
            resutl.Add(a);
            resutl.Add(b);
            for (int i = 0; i < count-2; i++)
            {
                c = a + b;
                resutl.Add(c);
                a = b;
                b = c;
            }
             return resutl;
        }
    }
}
