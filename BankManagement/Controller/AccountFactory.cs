using BankManagement.Enums;
using BankManagement.Model;
using BankManagement.Models;
using BankManagement.Utility;
using System;

namespace BankManagement.Controller
{
    public static class AccountFactory
    {

        public static Account GetAccountByType(string accountType)
        {
            if (accountType == "CURRENT")
            {
                Helper helper = new Helper();
                decimal amount = helper.GetAmount();
                CurrentAccount currentAccount = new CurrentAccount();
                currentAccount.Balance= amount; 
                return currentAccount;
            }
            else if (accountType == "SAVINGS")
            {
                SavingsAccount savingsAccount = new SavingsAccount();
                return savingsAccount;
            }
            else return null;   
        }
    }
}
