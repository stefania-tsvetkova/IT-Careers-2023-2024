using Histogram.Constants;

namespace Histogram.Models
{
    public class Histogram
    {
        public IEnumerable<double> HistogramResult { get; private set; }

        public Histogram(IEnumerable<int> data)
        {
            HistogramResult = GenerateHistogram(data);
        }

        private IEnumerable<double> GenerateHistogram(IEnumerable<int> data)
        {
            var groupsElementsCount = new int[HistogramConstants.GroupsCount];
            foreach (var element in data)
            {
                var group = element / HistogramConstants.GroupSize;
                groupsElementsCount[group]++;
            }

            var dataCount = data.Count();
            var histogram = groupsElementsCount.Select(group => (double)group / dataCount * 100);

            return histogram;
        }
    }
}