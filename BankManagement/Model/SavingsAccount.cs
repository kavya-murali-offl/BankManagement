using System;
using System.Reflection.Metadata.Ecma335;
using BankManagement.Models;

namespace BankManagement.Model
{
    public class SavingsAccount : Account
    {
        
        public SavingsAccount(decimal interestRate) : base() {
            InterestRate= interestRate; 
        }

        public decimal InterestRate { get; set; }

        public decimal MinimumBalance { get; set; }
        public void DepositInterest(decimal amount) {
            decimal interest = Balance * InterestRate / 100;
            Deposit(interest);
        }
    }
}
