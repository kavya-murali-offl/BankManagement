using BankManagement.Enums;
using BankManagement.Model;
using BankManagement.Models;
using BankManagement.Utility;


namespace BankManagement.Controller
{
    public class TransactionController
    {
        Helper helper = new Helper();
        public Account Account { get; set; }

        public IList<Transaction> GetAllTransactions(Account account)
        {
            return account.Transactions;
        }

        public bool Deposit(Account account)
          {
            decimal amount = helper.GetAmount();
            bool isDeposited = account.Deposit(amount);
            if (isDeposited) {
                Transaction transaction = new Transaction(amount, account.Balance, TransactionTypes.DEPOSIT);
                account.Transactions.Add(transaction);
            }
            return isDeposited;
          }

        public bool Withdraw(Account account)
        {
            decimal amount = helper.GetAmount();
            bool isWithdrawn = account.Withdraw(amount);
            if (isWithdrawn)
            {
                Transaction transaction = new Transaction(amount, account.Balance, TransactionTypes.WITHDRAW);
                account.Transactions.Add(transaction);
            }
            return isWithdrawn;
        }

        public bool Transfer(Account account, string toAccountID, ProfileController profile)
        {
            decimal amount = helper.GetAmount();
            Account transferAccount = profile.GetAccountByID(toAccountID);
            bool isTransferred = account.Transfer(amount, transferAccount);
            if(isTransferred)
            {
                Transaction transaction = new Transaction(amount, account.Balance, TransactionTypes.WITHDRAW);
                account.Transactions.Add(transaction);
            }
            return isTransferred;
        }
    }
}
