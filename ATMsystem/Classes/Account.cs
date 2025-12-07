using ATMsystem.Interfaces;
using System;


namespace ATMsystem.Classes
{
    // Abstract Class
    // Abstraction
    public abstract class Account : IAccount
    {
        protected string accountNumber;
        protected decimal balance;
        private string pin;

        // Default Constructor (No Needed)
        // public Account()
        // {
        //     accountNumber = "";
        //     balance = 0;
        //     pin = "";
        // }

        // Parameterized Constructor
        // this keyword is used to refer to the current instance of the class
        public Account(string accountNumber, decimal balance, string pin)
        {
            this.accountNumber = accountNumber;
            this.balance = balance;
            this.pin = pin;
        }

        // Properties 
        // getters and setters
        public string AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }

        public decimal Balance
        {
            get { return balance; }
            protected set { balance = value; }
        }

        // Virtual Methods
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

        // Access Modifiers (Protected)
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
