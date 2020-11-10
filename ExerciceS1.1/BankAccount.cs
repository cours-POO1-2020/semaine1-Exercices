using System;
using System.Diagnostics;
using System.Threading;

namespace BankAccountNS
{

    public class Program
    {
        public const int MAX_AMOUNT = 100;

        public static void Main(string[] args)
        {

            BankAccount ba = new BankAccount("Mr. Bryan Walton", 12.25);
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {

                ba.Credit(Math.Round(rand.NextDouble() * MAX_AMOUNT, 2));
                Thread.Sleep(500);

                ba.Debit(Math.Round(rand.NextDouble() * MAX_AMOUNT, 2));
                Thread.Sleep(500);

            }

            Console.ReadKey();
        }
    }


    /// <summary>
    /// Bank account demo class.
    /// </summary>
    public class BankAccount
    {
        private readonly string customerName;
        private double balance;

        private BankAccount() { }

        public BankAccount(string customerName, double balance)
        {
            this.customerName = customerName;
            this.balance = balance;
            Console.WriteLine($"{CustomerName} just opened a new account and has credited: {Balance} $.");
        }

        /// <summary>
        /// Customer name cannot be changed from outside!
        /// </summary>
        public string CustomerName
        {
            get { return customerName; }
        }
        /// <summary>
        /// BAlance cannot be changed from outside!
        /// Always round balance when displaying it to the oustide, 
        /// even if it is calculated with more precision inside
        /// </summary>
        public double Balance
        {
            get { return Math.Round(balance, 2); }
        }

        /// <summary>
        /// Debit a positive amount from the account
        /// Refuse negative amounts and amounts over current balance
        /// </summary>
        /// <param name="amount">the amount to debit</param>
        public void Debit(double amount)
        {
            Console.WriteLine("---Start operation---");
            Console.WriteLine($"Trying to Debit {amount} $ on {this.CustomerName} account");
            if (amount > Balance)
            {
                Console.ForegroundColor = ConsoleColor.Red;
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

            balance -= amount;
            Console.WriteLine($"Successfull: Balance is {Balance} $ on {this.CustomerName} account.");
            Console.WriteLine("---End operation---");
            Console.WriteLine();
        }

        /// <summary>
        /// Credit amount if positive refuse otherwise
        /// </summary>
        /// <param name="amount">the amount to credit</param>
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

            balance += amount;
            Console.WriteLine($"Successfull: Balance is {Balance} $ on {this.CustomerName} account.");

            Console.WriteLine("---End operation---");
            Console.WriteLine();

        }


    }
}