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

        private string _owner;
        private double _balance;

        public string Owner
        {
            get
            {
                return _owner;
            }
            set
            {
                _owner = value;
            }
        }

        public double Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                _balance = value;
            }
        }

        public Bank() { }

        public Bank(string owner, double balance)
        {
            _owner = owner;
            _balance = balance;
        }

        public bool Deposit(double amount)
        {
            Balance += amount;

            return true;
        }

        public bool Withdraw(double amount)
        {
            if(Balance - amount > 0)
            {
                Balance -= amount;
                return true;
            }

            return false;
        }
    }
}
