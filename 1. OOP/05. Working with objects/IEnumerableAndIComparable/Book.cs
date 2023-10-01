namespace IEnumerableAndIComparable
{
    public class Book : IComparable<Book>
    {
        public string Iban { get; private set; }

        public string Title { get; private set; }

        public int Year { get; private set; }

        public IEnumerable<string> Authors { get; private set; }

        public bool IsTaken { get; private set; }

        public Book(string iban, string title, int year, params string[] authors)
        {
            Iban = iban;
            Title = title;
            Year = year;
            Authors = authors;
            IsTaken = false;
        }

        public bool Take()
        {
            if (IsTaken)
            {
                return false;
            }

            IsTaken = true;
            return true;
        }

        public void Return()
            => IsTaken = false;

        public int CompareTo(Book other)
        {
            if (other is null)
            {
                return -1;
            }

            var result = Title.CompareTo(other.Title);
            if (result == 0)
            {
                result = Year.CompareTo(other.Year);
            }

            return result;
        }

        public override string ToString()
            => $"{Title} - {Year}";
    }
}
