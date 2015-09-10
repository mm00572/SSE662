using System.Collections.Generic;
using System.Linq;

namespace TDD_Bank
{
    /// <summary>
    /// Bank Class
    /// Future Potential : Create backend database to track all accounts, etc.
    ///     Use Reflection to map objects with properties to each dbRow and Entry
    /// </summary>
    public class Bank
    {
        #region Private Member Variables
        private string _bankName;
        private List<BankAccount> _bankAccounts; 
        #endregion // Private Member Variables

        #region Public Properties
        /// <summary>
        /// Name of Bank
        /// </summary>
        public string Name
        {
            get
            {
                return _bankName;
            }
        }

        /// <summary>
        /// List of Accounts
        /// </summary>
        public List<BankAccount> Accounts
        {
            get
            {
                return _bankAccounts;
            }
        } 
        #endregion // Public Properties

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of Bank</param>
        public Bank(string name)
        {
            _bankName = name;
            _bankAccounts = new List<BankAccount>();
        }
        #endregion // Constructor

        #region Public Methods
        /// <summary>
        /// Creates a new account
        /// </summary>
        /// <param name="owner">Owners name</param>
        /// <param name="balance">Initial balance</param>
        /// <param name="interestRate">Interest rate of account</param>
        /// <param name="type">Type of account</param>
        public void NewAccount(string owner, double balance, double interestRate, AccountType type)
        {
            switch (type)
            {
                case AccountType.Checking:
                    Accounts.Add(new CheckingAccount(owner, balance, interestRate, GetNextAccountNumber()));
                    break;
                case AccountType.Savings:
                    Accounts.Add(new SavingsAccount(owner, balance, interestRate, GetNextAccountNumber()));
                    break;
            }
        }
        
        /// <summary>
        /// Method that allows User to make deposit
        /// </summary>
        /// <param name="accountNumber">Account Number to deposit into</param>
        /// <param name="amount">Amount to deposit</param>
        public void MakeDeposit(long accountNumber, double amount)
        {
            Accounts.Where(account => account.AccountNumber == accountNumber).FirstOrDefault().Deposit(amount);
        }

        /// <summary>
        /// Method that allows User to make withdraw
        /// </summary>
        /// <param name="accountNumber">Account Number to withdraw from</param>
        /// <param name="amount">Amount to withdraw</param>
        public void MakeWithdraw(long accountNumber, double amount)
        {
            Accounts.Where(account => account.AccountNumber == accountNumber).FirstOrDefault().Withdraw(amount);
        }

        /// <summary>
        /// Gets the account with with the specified account number
        /// </summary>
        /// <param name="accountNumber">Account Number of account</param>
        /// <returns>Bank Account</returns>
        public BankAccount GetAccount(long accountNumber)
        {
            return Accounts.Where(account => account.AccountNumber == accountNumber).FirstOrDefault();
        }
        #endregion // Public Methods

        #region Private Methods
        /// <summary>
        /// Gets next account number in sequence
        /// TODO : implement a more secure way of doing this.
        /// </summary>
        /// <returns>Account number</returns>
        private long GetNextAccountNumber()
        {
            int current = Accounts.Count;
            return 100000064531 + current + 1;
        } 
        #endregion // Private Methods
    }
}
