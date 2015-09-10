﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Bank
{
    public class CheckingAccount : BankAccount
    {
        public CheckingAccount(string owner, double amount, double interestRate, long accountNumber):
            base(owner, amount, interestRate, accountNumber)
        {
        }
    }
}