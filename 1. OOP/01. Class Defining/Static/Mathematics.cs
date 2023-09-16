namespace Static
{
    public static class Mathematics
    {
        private static Dictionary<int, double> squareRoots;

        static Mathematics()
        {
            squareRoots = new Dictionary<int, double>();
        }

        public static int Add(int a, int b)
            => a + b;

        public static int Multiply(int a, int b)
            => a * b;

        public static double Sqrt(int number)
        {
            if (squareRoots.ContainsKey(number))
            {
                return squareRoots[number];
            }

            var squareRoot = Math.Sqrt(number);
            squareRoots.Add(number, squareRoot);

            return squareRoot;
        }
    }
}
