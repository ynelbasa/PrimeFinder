namespace PrimeFinder
{
    public static class PrimeFinder
    {
        public static IEnumerable<int> GetPrimesWithinRange(int min, int max)
        {
            var isMinMaxNegative = min < 0 || max < 0;
            var isMinGreaterThanMax = min > max;
            var isMinEqualsMax = min == max;
            if (isMinMaxNegative || isMinGreaterThanMax || isMinEqualsMax)
            {
                throw new ArgumentException($"{nameof(PrimeFinder)}: {nameof(GetPrimesWithinRange)}:" +
                    $"Invalid parameter supplied.");
            };

            var primesWithinRange = new List<int>();

            for (int number = min; number <= max; number++)
            {
                if (IsPrime(number))
                {
                    primesWithinRange.Add(number);
                }
            }

            return primesWithinRange;
        }

        /// <summary>
        /// Checks the primality of a given number using trial division method
        /// Tests whether number is a multiple of any integer between 2 and sqrt(number)
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static bool IsPrime(int number)
        {
            var possibleFactors = Math.Sqrt(number);

            var lowestFactor = 2;
            for (var factor = lowestFactor; factor <= possibleFactors; factor++)
            {
                if (number % factor == 0)
                {
                    return false;
                }
            }

            // Exhausted all factors so we know this number is prime
            return true;
        }
    }
}
