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
            Customer customer1 = new Customer("kav", "pass", "Kavya");
            customer1.Accounts = new List<Account>();
            customer1.Accounts.Add(new CurrentAccount(300));
            Customer customer2 = new Customer("test", "pass", "Test");
            CustomersList.Add(customer1);
            CustomersList.Add(customer2);
            ViewCustomers();
            
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

        public void AddCustomer(string username, string password, string? name, decimal initialAmount)
        {
            Customer customer = new Customer(username, password, name);
            customer.Accounts.Add(new CurrentAccount(initialAmount));
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
