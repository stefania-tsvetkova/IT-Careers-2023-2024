var input = Console.ReadLine();

try
{
    var number = int.Parse(input);
    var squareRoot = Sqrt(number);
    Console.WriteLine($"Square root of {number} is {squareRoot}");
}
catch (ArgumentOutOfRangeException)
{
    Console.WriteLine("Invalid number");
}
catch (FormatException)
{
    Console.WriteLine("Invalid number");
}
finally
{
    Console.WriteLine("Good bye");
}

double Sqrt(int number)
{
    if (number < 0)
    {
        throw new ArgumentOutOfRangeException("Number should be non-negative");
    }

    return Math.Sqrt(number);
}