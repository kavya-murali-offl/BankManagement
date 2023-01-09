using BankManagement.Enums;
using BankManagement.Model;
using BankManagement.Models;
using BankManagement.Utility;
using System;

namespace BankManagement.Controller
{
    public class AccountFactory
    {
        private readonly decimal SAVINGS_INTEREST_RATE = 5.6m;
        Helper helper = new Helper();

        public Account GetAccountByType(string accountType)
        {
            if (accountType == "CURRENT")
            {
                decimal amount = helper.GetAmount();
                CurrentAccount currentAccount = new CurrentAccount();
                currentAccount.Balance= amount; 
                return currentAccount;

            }
            else if (accountType == "SAVINGS")
            {
                SavingsAccount account = new SavingsAccount();
                account.InterestRate = SAVINGS_INTEREST_RATE;
                return account;

            }
            else return null;   
        }
    }
}
