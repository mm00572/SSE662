namespace TDD_Bank
{
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(string owner, double amount, double interestRate, long accountNumber) :
            base(owner, amount, interestRate, accountNumber)
        {
        }
    }
}
