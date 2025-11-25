using System;
using System.Collections.Generic;
using System.Text;

namespace ATMsystem.Classes
{

    // Customer Class
    public class Customer
    {
        private string customerId;
        private string name;
        private string phoneNumber;
        private List<Account> accounts;

        // Default Constructor
        public Customer()
        {
            accounts = new List<Account>();
        }

        // Parameterized Constructor
        public Customer(string customerId, string name, string phoneNumber)
        {
            this.customerId = customerId;
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.accounts = new List<Account>();
        }

        // Getter/Setter
        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        // Property
        public string CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        // Method Overloading
        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }

        public List<Account> GetAccounts()
        {
            return accounts;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"\n--- Customer Information ---");
            Console.WriteLine($"ID: {customerId}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Phone: {phoneNumber}");
            Console.WriteLine($"Number of Accounts: {accounts.Count}");
        }
    }
}
