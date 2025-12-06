using System;
using System.Collections.Generic;
using System.Text;

namespace ATMsystem.Interfaces
{
    // 5. Interface
    internal interface ITransaction
    {
        bool Execute();
        void DisplayReceipt();
    }
}
