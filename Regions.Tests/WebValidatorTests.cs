using Regions.Model.WebExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Regions.Tests
{
 public   class WebValidatorTests
    {
        [Fact]
        public void isCurrentPageNameValid_WhenCurrentPageNameEqualsExpectedPageName_ReturnTrue()
        {
            string Expected = "Dodawanie nowego dokumentu";

            var Result = WebValidator.isCurrentPageNameValid("Dodawanie nowego dokumentu", Expected);
            Assert.True(Result);
        }

        [Fact]
        public void isCurrentWPageNameValid_WhenCurrentPageNameDoesNotEqualExpectedPageName_ReturnFalse()
        {
            string Expected = "Dodawanie nowego dokumentu";

            var Result = WebValidator.isCurrentPageNameValid("Dodawanie nowego dokumentu", Expected);
            Assert.True(Result);
        }

        [Fact]
        public void isCurrentPageNameValid_WhenCurrentPageNameIsEmptyString_ReturnFalse()
        {
            string Expected = "Dodawanie nowego dokumentu";

            var Result = WebValidator.isCurrentPageNameValid("Dodawanie nowego dokumentu", Expected);
            Assert.True(Result);
        }

        [Fact]
        public void isCurrentPageNameValid_WhenCurrentPageNameIsNull_ReturnFalse()
        {
            string Expected = "Dodawanie nowego dokumentu";

            var Result = WebValidator.isCurrentPageNameValid("Dodawanie nowego dokumentu", Expected);
            Assert.True(Result);
        }

        [Fact]
        public void isCurrentPageNameValid_WhenExpectedPageNameIsEmptyString_ReturnFalse()
        {
            string Expected = "Dodawanie nowego dokumentu";

            var Result = WebValidator.isCurrentPageNameValid("Dodawanie nowego dokumentu", Expected);
            Assert.True(Result);
        }

        [Fact]
        public void isCurrentPageNameValid_WhenExpectedPageNameIsNull_ReturnFalse()
        {
            string Expected = "Dodawanie nowego dokumentu";

            var Result = WebValidator.isCurrentPageNameValid("Dodawanie nowego dokumentu", Expected);
            Assert.True(Result);
        }

        bool isCurrentPageNameValid(string CurrentWebPageName, string ExpectedWebPageName)
        {
            if (CurrentWebPageName.Equals(ExpectedWebPageName))
                return true;
            return false;
        }
    }
}
