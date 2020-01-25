using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Runner.Extensions
{
    public static class IEnumerableExtensions
    {
        public static TValue Median<TColl, TValue>(this IEnumerable<TColl> source,Func<TColl, TValue> selector)
        {
            return source.Select(selector).Median();
        }

        public static T Median<T>(this IEnumerable<T> source)
        {
            return source.OrderBy(x => x).Skip(source.Count() / 2).First();
        }
    }
}
