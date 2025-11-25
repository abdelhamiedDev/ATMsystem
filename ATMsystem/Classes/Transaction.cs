using ATMsystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATMsystem.Classes
{
    // Transaction Class
    public class Transaction : ITransaction
    {
        private string transactionId;
        private decimal amount;
        private DateTime date;
        private Account account;
        private string type;

        public Transaction(Account account, decimal amount, string type)
        {
            this.transactionId = Guid.NewGuid().ToString().Substring(0, 8);
            this.amount = amount;
            this.date = DateTime.Now;
            this.account = account;
            this.type = type;
        }

        // Implementing Interface
        public bool Execute()
        {
            if (type == "Withdraw")
            {
                return account.Withdraw(amount);
            }
            else if (type == "Deposit")
            {
                account.Deposit(amount);
                return true;
            }
            return false;
        }

        public void DisplayReceipt()
        {
            Console.WriteLine($"\n========== RECEIPT ==========");
            Console.WriteLine($"Transaction ID: {transactionId}");
            Console.WriteLine($"Type: {type}");
            Console.WriteLine($"Amount: {amount:C}");
            Console.WriteLine($"Date: {date}");
            Console.WriteLine($"Account: {account.GetAccountNumber()}");
            Console.WriteLine($"New Balance: {account.GetBalance():C}");
            Console.WriteLine($"=============================\n");
        }
    }
}
