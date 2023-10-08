using System.Text;

namespace EnhancedList
{
    public class EnhancedList<T> : IEnhancedList<T>
        where T : IComparable
    {
        private List<T> data;

        public EnhancedList()
        {
            data = new List<T>();
        }

        public void Add(T element)
            => data.Add(element);

        public bool Contains(T element)
        {
            foreach (var item in data)
            {
                if (item.Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public int CountGreaterThan(T element)
        {
            var count = 0;
            foreach (var item in data)
            {
                if (item.CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public T Max()
            => GetMinMaxElement((a, b) => a.CompareTo(b) > 0);
        //{
        //    if (!data.Any())
        //    {
        //        throw new InvalidOperationException("Collection contains no elements");
        //    }

        //    var maxElement = data[0];
        //    for (int i = 1; i < data.Count; i++)
        //    {
        //        if (data[i].CompareTo(maxElement) > 0)
        //        {
        //            maxElement = data[i];
        //        }
        //    }

        //    return maxElement;
        //}

        public T Min()
            => GetMinMaxElement((a, b) => a.CompareTo(b) < 0);
        //{
        //    if (!data.Any())
        //    {
        //        throw new InvalidOperationException("Collection contains no elements");
        //    }

        //    var minElement = data[0];
        //    for (int i = 1; i < data.Count; i++)
        //    {
        //        if (data[i].CompareTo(minElement) < 0)
        //        {
        //            minElement = data[i];
        //        }
        //    }

        //    return minElement;
        //}

        public T Remove(int index)
        {
            var element = data[index];

            data.RemoveAt(index);

            return element;
        }

        public void Swap(int index1, int index2)
        {
            var buffer = data[index1];
            data[index1] = data[index2];
            data[index2] = buffer;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        private T GetMinMaxElement(Func<T, T, bool> comparator)
        {
            if (!data.Any())
            {
                throw new InvalidOperationException("Collection contains no elements");
            }

            var wantedElement = data[0];
            for (int i = 1; i < data.Count; i++)
            {
                if (comparator(data[i], wantedElement))
                {
                    wantedElement = data[i];
                }
            }

            return wantedElement;
        }
    }
}