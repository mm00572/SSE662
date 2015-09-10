using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD_Bank;

namespace BankTest
{
    /// <summary>
    /// Summary description for BankAccountTest
    /// </summary>
    [TestClass]
    public class BankAccountTest
    {
        private const double INITIAL_BALANCE = 1000.00;

        private static BankAccount _checkingAccount;
        private static BankAccount _savingsAccount;
  
        public BankAccountTest()
        {
            _checkingAccount = new CheckingAccount("Owner", INITIAL_BALANCE, .0025, 1);
            _savingsAccount = new SavingsAccount("Owner", INITIAL_BALANCE, .04, 2);
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetBalanceTest()
        {
            Assert.AreEqual(INITIAL_BALANCE, _checkingAccount.Balance);
            Assert.AreEqual(INITIAL_BALANCE, _savingsAccount.Balance);
        }

        [TestMethod]
        public void WithdrawTest()
        {
            const double AMOUNT_TO_WITHDRAW = 245.23;
            double initialAmount = _checkingAccount.Balance;
            _checkingAccount.Withdraw(AMOUNT_TO_WITHDRAW);
            Assert.AreEqual(initialAmount - AMOUNT_TO_WITHDRAW, _checkingAccount.Balance);

            initialAmount = _savingsAccount.Balance;
            _savingsAccount.Withdraw(AMOUNT_TO_WITHDRAW);
            Assert.AreEqual(initialAmount - AMOUNT_TO_WITHDRAW, _savingsAccount.Balance);
        }

        [TestMethod]
        public void DepositTest()
        {
            const double AMOUNT_TO_DEPOSIT = 111.11;
            double initialAmount = _checkingAccount.Balance;
            _checkingAccount.Deposit(AMOUNT_TO_DEPOSIT);
            Assert.AreEqual(initialAmount + AMOUNT_TO_DEPOSIT, _checkingAccount.Balance);

            initialAmount = _savingsAccount.Balance;
            _savingsAccount.Deposit(AMOUNT_TO_DEPOSIT);
            Assert.AreEqual(initialAmount + AMOUNT_TO_DEPOSIT, _savingsAccount.Balance);
        }

        [TestMethod]
        public void OverdraftTest()
        {
            double balance = _checkingAccount.Balance;

            Assert.IsFalse(_checkingAccount.Withdraw(balance + .01));

            balance = _savingsAccount.Balance;

            Assert.IsFalse(_savingsAccount.Withdraw(balance + .01));
        }

        [TestMethod]
        public void GetInterestRateTest()
        {
            double checkingRate = _checkingAccount.InterestRate;
            double savingsRate = _savingsAccount.InterestRate;

            Assert.AreEqual(checkingRate, .0025);
            Assert.AreEqual(savingsRate, .04); 
        }

        [TestMethod]
        public void CalculateInterestRateTest()
        {
            const double EXPECTED_CHECK = 2.5;
            const double EXPECTED_SAVINGS = 40;

            _checkingAccount.Balance = 1000;
            _savingsAccount.Balance = 1000;

            double checkingAmount = _checkingAccount.GetInterestEarnedOnCalendarDate(DateTime.Now.AddMonths(1));
            double savingsAmount = _savingsAccount.GetInterestEarnedOnCalendarDate(DateTime.Now.AddMonths(1));

            Assert.AreEqual(EXPECTED_CHECK, checkingAmount);
            Assert.AreEqual(EXPECTED_SAVINGS, savingsAmount);
        }

        [TestMethod]
        public void GetAccountNumberTest()
        {
            double checkingNumber = _checkingAccount.AccountNumber;
            double savingsNumber = _savingsAccount.AccountNumber;

            Assert.AreEqual(checkingNumber, 1);
            Assert.AreEqual(savingsNumber, 2);
        }
    }
}
