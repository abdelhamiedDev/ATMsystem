using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace ATMsystem.Classes
{
    public abstract class Account
    {
        protected string accountNumber;
        protected decimal balance;
        private string pin;

        // Default Constructor
        public Account()
        {
            accountNumber = "";
            balance = 0;
            pin = "";
        }

        // Parameterized Constructor
        public Account(string accountNumber, decimal balance, string pin)
        {
            this.accountNumber = accountNumber;
            this.balance = balance;
            this.pin = pin;
        }

        // Regular Method
        public decimal Deposit(decimal amount)
        {
            if (ValidateAmount(amount))
            {
                balance += amount;
                Console.WriteLine($"Deposited: {amount:C}");
                return balance;
            }
            Console.WriteLine("Invalid amount!");
            return balance;
        }

        // Abstract Method
        public abstract bool Withdraw(decimal amount);

        // Getter
        public decimal GetBalance()
        {
            return balance;
        }

        public string GetAccountNumber()
        {
            return accountNumber;
        }

        // Protected Method
        protected bool ValidateAmount(decimal amount)
        {
            return amount > 0;
        }

        public bool ValidatePin(string inputPin)
        {

            return pin == inputPin;
        }
    }


}
