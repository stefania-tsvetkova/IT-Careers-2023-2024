char[] wordDelimiters = new[] { '.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '/', '\\', '!', '?', ' ' };

var words = Console.ReadLine()
    .Split(wordDelimiters, StringSplitOptions.RemoveEmptyEntries)
    .Where(word => word.Length < 5)
    .Select(word => word.ToLower())
    .Distinct()
    .OrderBy(word => word);

Console.WriteLine(string.Join(", ", words));