

using BankManagement.Controller;
using BankManagement.Enums;
using BankManagement.Models;
using BankManagement.Utility;

namespace BankManagement.View
{
    public class TransactionsView
    {
        public void GoToAccount(Account account, ProfileController profile)
        {
            while (true)
            {
                Console.WriteLine("\n1. Deposit \n2. Withdraw\n3. Transfer\n4. View Statement\n5. Print Statement\n6. Back \nEnter your choice: ");
                try
                {
                    string option = Console.ReadLine();
                    int entryOption = int.Parse(option);
                    if (entryOption != 0 && entryOption <= Enum.GetNames(typeof(AccountCases)).Count())
                    {
                        string operation = Enum.GetName(typeof(AccountCases), entryOption - 1);
                        if (TransactionOperations(operation, account, profile))
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

        public bool TransactionOperations(string option, Account account, ProfileController profile)
        {
            Helper helper = new Helper();
            decimal amount;
            switch (option)
            {
                case "DEPOSIT":
                    amount = helper.GetAmount();
                    account.Deposit(amount);
                    return true;
                case "WITHDRAW":
                    amount = helper.GetAmount();
                    account.Withdraw(amount);
                    return true;
                case "TRANSFER":
                    amount = helper.GetAmount();
                    string accountID = GetTransferAccountID();
                    Account transferAccount = profile.GetAccountByID(accountID);
                    account.Transfer(amount, transferAccount);
                    return true;
                case "VIEW_STATEMENT":
                    return false;
                case "PRINT_STATEMENT":
                    return false;
                case "BACK":
                    return true;
                default:
                    Console.WriteLine("Invalid option");
                    return false;
            }
        }

        public string GetTransferAccountID()
        {
            while (true)
            {
                Console.WriteLine("Enter Account ID to transfer: ");
                try
                {
                    return Console.ReadLine();
                }
                catch (Exception error)
                {
                    Console.WriteLine("Enter a valid amount. Try Again!(incoming view)");
                }
            }
        }
    }
}
