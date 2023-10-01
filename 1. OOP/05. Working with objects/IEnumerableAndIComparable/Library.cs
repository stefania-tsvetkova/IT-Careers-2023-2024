using System.Collections;

namespace IEnumerableAndIComparable
{
    public class Library : IEnumerable<Book>
    {
        private SortedSet<Book> books;

        public Library(params Book[] books)
        {
            this.books = new SortedSet<Book>(books);
        }

        public void AddBook(Book book)
            => books.Add(book);

        public bool TakeBook(string iban)
        {
            var book = books.FirstOrDefault(b => b.Iban == iban && !b.IsTaken);
            if (book is null)
            {
                return false;
            }

            return book.Take();
        }

        public void ReturnBook(string iban)
        {
            var book = books.FirstOrDefault(b => b.Iban == iban && b.IsTaken);
            book.Return();
        }

        public IEnumerator<Book> GetEnumerator()
        {
            foreach (var book in books)
            {
                if (!book.IsTaken)
                {
                    yield return book;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
