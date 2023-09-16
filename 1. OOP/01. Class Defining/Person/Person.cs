namespace PersonNamespace
{
    public class Person
    {
        private int age;
        private List<BankAccount> bankAccounts;

        public static int PersonCount { get; private set; }

        public string Name { get; set; }

        public int Age
        {
            get { return age; }
            set
            {
                age = value >= 0 ? value : 0;
                //if (value >= 0)
                //{
                //    age = value;
                //}
                //else
                //{
                //    age = 0;
                //}
            }
        }

        static Person()
        {
            PersonCount = 0;
        }

        public Person(string name, int age)
            : this(name, age, new List<BankAccount>())
        { }

        public Person(string name, int age, List<BankAccount> bankAccounts)
        {
            this.Name = name;
            this.Age = age;
            this.bankAccounts = bankAccounts;

            PersonCount++;
        }

        public void IntroduceYourself()
        {
            Console.WriteLine(ToString());
        }

        public void AddBankAccount(BankAccount bankAccount)
        {
            bankAccounts.Add(bankAccount);
        }

        public double GetBalance()
        {
            double balance = 0;
            foreach (var bankAccount in bankAccounts)
            {
                balance += bankAccount.Balance;
            }

            return balance;
        }

        public override string ToString()
            => $"Hello, my name's {Name} and I'm {Age} years old!";
        //{
        //    return $"Hello, my name's {Name} and I'm {Age} years old!";
        //}
    }
}
