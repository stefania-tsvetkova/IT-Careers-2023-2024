namespace AnimalKingdom
{
    public class Cat : Animal
    {
        public Cat(string name, int age)
            : base(name, age)
        { }

        public override string MakeNoise()
            => "Meow! " + base.MakeNoise();

        public override string MakeTrick()
            => "No trick for you! I'm too lazy!";
    }
}
