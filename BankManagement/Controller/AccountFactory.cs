using BankManagement.Enums;
using BankManagement.Model;
using BankManagement.Models;
using BankManagement.Utility;
using System;
using System.Security.Principal;

namespace BankManagement.Controller
{
    public static class AccountFactory
    {

        public static Account GetAccountByType(AccountTypes accountType)
        {
            if (accountType == AccountTypes.CURRENT)
            {
                Helper helper = new Helper();
                decimal amount = helper.GetAmount();
                CurrentAccount currentAccount = new CurrentAccount();
                currentAccount.Balance= amount;
                currentAccount.Transactions.Add(new Transaction(amount, amount, TransactionTypes.DEPOSIT));
                return currentAccount;
            }
            else if (accountType == AccountTypes.SAVINGS)
            {
                SavingsAccount savingsAccount = new SavingsAccount();
                return savingsAccount;
            }
            else return null;   
        }
    }
}
