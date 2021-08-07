using Regions.Model.CountDelegation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Regions.Tests
{
 public   class TimeValidatorTests
    {
        [Fact]
       public void TimeValidator_WhenInputIsInTimeFormatHH_MM24HWithLeadingZero_ShouldReturnTrue()
        {
            var result = TimeValidator.isTimeFomratValid("02:05");
            Assert.True(result);
        }
        [Fact]
        public void TimeValidator_WhenInputIsInTimeFormat2_30_ShouldReturnTrue()
        {
            var result = TimeValidator.isTimeFomratValid("2:30");
            Assert.True(result);
        }

        [Fact]
        public void TimeValidator_WhenInputIsInTimeFormatHH_MM24HWithLeadingZeroOptional_ShouldReturnTrue()
        {
            var result = TimeValidator.isTimeFomratValid("2:02");
            Assert.True(result);
        }

        [Fact]
        public void TimeValidator_WhenInputIsInTimeFormatHH_MM24AndHIsGreaterThen23_ShouldReturnFalse()
        {
            var result = TimeValidator.isTimeFomratValid("25:05");
            Assert.False(result);
        }

        [Fact]
        public void TimeValidator_WhenInputIsInTimeFormatHH_MM24AndMIsGreaterThen59_ShouldReturnFalse()
        {
            var result =  TimeValidator.isTimeFomratValid("20:75");
            Assert.False(result);
        }

        [Fact]
        public void TimeValidator_WhenInputIsInTimeFormatHH_MM_SS24HWithLeadingZero_ShouldReturnTrue()
        {
            var result = TimeValidator.isTimeFomratValid("02:01:01");
            Assert.True(result);
        }

        [Fact]
        public void TimeValidator_WhenInputIsInTimeFormatHH_MM_SS24HWithLeadingZeroOptional_ShouldReturnTrue()
        {
            var result = TimeValidator.isTimeFomratValid("2:1:5");
            Assert.True(result);
        }

        [Fact]
        public void TimeValidator_WhenInputIsInTimeFormatHH_MM_SS24HAndHIsGrreaterThen23_ShouldReturnFalse()
        {
            var result =TimeValidator.isTimeFomratValid("25:1:5");
            Assert.False(result);
        }
        [Fact]
        public void TimeValidator_WhenInputIsInTimeFormatHH_MM_SS24HAndMIsGrreaterThen59_ShouldReturnFalse()
        {
            var result = TimeValidator.isTimeFomratValid("20:75:5");
            Assert.False(result);
        }

        [Fact]
        public void TimeValidator_WhenInputIsInTimeFormatHH_MM_SS24HAndSIsGrreaterThen59_ShouldReturnFalse()
        {
            var result = TimeValidator.isTimeFomratValid("25:10:75");
            Assert.False(result);
        }
        [Fact]
        public void TimeValidator_WhenInputIsNotInTimeFormat_ShouldReturnFalse()
        {
            var result = TimeValidator.isTimeFomratValid("dsdf");
            Assert.False(result);
        }
    }
}
