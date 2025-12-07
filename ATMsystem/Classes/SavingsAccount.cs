using System;
using System.Collections.Generic;
using System.Text;

namespace ATMsystem.Classes
{
    // Inheritance
    public class SavingsAccount : Account
    {
        private decimal interestRate;
        private const decimal MIN_BALANCE = 100;

        // Super / Base Keyword
        public SavingsAccount(string accountNumber, decimal balance, string pin)
            : base(accountNumber, balance, pin)
        {
            this.interestRate = 0.05m;
        }

        // Method Overriding
        // Override Keyword
        public override bool Withdraw(decimal amount)
        {
            // Polymorphism (Different behavior for Withdraw)
            if (balance - amount >= MIN_BALANCE)
            {
                balance -= amount;
                Console.WriteLine($"Withdrawn: {amount:C}");
                Console.WriteLine($"Remaining Balance: {balance:C}");
                return true;
            }
            Console.WriteLine($"Insufficient balance! Minimum {MIN_BALANCE:C} required to be in your account.");
            return false;
        }

        public void ApplyInterest()
        {
            decimal interest = balance * interestRate;
            balance += interest;
            Console.WriteLine($"Interest applied: {interest:C}");
        }
    }
}
