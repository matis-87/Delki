using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Regions.Model.Helper.MyExtentions;

namespace Regions.Tests2
{
    public class MyExtentionsTests
    {
        [Fact]
        public void ToTimeSpan_WhenTimeInStringApplied_ReturnsTimeSpan()
        {
            string test = "10:15:00";
            var result = test.ToTimeSpan();

            Assert.Equal(new TimeSpan(10, 15, 00), result);
        }

        [Fact]
        public void ToTimeSpan_WhenNullApplied_ReturnsTimeSpan0()
        {
            string test = null;
            var result = test.ToTimeSpan();

            Assert.Equal(new TimeSpan(0), result);
        }

        [Fact]
        public void ToTimeSpan_WhenEmptyStringApplied_ReturnsTimeSpan0()
        {
            string test = string.Empty;
            var result = test.ToTimeSpan();

            Assert.Equal(new TimeSpan(0), result);
        }

        [Fact]
        public void GetIntegralPart_When12_55IsApplied_ReturnsIntegralPart()
        {

            double TestNumber = 12.55;
            int Expected = 12;

            int Result = TestNumber.GetIntegralPart();
            Assert.Equal(Expected, Result);
        }

        [Fact]
        public void GetFractionalPart_When12_55IsApplied_ReturnsFractionalPart()
        {

            double TestNumber = 12.55;
            int Expected = 55;

            int Result = TestNumber.GetFractionalPart();
            Assert.Equal(Expected, Result);
        }

        [Fact]
        public void GetStringIntegralPart_When12_55IsApplied_ReturnsIntegralPart()
        {

            string TestNumber = "12,55";
            string Expected = "12";

            string Result = TestNumber.GetIntegralPart();
            Assert.Equal(Expected, Result);
        }
        [Fact]
        public void GetStringIntegralPart_When12_55IsApplied_ReturnsFractionalPart()
        {

            string TestNumber = "12,55";
            string Expected = "55";

            string Result = TestNumber.GetFractionalPart();
            Assert.Equal(Expected, Result);
        }

        [Fact]
        public void GetStringIntegralPart_When12_55zlIsApplied_ReturnsFractionalPartWithoutzlPArt()
        {

            string TestNumber = "12,55 zł";
            string Expected = "55";

            string Result = TestNumber.GetFractionalPart();
            Assert.Equal(Expected, Result);
        }

        [Fact]
        public void GetStringIntegralPart_WhenNoFractionalPartIsApplied_ReturnsZeroes()
        {

            string TestNumber = "12";
            string Expected = "00";

            string Result = TestNumber.GetFractionalPart();
            Assert.Equal(Expected, Result);
        }
    }
}
