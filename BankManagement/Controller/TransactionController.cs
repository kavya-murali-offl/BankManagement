using BankManagement.Enums;
using BankManagement.Models;
using BankManagement.Utility;
using BankManagement.View;
using System;


namespace BankManagement.Controller
{
    public class TransactionController
    {

        public void GoToAccount(Account account, ProfileController profile)
        {
            while (true)
            {
                Console.WriteLine("\n1.Deposit \n2.Withdraw\n3.View Statement\n4. Print Statement\n5.Back \nEnter your choice: ");
                try
                {
                    string option = Console.ReadLine();
                    int entryOption = int.Parse(option);
                    if (entryOption != 0 && entryOption <= Enum.GetNames(typeof(AccountCases)).Count())
                    {
                        foreach (var opt in Enum.GetNames(typeof(AccountCases)))
                        {
                            Console.WriteLine(opt);
                        }
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
        public void Transact(decimal amount, TransactionType transactionType, Account account)
        {
           
        }

        public bool TransactionOperations(string option, Account account, ProfileController profile)
        {
            AccountController accountController = new AccountController();
            Helper helper = new Helper();
            switch (option)
            {
                case "DEPOSIT":
                    TransactionController transactionController = new TransactionController();
                    decimal amount = helper.GetAmount();
                    transactionController.Transact(amount, TransactionType.DEPOSIT, account);
                    accountController.Deposit(profile);
                    return false;
                case "WITHDRAW":
                    accountController.Withdraw(profile);
                    return false;

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

    }
}
