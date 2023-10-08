using EnhancedList;

var list = new EnhancedList<string>();

while (true)
{
    var input = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .ToArray();

    switch (input[0])
    {
        case "Add":
            HandleAddCommand(input);
            break;
        case "Remove":
            HandleRemoveCommand(input);
            break;
        case "Contains":
            HandleContainsCommand(input);
            break;
        case "Swap":
            HandleSwapCommand(input);
            break;
        case "Greater":
            HandleGreaterCommand(input);
            break;
        case "Max":
            HandleMaxCommand();
            break;
        case "Min":
            HandleMinCommand();
            break;
        case "Print":
            HandlePrintCommand();
            break;
        case "END":
            return;
    }

}

void HandleAddCommand(string[] input)
    => list.Add(input[1]);

void HandleRemoveCommand(string[] input)
{
    int index = int.Parse(input[1]);
    list.Remove(index);
}

void HandleContainsCommand(string[] input)
    => Console.WriteLine(list.Contains(input[1]));

void HandleSwapCommand(string[] input)
{
    int index1 = int.Parse(input[1]);
    int index2 = int.Parse(input[2]);

    list.Swap(index1, index2);
}

void HandleGreaterCommand(string[] input)
    => Console.WriteLine(list.CountGreaterThan(input[1]));

void HandleMaxCommand()
    => Console.WriteLine(list.Max());

void HandleMinCommand()
    => Console.WriteLine(list.Min());

void HandlePrintCommand()
    => Console.WriteLine(list);