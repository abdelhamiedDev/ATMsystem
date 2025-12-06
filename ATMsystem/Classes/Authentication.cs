using System;
using System.Data.Common;
using System.Reflection.Metadata.Ecma335;

namespace ATMsystem.Classes
{
    class Authenticattion
    {
        static public bool is_null_or_empty(string sample)
        {
            if (sample == "") return true;
            else return false;            
        }
    }
}