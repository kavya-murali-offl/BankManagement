using System;
using BankManagement.Models;
using BankManagement.Utility;

namespace BankManagement.Controller
{
    public class CustomerController
    {
        public Customer GetUserDetails(string username)
        {
            CustomersData userData = new CustomersData();
            return userData.GetDataByUsername(username);
        }
    }
}
