using BankManagement.Enums;
using BankManagement.Model;
using System;

namespace BankManagement.Models
{
    public abstract class Account
    {
        public Account() { 
            AccountID = Guid.NewGuid();
            IList<Transaction> transactions = new List<Transaction>();
            Transactions = transactions;
            Balance = 0;
            Status = AccountStatus.ACTIVE;
        }

        public decimal Balance { get; set; }

        public decimal InterestRate { get; set; }

        public Guid AccountID { get; set; } 
        
        public AccountStatus Status { get; set; } 
        
        public IList<Transaction> Transactions { get; set; }

        public bool Deposit(decimal amount)
        {
            Balance += amount;
            return true;
        }

        public bool Withdraw(decimal amount)
        {
            if (Balance > amount)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                Console.WriteLine("Insufficient Balance...");
                return false;
            }
                 
        }

        public bool Transfer(decimal amount, Account transferAccount)
        {
            try
            {
                Withdraw(amount);
                transferAccount.Deposit(amount);
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
        public override string ToString()
        {
            return "Account ID: " + AccountID + 
                "\nAccount Status: " + Status +
                "\nBalance: " + Balance;
        }
    }

}
