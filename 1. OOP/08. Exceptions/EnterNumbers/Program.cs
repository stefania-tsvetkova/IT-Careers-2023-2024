int ReadNumber(int start, int end)
{
    var input = Console.ReadLine();

    int number;
    try
    {
        number = int.Parse(input);
    }
    catch (FormatException ex)
    {
        throw new FormatException($"{input} is not a number", ex);
    }

    if (number < start || number > end)
    {
        throw new ArgumentOutOfRangeException($"The number should be in the range [{start}, {end}]");
    }

    return number;
}

int start = 2, end = 99;
for (int i = 0; i < 10; i++)
{
    try
    {
        var currentNumber = ReadNumber(start, end);
        start = currentNumber + 1;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        i--;
    }
}