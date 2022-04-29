using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PrimeFinder.Tests
{
    public class PrimeFinderTests
    {
        [Theory]
        [InlineData(-2, 0)]
        [InlineData(0, -2)]
        [InlineData(-4, -2)]
        public void GivenNegativeMinMax_WhenGetPrimesWithinRangeCalled_ShouldReturnNull(int min, int max)
        {
            Action act = () => PrimeFinder.GetPrimesWithinRange(min, max);
            act.Should().ThrowExactly<ArgumentException>();
        }

        [Theory]
        [InlineData(2, 0)]
        [InlineData(6, 4)]
        public void GivenMinIsGreaterThanMax_WhenGetPrimesWithinRangeCalled_ShouldReturnNull(int min, int max)
        {
            Action act = () => PrimeFinder.GetPrimesWithinRange(min, max);
            act.Should().ThrowExactly<ArgumentException>();
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        public void GivenMinIsEqualMax_WhenGetPrimesWithinRangeCalled_ShouldReturnNull(int min, int max)
        {
            Action act = () => PrimeFinder.GetPrimesWithinRange(min, max);
            act.Should().ThrowExactly<ArgumentException>();
        }

        [Fact]
        public void GivenValidRange_WhenGetPrimesWithinRangeCalled_ShouldReturnCorrectListOfPrimes()
        {
            var expectedPrimes = new List<int> { 1, 2, 3, 5, 7, 11, 13, 17, 19 };
            var primes = PrimeFinder.GetPrimesWithinRange(1, 20);
            primes.Should().BeEquivalentTo(expectedPrimes);
        }
    }
}
