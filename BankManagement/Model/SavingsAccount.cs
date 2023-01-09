using System;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;
using BankManagement.Models;

namespace BankManagement.Model
{
    public class SavingsAccount : Account
    {

        public decimal InterestRate { get; set; }

        public void DepositInterest(decimal amount) {
            decimal interest = Balance * InterestRate / 100;
            Deposit(interest);
        }

        public override string ToString()
        {
            return "Account Type: Savings\n" + "Account ID: " + AccountID + "\nBalance: " + Balance + "\nInterest Rate: " + InterestRate + "\n========================================\n";
        }
    }
}
