using System;
using BankManagement.Models;
using BankManagement.Utility;

namespace BankManagement.Controller
{
    public class ProfileController
    {
        public Customer Customer { get; set; }

        public string UserName
        {
            get { return Customer.Username; }
        }

        public string? Name
        {
            get { return Customer.Name; }
        }

        public string Password
        {
            get { return Customer.Password; }
            set { Customer.Password = value; }
        }


        public IList<Account> Accounts
        {
            get { return Customer.Accounts; }
            set { Customer.Accounts = value; }

        }

        public void GetUserDetails(String input)
        {
            CustomersData userData = new CustomersData();
            Customer = userData.GetDataByUsername(input);
        }

    }
}
