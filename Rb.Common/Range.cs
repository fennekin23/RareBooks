namespace Rb.Common
{
    public class Range
    {
        public Range(long min, long max)
        {
            Min = min;
            Max = max;
        }

        public long Max { get; set; }

        public long Min { get; set; }

        public long Size
        {
            get { return Max - Min; }
        }
    }
}