namespace TransportPrice
{
    public class Display
    {
        public (int distance, bool isDay) ReadUserInput()
        {
            var distance = int.Parse(Console.ReadLine());
            var dayOrNight = Console.ReadLine();
            var isDay = dayOrNight == "day";

            return (distance, isDay);
        }

        public void PrintRidePrice(double price)
        {
            Console.WriteLine($"{price:f2}");
        }
    }
}
