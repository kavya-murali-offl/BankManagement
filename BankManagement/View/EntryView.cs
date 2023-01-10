

using BankManagement.Controller;
using BankManagement.Utility;

namespace BankManagement.View
{
    public enum EntryOptions
    {
        LOGIN, SIGNUP, EXIT
    }
    public class EntryView
    {
        public void Entry()
        {
            
            CustomersController customersController = new CustomersController();
            AccountsController accountsController = new AccountsController();
            while (true)
            {
                Console.WriteLine("1.Login\n2.Signup\n3.Exit\nEnter your choice: ");
                try
                {
                    string? option = Console.ReadLine();
                    int entryOption = int.Parse(option);
                    if (entryOption != 0 && entryOption <= Enum.GetValues(typeof(EntryOptions)).Length)
                    {
                        EntryOptions entry = (EntryOptions)entryOption - 1;
                        if (EntryOperations(entry, customersController, accountsController))
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter proper input.");
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine("Enter a valid option. Try Again!");
                }
            }
        }
        

        public bool EntryOperations(EntryOptions option, CustomersController customersController, AccountsController accountsController)
        {

            switch (option)
            {
                case EntryOptions.LOGIN:
                    LoginView loginView = new LoginView();
                    loginView.Login(customersController, accountsController);
                    return false;
                case EntryOptions.SIGNUP:
                    SignupView signupView = new SignupView();
                    signupView.Signup(customersController, accountsController);
                    return false;
                case EntryOptions.EXIT:
                    Console.WriteLine("Closed");
                    return true;
                default:
                    Console.WriteLine("Enter valid option. Try Again!");
                    return false;
            }
        }
        
    }
}
