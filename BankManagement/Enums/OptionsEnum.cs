using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Enums
{
    public enum DashboardCases
    {
        PROFILE,
        CREATE_ACCOUNT,
        LIST_ACCOUNTS, GO_TO_ACCOUNT, SIGN_OUT
    }
    public enum TransactionType
    {
        DEPOSIT, WITHDRAW, TRANSFER
    }

    public enum BankName
    {
        HDFC, ICICI
    }

    public enum AccountCases
    {
         DEPOSIT, WITHDRAW, TRANSFER, VIEW_STATEMENT, PRINT_STATEMENT, BACK
    }

    public enum AccountTypesCases
    {
        CURRENT, SAVINGS
    }

}
