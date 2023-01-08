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

        public void Login()
        {
            bool isValidated;
            string input = GetUserName();
            String password = GetPassword();
            isValidated = ValidateLogin(input, password);

            if (isValidated)
            {
                ProfileController profile = new ProfileController();
                profile.GetUserDetails(input);
                AccountData accountData = new AccountData();
                profile.Accounts = accountData.GetBankDetails(profile.UserName);
                DashboardView dashboard = new DashboardView();
                dashboard.ViewDashboard(profile, accountData);
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

        public bool ValidateLogin(string username, string password)
        {
            //Helpers helpers = new Helpers();

            //if (helpers.LoginValidation(username, password))
            //{
            //    Console.WriteLine("Logged in successfully");
            //    return true;
            //}
            //else
            //{
            //    Console.WriteLine("Invalid login credentials. Try Again!");
            //}
            return true;

        }
    }
}
