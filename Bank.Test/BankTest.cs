using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TDD_Bank;

namespace BankTest
{
    /// <summary>
    /// Summary description for BankTest
    /// </summary>
    [TestClass]
    public class BankTest
    {
        const double INITIAL_BALANCE = 1000.00;

        private static Bank _myBankAccount = null;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _myBankAccount = new Bank("Matthew Mills", INITIAL_BALANCE);
        }

        public BankTest()
        {
            Bank bank = new Bank();
            Assert.IsNotNull(bank);

            Bank bank2 = new Bank("Matthew Mills", 500.25);
            Assert.IsNotNull(bank);
            Assert.AreEqual(bank2.Owner, "Matthew Mills");
            Assert.AreEqual(bank2.Balance, 500.25);
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
            Assert.AreEqual(INITIAL_BALANCE, _myBankAccount.Balance);
        }

        [TestMethod]
        public void WithdrawTest()
        {
            const double AMOUNT_TO_WITHDRAW = 245.23;
            double initialAmount = _myBankAccount.Balance;
            _myBankAccount.Withdraw(AMOUNT_TO_WITHDRAW);

            Assert.AreEqual(initialAmount - AMOUNT_TO_WITHDRAW, _myBankAccount.Balance);
        }

        [TestMethod]
        public void DepositTest()
        {
            const double AMOUNT_TO_DEPOSIT = 111.11;
            double initialAmount = _myBankAccount.Balance;
            _myBankAccount.Deposit(AMOUNT_TO_DEPOSIT);

            Assert.AreEqual(initialAmount + AMOUNT_TO_DEPOSIT, _myBankAccount.Balance);
        }

        [TestMethod]
        public void OverdraftTest()
        {
            double balance = _myBankAccount.Balance;

            bool successful = _myBankAccount.Withdraw(balance + .01);

            Assert.IsFalse(successful);
        }
    }
}
