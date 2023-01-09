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
        }

        public decimal Balance { get; set; }

        public Guid AccountID { get; set; } 
        
        public IList<Transaction> Transactions { get; set; }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (Balance > amount)
                Balance -= amount;
            else
                throw new ArgumentException ("Insufficient Balance");
        }

        public void transfer(decimal amount, Account transferAccount)
        {
            Withdraw(amount);
            transferAccount.Deposit(amount);
        }

    }

}
