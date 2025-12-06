using System;
using System.Collections.Generic;
using System.Text;

namespace ATMsystem.Classes
{
    // Customer Class
    public class Customer
    {
        // 15. Access Modifiers (Private)
        private string customerId;
        private string name;
        private string phoneNumber;
        private List<Account> accounts;

        // 12. Default Constructor
        public Customer()
        {
            accounts = new List<Account>();
        }

        // 13. Parameterized Constructor
        // 9. Method Overloading (Constructor is a type of method and overloaded here)
        public Customer(string customerId, string name, string phoneNumber)
        {
            this.customerId = customerId;
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.accounts = new List<Account>();
        }

        // 18. Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        public IReadOnlyList<Account> Accounts
        {
            get { return accounts.AsReadOnly(); }
        }

        // 8. Instance Members
        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"\n--- Customer Information ---");
            Console.WriteLine($"ID: {CustomerId}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Phone: {PhoneNumber}");
            Console.WriteLine($"Number of Accounts: {accounts.Count}");
        }
    }
}
