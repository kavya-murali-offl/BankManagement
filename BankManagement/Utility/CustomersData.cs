using System;
using System.Security.AccessControl;
using BankManagement.Model;
using BankManagement.Models;
using BankManagement.View;

namespace BankManagement.Utility
{
    public class CustomersData
    {
        public CustomersData()
        {
            CustomersList = new List<Customer>();   
            
        }
        public Customer GetDataByUsername(string username)
        {
            foreach (Customer customer in CustomersList)
            {
                if (customer.Username == username)
                {
                    return customer;
                }
            }
            return null;
        }

        public void AddCustomer(string username, string password, string? name)
        {
            Customer customer = new Customer(username, password, name);
            CustomersList.Add(customer);
        }

        public void ViewCustomers()
        {
            foreach(Customer customer in CustomersList) {
                Console.WriteLine(customer);
            }
        }

        public IList<Customer> CustomersList { get; set; }
    }
}
