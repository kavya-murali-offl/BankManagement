using BankManagement.Model;
using BankManagement.Models;
using BankManagement.Enums;
using BankManagement.Controller;
using BankManagement.Utility;

namespace BankManagement.View
{
    public class DashboardView
    {

        public void ViewDashboard(ProfileController profileController, AccountsController accountsController)
        {
            while (true)
            {
                Console.WriteLine("\n1. Profile\n2. Create Account\n3. List Accounts\n 4. Go to Account\n5. Sign out\nEnter your choice: ");
                try
                {
                    string option = Console.ReadLine();
                    int entryOption = int.Parse(option);
                    if (entryOption != 0 && entryOption <= Enum.GetNames(typeof(DashboardCases)).Count())
                    {
                        string operation = Enum.GetName(typeof(DashboardCases), entryOption - 1);
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
                    Console.WriteLine("Enter a valid option. Try Again!(view dashboard)");
                }
            }
        }


        private bool DashboardOperations(string operation, ProfileController profileController, AccountsController accountController)
        {
            TransactionsView transactionView = new TransactionsView();
            switch (operation)
            {
                case "PROFILE":
                    ProfileView profileView = new ProfileView();
                    profileView.GetProfileDetails(profileController);
                    return false;
                case "CREATE_ACCOUNT":
                    accountController.CreateAccount(profileController);
                    return false;
                case "LIST_ACCOUNTS":
                    accountController.ViewAccounts(profileController);
                    return false;
                case "GO_TO_ACCOUNT":
                    Account transactionAccount = ChooseAccountForTransaction(profileController, accountController);
                    transactionView.GoToAccount(transactionAccount, profileController);
                    return false;
                case "SIGN_OUT":
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
