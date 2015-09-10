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
