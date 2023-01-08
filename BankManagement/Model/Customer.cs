using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Models
{
    public class Customer
    {
        public Customer()
        {
            Accounts = new List<Account>();
        }

        public Customer(string username, string password, string? name)
        {
            Username= username;
            Password= password;
            Name = name;
            //PhoneNumber = phoneNumber;
            Accounts = new List<Account>();
        }

        public string Username { get; set; }
        public string Name { get; set; }

        public int PhoneNumber{ get; set; }  
        
       public string Password {  get; set; }    
        
        public IList<Account> Accounts { get; set; }

        public void ViewAllAccounts()
        {
            foreach(Account account in Accounts) {
                account.ToString();
            }
        }
        public override string ToString()
        {
            return "Name: " + Name + "\n Username: " + Username + "Accounts: \n" + Accounts.Count();
        }
    }
}
