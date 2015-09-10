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
            _myBankAccount = new Bank("Bank of Interest");
        }

        public BankTest()
        {
            Bank bank2 = new Bank("Bank of Interest");
            Assert.IsNotNull(bank2);
            Assert.AreEqual(bank2.Name, "Bank of Interest");
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
        public void NewAccountTest()
        {
            _myBankAccount.NewAccount("P1", 250, .00075, AccountType.Checking);
            Assert.IsTrue(_myBankAccount.Accounts[0] is CheckingAccount);

            _myBankAccount.NewAccount("P1", 250, .00075, AccountType.Savings);
            Assert.IsTrue(_myBankAccount.Accounts[1] is SavingsAccount);

            Assert.AreNotEqual(_myBankAccount.Accounts[0].AccountNumber, 
                _myBankAccount.Accounts[1].AccountNumber);
        }
    }
}
