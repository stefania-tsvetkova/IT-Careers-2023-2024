namespace Histogram
{
    public class Display
    {
        public IEnumerable<int> ReadData()
        {
            var dataCount = int.Parse(Console.ReadLine());

            var data = new int[dataCount];
            for (int i = 0; i < dataCount; i++)
            {
                data[i] = int.Parse(Console.ReadLine());
            }

            return data;
        }

        public void PrintHistogram(IEnumerable<double> histogram)
        {
            foreach (var element in histogram)
            {
                Console.WriteLine($"{element:f2}%");
            }
        }
    }
}
