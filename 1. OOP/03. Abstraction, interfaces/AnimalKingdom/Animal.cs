namespace AnimalKingdom
{
    public abstract class Animal : IMakeNoise, IMakeTrick
    {
        private string name;

        private int age;

        public Animal(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public virtual string MakeNoise()
            => $"My name is {name}. I am {age} old.";

        public virtual string MakeTrick()
            => "Look at my trick!";
    }
}
