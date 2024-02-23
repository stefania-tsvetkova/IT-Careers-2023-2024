namespace SqlQueries
{
    public static class InputHelper
    {
        public static string GetInputData()
            => Console.ReadLine()
            .Split(": ")
            .Skip(1)
            .First();
    }
}
