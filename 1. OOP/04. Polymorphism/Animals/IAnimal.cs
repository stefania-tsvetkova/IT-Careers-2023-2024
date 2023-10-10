namespace Animals
{
    public interface IAnimal : IMakeNoise, IMakeTrick
    {
        string Perform();
    }
}
