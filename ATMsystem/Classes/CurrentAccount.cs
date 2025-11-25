using System;
using System.Collections.Generic;
using System.Text;

namespace ATMsystem.Classes
{

    // Inheritance - CurrentAccount
    public class CurrentAccount : Account
    {
        private decimal overdraftLimit;

        public CurrentAccount(string accountNumber, decimal balance, string pin)
            : base(accountNumber, balance, pin)
        {
            this.overdraftLimit = 5000;
        }

        // Method Overriding (Polymorphism)
        public override bool Withdraw(decimal amount)
        {
            if (balance + overdraftLimit >= amount)
            {
                balance -= amount;
                Console.WriteLine($"Withdrawn: {amount:C}");
                if (balance < 0)
                {
                    Console.WriteLine($"Overdraft used: {Math.Abs(balance):C}");
                }
                return true;
            }
            Console.WriteLine("Insufficient balance even with overdraft!");
            return false;
        }

        public decimal GetOverdraftLimit()
        {
            return overdraftLimit;
        }
    }

}
