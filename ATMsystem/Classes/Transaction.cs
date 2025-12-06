using ATMsystem.Interfaces;
using System;

namespace ATMsystem.Classes
{
    // 24. Classes Types (Normal Class)
    public class Transaction : ITransaction
    {
        // 1. Encapsulation (Private Fields)
        private string transactionId;
        private decimal amount;
        private DateTime date;
        private IAccount account;
        private string type;

        // 13. Parameterized Constructor
        public Transaction(IAccount account, decimal amount, string type)
        {
            this.transactionId = Guid.NewGuid().ToString().Substring(0, 8);
            this.amount = amount;
            this.date = DateTime.Now;
            this.account = account; // 22. This Keyword
            this.type = type;
        }

        // 14. Destructor
        ~Transaction()
        {
            // Code cleanup if needed
        }

        // 18. Properties
        public string TransactionId
        {
            get { return transactionId; } // 17. Getter
            private set { transactionId = value; } // 17. Setter (Private)
        }

        public decimal Amount
        {
            get { return amount; }
            private set { amount = value; }
        }

        public DateTime Date
        {
            get { return date; }
            private set { date = value; }
        }

        public string Type
        {
            get { return type; }
            private set { type = value; }
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
            Console.WriteLine($"Transaction ID: {TransactionId}");
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"Amount: {Amount:C}");
            Console.WriteLine($"Date: {Date}");
            Console.WriteLine($"Account: {account.AccountNumber}");
            Console.WriteLine($"New Balance: {account.Balance:C}");
            Console.WriteLine($"=============================\n");
        }
    }
}
