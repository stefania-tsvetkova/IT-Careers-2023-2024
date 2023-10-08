Func<string, int> parser = (string numberText) =>
{
    int result = 0;
    foreach (var digitChar in numberText)
    {
        var digit = digitChar - '0';
        result = result * 10 + digit;
    }

    return result;
};

var input = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(parser);

Console.WriteLine(input.Count());
Console.WriteLine(input.Sum());