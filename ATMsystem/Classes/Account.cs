using ATMsystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace ATMsystem.Classes
{
    // 6. Abstract Class
    // 4. Abstraction
    public abstract class Account : IAccount
    {
        // 15. Access Modifiers (Protected)
        protected string accountNumber;
        protected decimal balance;
        private string pin;

        // 12. Default Constructor
        public Account()
        {
            accountNumber = "";
            balance = 0;
            pin = "";
        }

        // 13. Parameterized Constructor
        public Account(string accountNumber, decimal balance, string pin)
        {
            this.accountNumber = accountNumber;
            this.balance = balance;
            this.pin = pin;
        }

        // 18. Properties
        public string AccountNumber
        {
            get { return accountNumber; }
            protected set { accountNumber = value; }
        }

        public decimal Balance
        {
            get { return balance; }
            protected set { balance = value; }
        }

        // 19. Virtual Methods
        public virtual decimal Deposit(decimal amount)
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

        // Abstract Method (Must be overridden)
        public abstract bool Withdraw(decimal amount);

        // 15. Access Modifiers (Protected)
        protected bool ValidateAmount(decimal amount)
        {
            return amount > 0;
        }

        public bool ValidatePin(string inputPin)
        {
             // Simple PIN validation
            if (string.IsNullOrEmpty(inputPin) || inputPin.Length != 4)   
            {
                return false;
            }
            return pin == inputPin;
        }
    }
}
