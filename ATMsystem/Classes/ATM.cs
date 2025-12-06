using System;
using System.Collections.Generic;
using System.Text;
using ATMsystem.Interfaces;

namespace ATMsystem.Classes
{
    // 16. Final / Sealed Classes
    public sealed class ATM
    {
        private string atmId;
        private decimal cashAvailable;
        
        // 7. Static Members
        private static int atmCount = 0;

        // 13. Parameterized Constructor
        public ATM(string atmId, decimal initialCash)
        {
            this.atmId = atmId;
            this.cashAvailable = initialCash;
            atmCount++;
        }

        // Properties
        public string AtmId
        {
            get { return atmId; }
            private set { atmId = value; }
        }

        public static int GetATMCount()
        {
            return atmCount;
        }

        // Simple Authentication
        public bool Authenticate(IAccount account, string pin)
        {
            return account.ValidatePin(pin);
        }

        // 8. Instance Members
        public bool DispenseCash(decimal amount)
        {
            if (cashAvailable >= amount)
            {
                cashAvailable -= amount;
                return true;
            }
            Console.WriteLine("ATM has insufficient cash!");
            return false;
        }
    }
}
