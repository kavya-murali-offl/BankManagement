using BankManagement.Controller;
using BankManagement.Models;
using BankManagement.Utility;
using BankManagement.View;
using System;

namespace BankManagement.View
{
    public class SignupView
    {

        public void Signup(CustomersData customersData, AccountData accountData)
        {
            Validation validation = new Validation();
            string email;
            string password;
            string name;
            string userName;

            while (true)
            {
                userName = GetUsername();
                if (validation.CheckEmpty(userName))
                {
                    if (validation.CheckUnique(userName, "Username"))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Username Already Exists");
                        return;
                    }
                }
            }

            do
            {
                password = GetPassword();
            } while (!validation.CheckEmpty(password));

            VerifyPassword(password);
            name = GetName();
            AccountFactory accountFactory = new AccountFactory();
            Account account = accountFactory.GetAccountByType("CURRENT");
            customersData.AddCustomer(userName, password, name);
            accountData.AddAccount(userName, account);
            Console.WriteLine("Account created Successfully.\n Please Login to contine");

        }

        private string GetUsername()
        {
            Console.WriteLine("Create a unique User Name: ");
            return Console.ReadLine();
        }

        private string GetName()
        {
            Console.WriteLine("Name: ");
            return Console.ReadLine();
        }


        private string GetRePassword()
        {
            Console.WriteLine("Re-enter password: ");
            return Console.ReadLine();
        }


        public string GetPassword()
        {
            Console.WriteLine("Enter password: ");
            return Console.ReadLine();
        }

        public void VerifyPassword(string password)
        {
            Validation validation = new Validation();
            while (true)
            {
                string rePassword = GetRePassword();
                if (validation.ValidatePassword(password, rePassword))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Password not matching, Enter again");
                }
            }
        }
    }
}
