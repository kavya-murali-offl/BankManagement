using BankManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Utility
{
    public class Helper
    {
        public decimal GetAmount()
        {
            while (true)
            {
                Console.WriteLine("Enter amount: ");
                try
                {
                    decimal amount = Decimal.Parse(Console.ReadLine());
                    if (amount > 0) return amount;
                    else Console.WriteLine("Amount should be greater than zero.");
                }
                catch (Exception error)
                {
                    Console.WriteLine("Enter a valid amount. Try Again!(incoming view)");
                }
            }
        }

        public bool LoginValidation(string username, string password, CustomersData customersData)
        {
            foreach(Customer customer in customersData.CustomersList) {
                if(customer.Username == username)
                {
                    if(customer.Password == password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }     
        
    }
}
