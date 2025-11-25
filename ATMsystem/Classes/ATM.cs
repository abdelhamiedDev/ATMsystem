using System;
using System.Collections.Generic;
using System.Text;

namespace ATMsystem.Classes
{
    // Sealed Class
    public sealed class ATM
    {
        private string atmId;
        private decimal cashAvailable;
        private static int atmCount = 0;

        public ATM(string atmId, decimal initialCash)
        {
            this.atmId = atmId;
            this.cashAvailable = initialCash;
            atmCount++;
        }

        // Static Method
        public static int GetATMCount()
        {
            return atmCount;
        }

        public bool Authenticate(Account account, string pin)
        {
            return account.ValidatePin(pin);
        }

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

        public string GetATMId()
        {
            return atmId;
        }
    }
}
