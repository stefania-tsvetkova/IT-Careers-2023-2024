var input = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse);

var inputLength = input.Count();
int k = inputLength / 4;

var part1 = input.Take(k);
var part2 = input.Skip(k).Take(2 * k);
var part3 = input.Skip(3 * k);

var upperRow = part1
    .Reverse()
    .Concat(part3.Reverse())
    .ToArray();

var lowerRow = part2.ToArray();

for (int i = 0; i < 2 * k; i++)
{
    Console.Write(upperRow[i] + lowerRow[i]);

    if (i < 2 * k - 1)
    {
        Console.Write(" ");
    }
}