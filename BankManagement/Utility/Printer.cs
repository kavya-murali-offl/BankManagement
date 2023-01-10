using BankManagement.Model;

namespace BankManagement.Utility
{
    public class Printer
    {
        public static void PrintStatement(IList<Transaction> transactions)
        {
            try
            {
                StreamWriter sw = new StreamWriter("C:\\Users\\kavya-pt6688\\source\\repos\\BankManagementApp\\Statement.txt");
                sw.WriteLine("S.No.\t\tTransaction ID\t\t\t\t\t\t\tTransaction Time\t\t\t\t\t\t\tTransaction Type\t\tAmount\t\tBalance");
                for(int i = 0;i< transactions.Count;i++) {
                    sw.WriteLine(i + 1 + "\t\t" + transactions[i].ToString() + "\n\n================\n\n");
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}
