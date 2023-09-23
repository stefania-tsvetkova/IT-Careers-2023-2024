using StackUsingList;

var stack = new StackOfStrings();

stack.Push("one");
stack.Push("two");
stack.Push("three");

Console.WriteLine(stack.Peek());

Console.WriteLine(stack.Pop());
Console.WriteLine(stack.Peek());

Console.WriteLine(stack.IsEmpty());

Console.WriteLine(stack.Pop());
Console.WriteLine(stack.Pop());

Console.WriteLine(stack.IsEmpty());