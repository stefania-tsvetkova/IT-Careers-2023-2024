namespace StackUsingList
{
    public class StackOfStrings
    {
        private List<string> data;

        public StackOfStrings()
        {
            data = new List<string>();
        }

        public void Push(string element)
        {
            data.Add(element);
        }

        public string Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack contains no elements!");
            }

            int lastElementIndex = data.Count - 1;
            var element = data[lastElementIndex];
            data.RemoveAt(lastElementIndex);

            return element;
        }

        public string Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack contains no elements!");
            }

            int lastElementIndex = data.Count - 1;
            return data[lastElementIndex];
        }

        public bool IsEmpty()
        {
            return data.Count == 0;
        }
    }
}
