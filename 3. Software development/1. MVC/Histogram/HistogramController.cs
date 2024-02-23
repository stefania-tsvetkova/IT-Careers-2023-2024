using HistogramModel = Histogram.Models.Histogram;

namespace Histogram
{
    public class HistogramController
    {
        private Display display;

        public HistogramController()
        {
            display = new Display();
        }

        public void Start()
        {
            var data = display.ReadData();

            var dataHistogram = new HistogramModel(data);

            display.PrintHistogram(dataHistogram.HistogramResult);
        }
    }
}
