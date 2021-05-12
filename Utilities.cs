using System;

namespace PasswordApp
{
    class Utilities
    {
        public static int ASCII_MINIMUM_WITH_SYMBOLS = 33;
        public static int ASCII_MINIMUM_WITHOUT_SYMBOLS = 65;
        public static int ASCII_MAXIMUM_WITH_SYMBOLS = 126;
        public static int ASCII_MAXIMUM_WITHOUT_SYMBOLS = 122; 

        private static Random random;
        public static void setupRandomGenerator()
        {
            random = new Random();
        }
        public static int randomIntegerGeneration(int minimum, int maximum)
        {
            int value = random.Next(minimum, maximum);
            return value;
        }
    }
}
