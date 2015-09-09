using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Bank
{
    public class Bank
    {
        //TODO : Banks control characteristics of Account Holder
        // -> First Name, Last Name, SSN, Address, PIN Code, Accounts
        //TODO : Make interface for BankAccount
        //TODO : Make base class BankAccount
        //TODO : Make Checking
        //TODO : Make Savings

        private string _bankName;

        public string Name
        {
            get
            {
                return _bankName;
            }
        }

        public Bank(string name)
        {
            _bankName = name;
        }
    }
}
