using System;
using System.Collections.Generic;
using System.Text;

namespace ATMsystem.Interfaces
{
    public interface IAccount
    {
        string AccountNumber { get; }
        decimal Balance { get; }
        decimal Deposit(decimal amount);
        bool Withdraw(decimal amount);
        bool ValidatePin(string inputPin);
    }
}
