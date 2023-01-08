using System;
using BankManagement.Enums;
using BankManagement.Model;
using BankManagement.Models;

namespace BankManagement.Utility
{
    public class AccountData
    {
        public AccountData() {
            Account currentAccount1 = new CurrentAccount(5000);
            currentAccount1.AccountID = Guid.NewGuid();
            currentAccount1.BankName = BankName.HDFC;
            IDictionary<string, IList<Account>> AccountsDict = new Dictionary<string, IList<Account>>();
            List<Account> userAccountsList = new List<Account>();
            userAccountsList.Add(currentAccount1);
            AccountsDict.Add("kav", userAccountsList);
            Accounts = AccountsDict;
        }

        public IList<Account> GetBankDetails(string username)
        {
            if (Accounts.ContainsKey(username)) return Accounts[username];
            else return null;
        }

        public void AddAccount(string username, Account account)
        {
            if (Accounts.ContainsKey(username)) { 
                Accounts[username].Add(account);
            }
            else
            {
                IDictionary<string, IList<Account>> userAccounts = new Dictionary<string, IList<Account>>();
                IList<Account> accounts = new List<Account>();
                accounts.Add(account);
                userAccounts.Add(username, accounts);
                Accounts = userAccounts;
            }
        }

        public IDictionary<string, IList<Account>> Accounts { get; set; }
    }
}
