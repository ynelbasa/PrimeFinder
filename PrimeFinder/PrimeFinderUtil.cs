namespace PrimeFinder
{
    public static class PrimeFinderUtil
    {
        /// <summary>
        /// Return primary numbers within the range of the minimum and maximum number supplied
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int[] GetPrimesWithinRange(int min, int max)
        {
            var isMinMaxNegative = min < 0 || max < 0;
            var isMinGreaterThanMax = min > max;
            var isMinEqualsMax = min == max;
            if (isMinMaxNegative || isMinGreaterThanMax || isMinEqualsMax)
            {
                throw new ArgumentException($"{nameof(PrimeFinderUtil)}: {nameof(GetPrimesWithinRange)}:" +
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

            return primesWithinRange.ToArray();
        }

        private static int[] PrimeNumbers { get; set; }

        /// <summary>
        /// Find 4 prime numbers whose product meets the following requirements:
        /// Length is 12, digits are either in ascending order or same as previous
        /// </summary>
        /// <param name="primes"></param>
        public static void Solve(int[] primeNumbers)
        {
            PrimeNumbers = primeNumbers;
            SearchCombination(index: 1, currentCombination: new List<int>(), product: 1);
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

        /// <summary>
        /// Traverse through list of prime numbers (PrimeNumbers) and check if product meets criteria
        /// </summary>
        /// <param name="index"></param>
        /// <param name="currentCombination"></param>
        /// <param name="product"></param>
        private static void SearchCombination(int index, List<int> currentCombination, long product)
        {
            if (index >= PrimeNumbers.Length) return;

            if (currentCombination.Count < 4)
            {
                for (var i = index; i < PrimeNumbers.Length; i++)
                {
                    currentCombination.Add(PrimeNumbers[i]);
                    SearchCombination(i + 1, currentCombination, product * PrimeNumbers[i]);
                    currentCombination.RemoveAt(currentCombination.Count - 1);
                }
            }

            if (Validator.IsProductValid(product))
            {
                Console.WriteLine($"Primes: { string.Join(",", currentCombination)}");
                Console.WriteLine($"Product: { product }");
            }
        }
    }
}
