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
        private List<BankAccount> _bankAccounts;

        public string Name
        {
            get
            {
                return _bankName;
            }
        }

        public List<BankAccount> Accounts
        {
            get
            {
                return _bankAccounts;
            }
        }

        public Bank(string name)
        {
            _bankName = name;
            _bankAccounts = new List<BankAccount>();
        }

        public void NewAccount(string owner, double balance, double interestRate, AccountType type)
        {
           switch(type)
           {
               case AccountType.Checking:
                   Accounts.Add(new CheckingAccount(owner, balance, interestRate, GetNextAccountNumber()));
                   break;
               case AccountType.Savings:
                   Accounts.Add(new SavingsAccount(owner, balance, interestRate, GetNextAccountNumber()));
                   break;
           }
        }

        private long GetNextAccountNumber()
        {
            int current = Accounts.Count;
            return 100000064531 + current + 1;
        }
    }
}
