using CustomerPro.Log;

namespace CustomerPro.Bank
{
    public class BankAccount
    {
        private readonly ILogBank _logBank;

        public int BankBalance { get; set; }
        public BankAccount(ILogBank logBank)
        {
            this._logBank = logBank;
        }

        public bool Deposit(int amount)
        {
            _logBank.LogBankAccount("Deposit Done");
            BankBalance += amount;
            return true;
        }
        public bool Withdrow(int amount)
        {
            if (amount <= BankBalance)
            {
                _logBank.LogBankAccount($"Withdrow Done By: {amount}");
                BankBalance -= amount;
                return _logBank.BankAccountAfterWithdrow(BankBalance);
            }
            return _logBank.BankAccountAfterWithdrow(BankBalance-amount);
        }
    }
}
