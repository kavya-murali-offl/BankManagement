using BankManagement.Models;
using BankManagement.Utility;
using BankManagement.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Controller
{
    public class AccountsController
    {
        public AccountsController()
        {
            AccountData accountData = new AccountData();
            AccountData = accountData;
            AccountsView = new AccountsView();
        }

        public AccountData AccountData { get; set; }    
        public Account Account { get; set; }

        public AccountsView AccountsView { get; set; }

      
        public void ViewAccounts(ProfileController profile)
        {
            profile.Accounts = GetAccountsByUsername(profile);
            AccountsView.ViewAllAccounts(profile.Accounts);
        }

        public IList<Account> GetAccountsByUsername(ProfileController profile)
        {
            return AccountData.GetAccountsByUsername(profile.UserName);
        }

        public Account GetAccountByIndex(int index, ProfileController profile)
        {
            return profile.Accounts[index - 1];
        }


        public void CreateAccount(ProfileController profile)
        {
            Account account = AccountsView.CreateAccount();
            if (account != null)
            {
                AddAccount(profile.UserName, account);
                profile.Accounts = AccountData.GetAccountsByUsername(profile.UserName);
                AccountsView.SuccessMessage("Account created Successfully");
            }
        }

        public void AddAccount(string userName, Account account)
        {
            AccountData.AddAccount(userName, account);
        }

}
}
