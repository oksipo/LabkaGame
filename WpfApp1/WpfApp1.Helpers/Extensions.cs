using System;
using System.Collections.Generic;
using System.Linq;

namespace WpfApp1.Helpers
{
    public static class Extensions
    {
        private static Random random;

        static Extensions()
        {
            random = new Random();
        }

        public static T GetRandom<T>(this IEnumerable<T> list)
        {
            return list.ElementAt(random.Next(0, list.Count()));
        }
    }
}
