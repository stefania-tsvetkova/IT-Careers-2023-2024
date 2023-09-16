namespace PersonNamespace
{
    public class BankAccount
    {
        private static int bankAccountsCount;

        public int Id { get; private set; }

        public double Balance { get; private set; }

        static BankAccount()
        {
            bankAccountsCount = 0;
        }

        public BankAccount()
        {
            Id = bankAccountsCount;
            bankAccountsCount++;
        }

        public BankAccount(double balance)
            : this()
        {
            Balance = balance;
        }

        public void Add(double amount)
        {
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            Balance -= amount;
        }
    }
}
