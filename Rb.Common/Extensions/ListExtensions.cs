using System;
using System.Collections.Generic;

namespace Rb.Common
{
    public static class ListExtensions
    {
        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            var random = new Random();
            var listCount = list.Count;
            while (listCount > 1)
            {
                listCount--;
                var k = random.Next(listCount + 1);
                var value = list[k];
                list[k] = list[listCount];
                list[listCount] = value;
            }

            return list;
        }
    }
}