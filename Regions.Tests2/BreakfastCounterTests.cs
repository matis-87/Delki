using Regions.Model.CountDelegation;
using System;
using Xunit;

namespace Regions.Tests2
{
    public class BreakfastCounterTests
    {
        [Fact]
        public void CountBreakfast_WhenEndDelegationIsThreeDaysLater_ShouldReturnThree()
        {
            var Counter = new BreakfastCounter();

            var result = Counter.CountBreakfast(new DateTime(2021, 07, 1), new DateTime(2021, 07, 4));

            Assert.Equal(3, result);
        }

        [Fact]
        public void CountBreakfast_WhenEndDelegationIsEarlierThenStartDelegation_ShouldReturnZero()
        {
            var Counter = new BreakfastCounter();

            var result = Counter.CountBreakfast(new DateTime(2021, 07, 4), new DateTime(2021, 07, 1));

            Assert.Equal(0, result);
        }
    }
}
