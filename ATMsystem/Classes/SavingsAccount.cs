using System;
using System.Collections.Generic;
using System.Text;

namespace ATMsystem.Classes
{
    // 2. Inheritance
    public class SavingsAccount : Account
    {
        private decimal interestRate;
        private const decimal MIN_BALANCE = 1000;

        // 21. Super / Base Keyword
        public SavingsAccount(string accountNumber, decimal balance, string pin)
            : base(accountNumber, balance, pin)
        {
            this.interestRate = 0.05m;
        }

        // 10. Method Overriding
        // 20. Override Keyword
        public override bool Withdraw(decimal amount)
        {
            // 3. Polymorphism (Different behavior for Withdraw)
            if (balance - amount >= MIN_BALANCE)
            {
                balance -= amount;
                Console.WriteLine($"Withdrawn: {amount:C}");
                Console.WriteLine($"Minimum balance maintained: {MIN_BALANCE:C}");
                return true;
            }
            Console.WriteLine($"Insufficient balance! Minimum {MIN_BALANCE:C} required.");
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
