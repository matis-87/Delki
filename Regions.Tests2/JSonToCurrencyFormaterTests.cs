using Regions.Model.CountDelegation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Regions.Tests2
{
    public class JSonToCurrencyFormaterTests
    {
        [Fact]
        public void JSonToCurrency_WhenAppliedValidValue_ReturnsStringInCurrencyFormat()
        {

            string result = JSonToCurrencyFormater.JSonToCurrency("\"9.790,00 zł\"");

            Assert.Equal("9790.00 zł", result);
        }

        [Fact]
        public void JSonToCurrency_WhenNonJSONApplied_ReturnsEmptyString()
        {

            string result = JSonToCurrencyFormater.JSonToCurrency("werfgvc");

            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void JSonToCurrency_WhenNonComaFound_ReturnsStringInCurrencyFormat()
        {

            string result = JSonToCurrencyFormater.JSonToCurrency("\"9790,00 zł\"");

            Assert.Equal("9790.00 zł", result);
        }
    }
}
