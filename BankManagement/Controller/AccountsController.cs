using System;
using BankManagement.Models;
using BankManagement.Utility;
using BankManagement.View;


namespace BankManagement.Controller
{
    public class AccountsController
    {
        public AccountsController()
        {
            AccountData = new AccountData(); ;
            AccountsView = new AccountsView();
        }

        public AccountData AccountData { get; set; }

        public AccountsView AccountsView { get; set; }

        public void CreateAccount(ProfileController profile)
        {
            Account account = AccountsView.GenerateAccount();
            if (account != null)
            {
                AddAccountToUserName(profile.UserName, account);
                profile.Accounts = AccountData.GetAccountsByUsername(profile.UserName);
                AccountsView.AccountCreatedSuccessMessage();
            }
            else
            {
                throw new ArgumentNullException("Something went wrong in creating the account.");
            }
        }

        public void AddAccountToUserName(string userName, Account account)
        {
            AccountData.AddAccount(userName, account);
        }

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
    }
}
