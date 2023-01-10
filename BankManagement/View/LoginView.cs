using System;
using BankManagement;
using BankManagement.Models;
using BankManagement.Controller;
using BankManagement.Utility;

namespace BankManagement.View
{
    public class LoginView
    {

        public LoginView() { }

        public void Login(CustomersController customersController, AccountsController accountController)
        {
            bool isValidated;
            string userName = GetUserName();
            String password = GetPassword();
            isValidated = ValidateLogin(userName, password, customersController);

            if (isValidated)
            {
                ProfileController profile = new ProfileController();
                profile.Customer = customersController.GetUserDetails(userName);
                profile.Accounts = accountController.GetAccountsByUsername(profile);
                DashboardView dashboard = new DashboardView();
                dashboard.ViewDashboard(profile, accountController);
            }
        }

        public String GetUserName()
        {
            Console.WriteLine("Enter UserName: ");
            return Console.ReadLine();
        }

        public String GetPassword()
        {
            Console.WriteLine("Enter password: ");
            return Console.ReadLine();
        }

        public bool ValidateLogin(string username, string password, CustomersController customersController)
        {

            Helper helpers = new Helper();

            if (helpers.LoginValidation(username, password, customersController))
            {
                Console.WriteLine("Logged in successfully");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid login credentials. Try Again!");
            }
            return false;

        }
    }
}
