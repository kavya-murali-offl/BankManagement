using BankManagement.Model;
using BankManagement.Models;
using BankManagement.Enums;
using BankManagement.Controller;
using BankManagement.Utility;

namespace BankManagement.View
{
    public enum DashboardCases
    {
        PROFILE,
        CREATE_ACCOUNT,
        LIST_ACCOUNTS, GO_TO_ACCOUNT, SIGN_OUT
    }

    public class DashboardView
    {
        public void ViewDashboard(ProfileController profileController, AccountsController accountsController)
        {
            while (true)
            {
                Console.WriteLine("\n" +
                    "1. Profile\n" +
                    "2. Create Account\n" +
                    "3. List Accounts\n" +
                    "4. Go to Account\n" +
                    "5. Sign out\n" +
                    "Enter your choice: \n");
                try
                {
                    string option = Console.ReadLine();
                    int entryOption = int.Parse(option);
                    if (entryOption != 0 && entryOption <= Enum.GetNames(typeof(DashboardCases)).Count())
                    {
                        DashboardCases operation = (DashboardCases)entryOption-1;
                        if (DashboardOperations(operation, profileController, accountsController))
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter proper input.");
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine("Enter a valid option. Try Again!");
                }
            }
        }

        private bool DashboardOperations(DashboardCases operation, ProfileController profileController, AccountsController accountController)
        {
            TransactionsView transactionView = new TransactionsView();
            switch (operation)
            {
                case DashboardCases.PROFILE:
                    ProfileView profileView = new ProfileView();
                    profileView.GetProfileDetails(profileController);
                    return false;
                case DashboardCases.CREATE_ACCOUNT:
                    accountController.CreateAccount(profileController);
                    return false;
                case DashboardCases.LIST_ACCOUNTS:
                    accountController.ViewAccounts(profileController);
                    return false;
                case DashboardCases.GO_TO_ACCOUNT:
                    Account transactionAccount = ChooseAccountForTransaction(profileController, accountController);
                    transactionView.GoToAccount(transactionAccount, profileController);
                    return false;
                case DashboardCases.SIGN_OUT:
                    Console.WriteLine(".....LOGGING YOU OUT.....");
                    return true;
                default:
                    Console.WriteLine("Enter a valid option.\n");
                    return false;
            }
        }


        public Account ChooseAccountForTransaction(ProfileController profileController, AccountsController accountController)
        {
            IList<Account> accounts = accountController.GetAccountsByUsername(profileController);
            ListAccountIDs(accounts);
            string index = Console.ReadLine();
            int accountIndex = int.Parse(index);
            return accountController.GetAccountByIndex(accountIndex, profileController);
        }

        public void ListAccountIDs(IList<Account> accounts)
        {
            for(int i = 1; i<accounts.Count()+1;i++)
            {
                Console.WriteLine(i + ". " + accounts[i-1].AccountID);
            }
        }

    }
}
