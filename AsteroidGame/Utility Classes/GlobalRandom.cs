using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame
{
    static class GlobalRandom
    {
        static Random random = new Random();
        public static int Next(int minValue, int maxValue) {
            return random.Next(minValue, maxValue);
        }
    }
}
