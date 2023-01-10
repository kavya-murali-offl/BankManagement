using System;
using BankManagement.Enums;
using BankManagement.Model;
using BankManagement.Models;

namespace BankManagement.Utility
{
    public class AccountData
    {
        public AccountData() {
            IDictionary<string, IList<Account>> AccountsDict = new Dictionary<string, IList<Account>>();
            AllUsersAccounts = AccountsDict;
        }

        public IList<Account> GetAccountsByUsername(string username)
        {
            if (AllUsersAccounts.ContainsKey(username)) return AllUsersAccounts[username];
            else return null;
        }

        public void AddAccount(string username, Account account)
        {
            if (AllUsersAccounts.ContainsKey(username)) {
                AllUsersAccounts[username].Add(account);
            }
            else
            {
                IList<Account> userAccounts = new List<Account>();
                userAccounts.Add(account);
                AllUsersAccounts.Add(username, userAccounts);
            }
        }

        public IDictionary<string, IList<Account>> AllUsersAccounts { get; set; }
    }
}
