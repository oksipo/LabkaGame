using System;
using System.Collections.Generic;

namespace WpfApp1.Helpers
{
    public static class Extensions
    {
        private static Random random;

        static Extensions()
        {
            random = new Random();
        }

        public static T GetRandom<T>(this List<T> list)
        {
            return list[random.Next(0, list.Count)];
        }
    }
}
