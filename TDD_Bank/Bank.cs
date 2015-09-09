using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Bank
{
    public class Bank
    {
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
            throw new NotImplementedException();
        }

        public bool Withdraw(double amount)
        {
            throw new NotImplementedException();
        }
    }
}
