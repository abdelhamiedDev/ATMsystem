using System;
using System.Collections.Generic;
using System.Text;

namespace ATMsystem.Interfaces
{
    internal interface ITransaction
    {
        bool Execute();
        void DisplayReceipt();
    }
}
