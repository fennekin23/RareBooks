namespace Rb.Common
{
    public static class BoolExtensions
    {
        public static double ToDouble(this bool value)
        {
            return value ? 1.0 : 0.0;
        }

        public static double ToDouble(this bool? value)
        {
            return value == null
                ? 0.0
                : (bool) value ? 1.0 : -1.0;
        }
    }
}