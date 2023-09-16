using PersonNamespace;

var person = new Person("Ivan", 18);

person.IntroduceYourself();

person.Age++; //person.Age = person.Age + 1;

person.IntroduceYourself();

var bankAccount1 = new BankAccount();
bankAccount1.Add(100);

Console.WriteLine(bankAccount1.Id);

var bankAccount2 = new BankAccount(50);
bankAccount2.Add(150);

Console.WriteLine(bankAccount2.Id);

person.AddBankAccount(bankAccount1);
person.AddBankAccount(bankAccount2);

Console.WriteLine(person.GetBalance());

bankAccount1.Withdraw(100);

Console.WriteLine(person.GetBalance());

Console.WriteLine(Person.PersonCount);

var person2 = new Person("Mimi", 15);

Console.WriteLine(Person.PersonCount);
