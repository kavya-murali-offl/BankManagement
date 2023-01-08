using System;
using BankManagement.Models;
using BankManagement.View;

namespace MoneyManager
{
    class Program
    {
        static void Main(string[] args)
        {
            EntryView entryView = new EntryView();
            entryView.Entry();
            //AuthServices authServices = new AuthServices();
            //CustomerServices customerServices = new CustomerServices();

            //entryView.WelcomeMessage();
            //authServices.RequestService();

            //Customer currentUser = authServices.GetCustomer();

            //if (currentUser != null)
            //{
            //    Dashboard dashBoardView = new Dashboard(currentUser);
            //    dashBoardView.Entry();
            //}


        }
    }
}