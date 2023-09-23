using Animals;

Console.WriteLine("Animal:");

var animal = new Animal();
animal.Eat();

Console.WriteLine("Dog:");

var dog = new Dog();
dog.Eat();
dog.Bark();

Console.WriteLine("Puppy:");

var puppy = new Puppy();
puppy.Eat();
puppy.Bark();
puppy.Weep();

Console.WriteLine("Cat:");

var cat = new Cat();
cat.Eat();
cat.Meow();