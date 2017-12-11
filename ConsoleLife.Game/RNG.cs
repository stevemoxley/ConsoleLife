using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife.Framework
{
    public static class RNG
    {
        private static readonly Random _random = new Random();

        public static Random Random
        {
            get
            {
                return _random;
            }
        }

        public static int Next(int min, int max)
        {
            return _random.Next(min, max + 1);
        }

        public static int Next(int max)
        {
            return _random.Next(max + 1);
        }

    }
}
