using BankManagement.Models;
using BankManagement.Utility;
using System;

namespace BankManagement.Controller
{
    public class CustomersController
    {
        public CustomersController() {
            CustomersData customersData = new CustomersData();
            CustomersData = customersData;
        }

        public CustomersData CustomersData { get; set; }

        public void AddCustomer(string username, string password, string? name)
        {
            Customer customer = new Customer(username, password, name);
            CustomersData.AddCustomer(customer);
        }

        public IList<Customer> GetAllCustomers()
        {
            return CustomersData.CustomersList;
        }

        public Customer GetUserDetails(string username)
        {
            return CustomersData.GetDataByUsername(username);
        }
    }
}
