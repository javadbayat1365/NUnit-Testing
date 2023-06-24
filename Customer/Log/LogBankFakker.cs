using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPro.Log
{
    public class LogBankFakker //: ILogBank
    {
        public bool BankAccountAfterWithdrow(int BalanceAfterWithdrow)
        {
            return true;
        }

        public void LogBankAccount(string Message)
        {
            
        }

        public bool LogToDB(string Message)
        {
            throw new NotImplementedException();
        }
    }
}
