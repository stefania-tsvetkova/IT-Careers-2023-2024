namespace AnimalKingdom
{
    public class Dog : Animal
    {
        public Dog(string name, int age)
            : base(name, age)
        { }

        public override string MakeNoise()
            => "Woof! " + base.MakeNoise();

        public override string MakeTrick()
            => "Hold my paw, human!";
    }
}
