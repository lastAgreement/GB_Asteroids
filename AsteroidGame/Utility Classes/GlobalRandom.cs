using System;

namespace AsteroidGame.UtilityClasses
{
    static class GlobalRandom
    {
        static Random random = new Random();
        public static int Next(int minValue, int maxValue) {
            return random.Next(minValue, maxValue);
        }
    }
}
