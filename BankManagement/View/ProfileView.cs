using BankManagement.Controller;
using BankManagement.Models;
using System;


namespace BankManagement.View
{
    public class ProfileView
    {
        
        public void GetProfileDetails(ProfileController profileController)
        {
            while (true)
            {
                PrintProfileDetails(profileController);
                Console.WriteLine("Press 0 to go back to dashboard");
                try
                {
                    String input = Console.ReadLine();
                    if (input != "0")
                    {
                        Console.WriteLine("Enter a valid option");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine("Enter a valid option");
                }
            }
        }

        public void PrintProfileDetails(ProfileController profileController)
        {
            Console.WriteLine("\n PROFILE \n");
            Console.WriteLine("Name: " + profileController.Name);
            Console.WriteLine("UserName: " + profileController.UserName);
            Console.WriteLine("Password: " + profileController.Password);
            //        double incoming, expense;
            //    totalDeposit = profileController.getTotalExpense(profileController.getUserName());
            //    totalWithdraw = profileController.getTotalIncoming(profileController.getUserName());
            //    Console.WriteLine("Total Incoming: "+incoming+"\t\t\tTotal Expense: "+expense);
            //        if(incoming-expense > 0){
            //        Console.WriteLine("Your expenses are lower than your incomings by Rs." + (incoming - expense));
            //    }else if(incoming-expense < 0){
            //        Console.WriteLine("Your expenses are higher than your incomings by Rs. " + (expense - incoming));
            //    }else{
            //        Console.WriteLine("Your expenses and incomings are balanced");
            //    }
            //    Console.WriteLine("\n---------------------------------------------\n");
            //}
        }
    }
}
