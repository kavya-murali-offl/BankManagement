using System;
using BankManagement.Models;
using BankManagement.View;
using Microsoft.VisualBasic;
using System.IO;
namespace MoneyManager
{
    class Program
    {
        static void Main(string[] args)
        {
            EntryView entryView = new EntryView();
            entryView.Entry();



        }
    }
}