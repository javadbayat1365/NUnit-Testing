namespace CustomerPro.Log
{
    public interface ILogBank
    {
        public int Count { get; set; }
        public string BankName { get; set; }
        void LogBankAccount(string Message);
        bool BankAccountAfterWithdrow(int BalanceAfterWithdrow);
        bool LogToDB(string Message);
        string LogAndReturnStr(string message);
        void LogWithOutputResult(string str,out string output);
        bool LogWithRef(ref Customer customer);
    }
}