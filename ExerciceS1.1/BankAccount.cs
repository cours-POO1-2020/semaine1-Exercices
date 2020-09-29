using System;
using System.Diagnostics;
using System.Threading;

namespace BankAccountNS
{
    //Test my changes
    public class Program
    { 
        public const int MaxAmount = 100;

        public static void Main(string[] args)
        {
            //here is the main change
            BankAccount ba = new BankAccount("Mr. Bryan Walton", 12.25);
            Random rand = new Random();
            for (int i = 0; i < 10 ; i++)
            {

                ba.Credit(Math.Round(rand.NextDouble() * MaxAmount,2));
                Thread.Sleep(500);

                ba.Debit(Math.Round(rand.NextDouble() * MaxAmount,2));
                Thread.Sleep(500);

            }

            Console.ReadKey();
        }
    }


    /// <summary>
    /// Bank account demo class.
    /// </summary>
    public  class BankAccount
    {
        private readonly string _CustomerName;
        private double _Balance;

        private BankAccount() { }

        public BankAccount(string customerName, double balance)
        {
            _CustomerName = customerName;
            _Balance = balance;
            Console.WriteLine($"{CustomerName} just opened a new account and has credited: {Balance} $." );
        }

        public string CustomerName
        {
            get { return _CustomerName; }
        }

        public double Balance
        {
            get { return Math.Round(_Balance,2); }
        }

        public void Debit(double amount)
        {
            Console.WriteLine("---Start operation---");
            Console.WriteLine($"Trying to Debit {amount} $ on {this.CustomerName} account");
            if (amount > Balance)
            {
                Console.ForegroundColor  = ConsoleColor.Red;
                Console.WriteLine($"Impossible to debit more than existing account balance.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("---operation aborted---");
                Console.WriteLine();
                return;
            }

            if (amount < 0)
            {
                Console.WriteLine($"Impossible to debit negative values.");
                Console.WriteLine("---operation aborted---");
                Console.WriteLine();
                return;
            }

            _Balance -= amount;
            Console.WriteLine($"Successfull: Balance is {Balance} $ on {this.CustomerName} account.");
            Console.WriteLine("---End operation---");
            Console.WriteLine();
        }

        public void Credit(double amount)
        {
            Console.WriteLine("---Start operation---");
            Console.WriteLine($"Trying to credit {amount} $ on {this.CustomerName} account");
            if (amount < 0)
            {
                Console.WriteLine($"Impossible to credit negative values.");
                Console.WriteLine("---operation aborted---");
                Console.WriteLine("---operation aborted---");
                Console.WriteLine();
                return;
            }

            _Balance += amount;
            Console.WriteLine($"Successfull: Balance is {Balance} $ on {this.CustomerName} account.");

            Console.WriteLine("---End operation---");
            Console.WriteLine();

        }


    }
}
