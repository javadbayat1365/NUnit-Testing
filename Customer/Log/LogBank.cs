using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPro.Log
{
    public class LogBank : ILogBank
    {
        public int Count { get ; set ; }
        public string BankName { get ; set ; }

        public bool BankAccountAfterWithdrow(int Amount)
        {
            if (Amount >= 0)
            {
                Console.WriteLine("Success");
                return true;
            }
            Console.WriteLine("Failure");
            return false;
        }

        public string LogAndReturnStr(string message)
        {
            Console.WriteLine(message);
            return message.ToLower();
        }

        public void LogBankAccount(string Message)
        {
            Console.WriteLine(Message);
        }

        public bool LogToDB(string Messaged)
        {
            Console.WriteLine(Messaged);
            return true;
        }

        public void LogWithOutputResult(string str, out string output)
        {
            Console.WriteLine(str);
            output = $"Hello {str}";
        }

        public bool LogWithRef(ref Customer customer)
        {
            return true;
        }
    }
}
