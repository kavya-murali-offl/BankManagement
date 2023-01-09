using BankManagement.Enums;
using BankManagement.Models;
using System;

namespace BankManagement.Model
{
    public class CurrentAccount : Account
    {
        private readonly decimal MIN_BALANCE = 5000;
        private decimal Charges = 200;
        private readonly AccountTypesCases ACCOUNT_TYPE = AccountTypesCases.SAVINGS;

        public void Deposit(decimal amount)
        {
            base.Deposit(amount);
        }

        public void Withdraw(decimal amount)
        {
            bool validTransaction = CheckMinimumBalance(amount);
            if (validTransaction)
                Withdraw(amount);
            else
                Withdraw(amount - Charges);
        }

        public bool CheckMinimumBalance(decimal amount)
        {
            if (Balance - amount < MIN_BALANCE)
                return false;
            return true;

        }
        public decimal MinimumBalance { get { return MIN_BALANCE; } }

        public AccountTypesCases AccountType { get { return ACCOUNT_TYPE; } }

        public override string ToString()
        {
            return "Account Type: Current\n"+ "Account ID: " + AccountID + "\nBalance: " + Balance + "\nMinimum Balance: " + MinimumBalance+ "\n========================================\n";
        }

    }
}
