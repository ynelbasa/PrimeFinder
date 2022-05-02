using FluentAssertions;
using Xunit;

namespace PrimeFinder.Tests
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-1001)]
        public void GivenZeroOrNegativeProduct_WhenIsProductValidCalled_ThenShouldReturnFalse(long product)
        {
            var isValid = Validator.IsProductValid(product);
            isValid.Should().BeFalse();
        }

        [Theory]
        [InlineData(001)]
        [InlineData(1122)]
        [InlineData(11223344)]
        public void GivenProductWithLessThan12Digits_WhenIsProductValidCalled_ThenShouldReturnFalse(long product)
        {
            var isValid = Validator.IsProductValid(product);
            isValid.Should().BeFalse();
        }

        [Theory]
        [InlineData(0012345678910)]
        [InlineData(1122334455667788)]
        public void GivenProductWithMoreThan12Digits_WhenIsProductValidCalled_ThenShouldReturnFalse(long product)
        {
            var isValid = Validator.IsProductValid(product);
            isValid.Should().BeFalse();
        }

        [Theory]
        [InlineData(113445566777)]
        [InlineData(998876554321)]
        [InlineData(112344556567)]
        [InlineData(111224445678)]
        public void GivenDigitsNotSequentiallyAscendingOrEqual_WhenIsProductValidCalled_ThenShouldReturnFalse(long product)
        {
            var isValid = Validator.IsProductValid(product);
            isValid.Should().BeFalse();
        }

        [Theory]
        [InlineData(122333455667)]
        [InlineData(122334456789)]
        [InlineData(777788889999)]
        public void GivenProductSequenceAndLengthIsValid_WhenIsProductValidCalled_ThenShouldReturnTrue(long product)
        {
            var isValid = Validator.IsProductValid(product);
            isValid.Should().BeTrue();
        }
    }
}