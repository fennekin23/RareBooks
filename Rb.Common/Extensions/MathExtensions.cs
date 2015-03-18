using System;

namespace Rb.Common
{
    public static class MathExtensions
    {
        public static int RoundOff(this int i, int number)
        {
            return ((int) Math.Round(i / (double) number)) * number;
        }

        public static long RoundOff(this long i, int number)
        {
            return ((long) Math.Round(i / (double) number)) * number;
        }
    }
}