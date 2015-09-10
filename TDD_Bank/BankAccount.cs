using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Bank
{
    /// <summary>
    /// Different Account Types
    /// </summary>
    public enum AccountType
    {
        /// <summary>
        /// Checking Account Type
        /// </summary>
        Checking,
        /// <summary>
        /// Savings Account Type
        /// </summary>
        Savings
    }

    /// <summary>
    /// Bank Account Class
    /// </summary>
    public class BankAccount
    {
        #region Private Member Variables
        private double _balance;
        private string _owner;
        private double _interestRate;
        private long _accountNumber; 
        #endregion // Private Member Variables

        #region Public Properties
        /// <summary>
        /// Current Balance of account
        /// </summary>
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

        /// <summary>
        /// Owner of account
        /// </summary>
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

        /// <summary>
        /// Interest rate 
        /// </summary>
        public double InterestRate
        {
            get
            {
                return _interestRate;
            }
            set
            {
                _interestRate = value;
            }
        }

        /// <summary>
        /// Account number
        /// </summary>
        public long AccountNumber
        {
            get
            {
                return _accountNumber;
            }
        } 
        #endregion // Public Properties

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="owner">Account owners name</param>
        /// <param name="amount">Initial balance of account</param>
        /// <param name="interestRate">Interest rate of account</param>
        /// <param name="accountNumber">Account number</param>
        public BankAccount(string owner, double amount, double interestRate, long accountNumber)
        {
            Balance = amount;
            Owner = owner;
            InterestRate = interestRate;
            _accountNumber = accountNumber;
        } 
        #endregion // Constructor

        #region Public Methods
        /// <summary>
        /// Deposits amount of money into account
        /// </summary>
        /// <param name="amount">Amount to deposit</param>
        /// <returns>True if successful</returns>
        public bool Deposit(double amount)
        {
            Balance += amount;

            return true;
        }

        /// <summary>
        /// Withdraws amount of money from account
        /// </summary>
        /// <param name="amount">Amount to withdraw</param>
        /// <returns>True if successfull</returns>
        public bool Withdraw(double amount)
        {
            if (Balance - amount > 0)
            {
                Balance -= amount;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Calculates the amount of interest earned over a period of months
        /// </summary>
        /// <param name="dateTime">Date to calculate to</param>
        /// <returns>Total interest earned</returns>
        public double GetInterestEarnedOnCalendarDate(DateTime dateTime)
        {
            double totalInterest = Balance;
            int months = (dateTime.Month - DateTime.Now.Month) + 12 * (dateTime.Year - DateTime.Now.Year);

            for (int i = 0; i < months; i++)
            {
                totalInterest += totalInterest * InterestRate;
            }

            return totalInterest - Balance;
        } 
        #endregion // Public Methods
    }
}
