using System;
using BankManagement.Enums;
using BankManagement.Models;

namespace BankManagement.Model
{
    public class Transaction
    {
        private static int TransactionID = 1;
        private DateTime _recordedOn;

        public Transaction(Account account, decimal amount, decimal balance, TransactionType transactionType)
        {
            TransactionID = TransactionID + 1;
            TransactionType = transactionType;
            Amount = amount;
            Account = account;
            _recordedOn = DateTime.Now;
        }

        public TransactionType TransactionType { get; set; }

        public decimal Amount { get; set; }

        public decimal Balance { get; set; }

        public Account Account { get; set; } 

        public override string ToString()
        {
            return "Transaction ID: " +
                "Transaction Type: " + TransactionType + TransactionID + "Transaction Time: " +
                _recordedOn + "Amount: " + Amount +
                "Balance: " + Balance;
        }

    }

}
