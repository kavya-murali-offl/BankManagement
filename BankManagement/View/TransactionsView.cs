

using BankManagement.Controller;
using BankManagement.Enums;
using BankManagement.Model;
using BankManagement.Models;
using BankManagement.Utility;

namespace BankManagement.View
{
    public enum AccountCases
    {
        DEPOSIT, WITHDRAW, TRANSFER, VIEW_STATEMENT, PRINT_STATEMENT, BACK
    }

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
            TransactionController transactionController = new TransactionController();  
            decimal amount;
            switch (option)
            {
                case "DEPOSIT":
                    bool isDeposited = transactionController.Deposit(account);
                    if (isDeposited) Console.WriteLine("Deposit succesful");
                    else Console.WriteLine("Something went wrong.");
                    return true;
                case "WITHDRAW":
                    bool isWithdrawn = transactionController.Withdraw(account);
                    if (isWithdrawn) Console.WriteLine("Withdraw succesful");
                    else Console.WriteLine("Something went wrong.");
                    return true;
                case "TRANSFER":
                    string transferAccountID = GetTransferAccountID();
                    bool isTransferred = transactionController.Transfer(account, transferAccountID, profile);
                    if (isTransferred) Console.WriteLine("Transfer succesful");
                    else Console.WriteLine("Something went wrong.");
                    return true;
                case "VIEW_STATEMENT":
                    ViewStatement(transactionController, account);
                    return false;
                case "PRINT_STATEMENT":
                    Printer.PrintStatement(account.Transactions);
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

        public void ViewStatement(TransactionController transactionController, Account account)
        {
            IList<Transaction> transactions = transactionController.GetAllTransactions(account);
            if (transactions.Count > 0)
            {
                foreach (Transaction transaction in transactions) { Console.WriteLine(transaction); }
            }
        }

        public void PrintStatement(TransactionController transactionController, Account account)
        {
            IList<Transaction> transactions = transactionController.GetAllTransactions(account);
            if (transactions.Count > 0)
            {
                foreach (Transaction transaction in transactions) { Console.WriteLine(transaction); }
            }
        }
    }
}
