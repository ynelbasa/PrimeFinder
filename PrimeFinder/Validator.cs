namespace PrimeFinder
{
    public static class Validator
    {
        public static bool IsProductValid(long product)
        {
            var isProductTwelveDigits = product > 100000000000 && product < 999999999999;

            return isProductTwelveDigits && IsProductDigitSequencingValid(product);
        }

        private static bool IsProductDigitSequencingValid(long product)
        {
            int size = 12;
            long[] digits = new long[size];
            for (int index = size - 1; index >= 0; index--)
            {
                digits[index] = (product % 10);
                product /= 10;

                var isLastDigit = index == size - 1;
                if (!isLastDigit)
                {
                    var previousNumber = digits[index + 1];
                    var currentNumber = digits[index];

                    var isSameAsPrevious = currentNumber == previousNumber;
                    var isSequential = currentNumber == previousNumber - 1;
                    if (!isSameAsPrevious && !isSequential)
                        return false;
                }
            }

            return true;
        }
    }
}
