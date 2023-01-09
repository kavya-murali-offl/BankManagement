using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Models
{
    public class Customer
    {

        public Customer(string username, string password, string? name)
        {
            Username= username;
            Password= password;
            Name = name;
        }

        public string Username { get; set; }
        public string Name { get; set; }

        public int PhoneNumber{ get; set; }  
        
       public string Password {  get; set; }    
        
        public override string ToString()
        {
            return "Name: " + Name + "\n Username: " + Username;
        }
    }
}
