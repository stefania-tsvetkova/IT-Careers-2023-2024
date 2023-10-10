namespace Animals
{
    public class Cat : IAnimal
    {
        public string MakeNoise()
            => "Meow";

        public string MakeTrick()
            => "No trick for you! I'm too lazy!";

        public string Perform()
            => MakeNoise() + " " + MakeTrick();
    }
}
