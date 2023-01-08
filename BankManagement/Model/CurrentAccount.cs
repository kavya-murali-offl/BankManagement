using BankManagement.Models;
using System;

namespace BankManagement.Model
{
    public class CurrentAccount : Account
    {
        private readonly decimal MIN_BALANCE = 5000;
        private decimal Charges = 200;
        public CurrentAccount(decimal initialAmount) {
            Balance = initialAmount;
        }

        public void Deposit(decimal amount)
        {
            base.Deposit(amount);
        }

        public void Withdraw(decimal amount)
        {
            bool validTransaction = CheckMinimumBalance(amount);
            if (validTransaction)
                base.Withdraw(amount);
            else
                base.Withdraw(amount - Charges);
        }

        public bool CheckMinimumBalance(decimal amount)
        {
            if (Balance - amount < MIN_BALANCE)
                return false;
            return true;

        }
        public decimal MinimumBalance { get; }

    }
}
