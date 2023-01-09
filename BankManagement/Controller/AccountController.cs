using BankManagement.Models;
using BankManagement.Utility;
using BankManagement.View;

namespace BankManagement.Controller
{
    public class AccountController
    {
       public AccountController() {
            //Account = new Account();
            AccountsView = new AccountsView();
        }

        public Account Account { get; set; }

        public AccountsView AccountsView { get; set; }

        public void GetAccounts(ProfileController profile, AccountData accountData) {
            profile.Accounts = accountData.GetBankDetails(profile.UserName);
        }

        public void ViewAccounts(ProfileController profile, AccountData accountData)
        {
            GetAccounts(profile, accountData);
            AccountsView.ViewAllAccounts(profile.Accounts);
        }

        public Account GetAccountByIndex(int index, ProfileController profile)
        {
            return profile.Accounts[index - 1];
        }

        public void CreateAccount(ProfileController profile, AccountData accountData)
        {
            Account account = AccountsView.CreateAccount();
            if(account != null)
            {
                accountData.AddAccount(profile.UserName, account);
                profile.Accounts = accountData.GetBankDetails(profile.UserName);
                AccountsView.SuccessMessage("Account created Successfully");
            }
        }

        public void Deposit(ProfileController profile) { }

        public void Withdraw(ProfileController profile) { }
    }
}
