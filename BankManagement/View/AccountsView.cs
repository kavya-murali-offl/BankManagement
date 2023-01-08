using BankManagement.Controller;
using BankManagement.Enums;
using BankManagement.Model;
using BankManagement.Models;

namespace BankManagement.View
{
    public class AccountsView
    {

        public void ViewAllAccounts(IList<Account> accounts)
        {
            if (accounts == null || accounts.Count() == 0)
            {
                Console.WriteLine("\n-------- NO ACCOUNTS FOUND --------\n");
            }
            else
            {
                Console.WriteLine("S.NO\t\tAccount Number\t\t\tBank Name\t\tBalance");
                for (int i = 0; i < accounts.Count(); i++)
                {
                    Console.WriteLine(i + 1 + ".  \t\t" + accounts[i].AccountID + "\t\t\t\t" + accounts[i].BankName + "\t\t" + accounts[i].Balance);
                }
            }
        }

        public void AccountSelection(ProfileController profile)
        {
            bool isValidOption = false;
            while (!isValidOption)
            {
                //Enum.GetName(typeof(AccountCases), entryOption - 1);
                Console.WriteLine("Enter your choice: ");
                try
                {
                    string option = Console.ReadLine();
                    int entryOption = int.Parse(option);

                    if (entryOption != 0 && entryOption <= profile.Accounts.Count())
                    {
                        Account account = profile.Accounts[entryOption - 1];
                    }
                    else
                    {
                        Console.WriteLine("Enter proper input.");
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine("Enter a valid option(Linked Account view)");
                }
            }
        }

        public Account CreateAccount()
        {
            Account acc;
            while (true)
            {
                Console.WriteLine("Choose Account type: \n1. Current Account \n2. Savings Account");
                Console.WriteLine("Enter your choice: ");
                acc = GetAccount();
                if (GoBack())
                {
                    break;
                }
            }
            return acc;

        }


        public Account GetAccount()
        {

            Account account = null;
            
            try
            {
                string option = Console.ReadLine();
                int entryOption = int.Parse(option);

                if (entryOption != 0 && entryOption <= Enum.GetNames(typeof(AccountTypesCases)).Count())
                {
                    string accountType = Enum.GetName(typeof(AccountTypesCases), entryOption - 1);
                    if (accountType == "CURRENT")
                    {
                        decimal amount = GetAmount();
                        account = new CurrentAccount(amount);
                    }
                    else if (accountType == "SAVINGS")
                    {
                        decimal interest = 5.6m;
                        Console.WriteLine("Interest Rate will be " + interest);
                        account = new SavingsAccount(interest);
                    }
                }
                else
                {
                    Console.WriteLine("Enter proper input.");
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Enter a valid option.");
            }
            return account; 
        }
        //    public int getAccountNumber()
        //    {
        //        Console.WriteLine("Enter Account Number: ");
        //        return sc.nextInt();
        //    }
        public bool GoBack()
        {
            Console.WriteLine("Press 0 to go back to dashboard");
            try
            {
                String input = Console.ReadLine();
                if (input != "0")
                {
                    Console.WriteLine("Enter a valid option");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Enter a valid option");
                return false;
            }
        }
        public decimal GetAmount()
        {
            Console.WriteLine("Enter Amount ");
            return Decimal.Parse(Console.ReadLine());
        }

        public void SuccessMessage(string message)
        {
            Console.WriteLine(message);
        }

        //    public void linkStatus(boolean status)
        //    {
        //        if (status)
        //        {
        //            Console.WriteLine("Account Linked Successfully");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Account Already linked");
        //        }
        //    }

        //    public int getAccountToBeDeleted()
        //    {
        //        while (true)
        //        {
        //            Console.WriteLine("\nSelect the account to be deleted: ");
        //            try
        //            {
        //                String input = sc.nextLine();
        //                return Integer.parseInt(input);
        //            }
        //            catch (Exception error)
        //            {
        //                Console.WriteLine("Invalid option. (Account to be deleted)");
        //            }
        //        }
        //    }

        //    public void removeStatus(boolean status)
        //    {
        //        if (status)
        //        {
        //            Console.WriteLine("Account removed Successfully");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Select from the linked accounts");
        //        }
        //    }
        //}

    }
}
