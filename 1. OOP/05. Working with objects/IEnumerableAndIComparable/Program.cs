using IEnumerableAndIComparable;

var library = new Library();

library.AddBook(new Book("234", "Book 2", 2023, "Maria", "Petar"));
library.AddBook(new Book("3456", "Book 2", 2020, "Ivan"));
library.AddBook(new Book("123", "Book 1", 2023, "Maria"));
library.AddBook(new Book("345", "Book 4", 1890, "Maria", "Ivanka"));
library.AddBook(new Book("345", "Book 4", 2000, "Maria", "Ivanka"));

foreach (var book in library)
{
    Console.WriteLine(book);
}

for (int i = 0; i < 3; i++)
{
    Console.WriteLine(library.TakeBook("345"));

    foreach (var book in library)
    {
        Console.WriteLine(book);
    }
}