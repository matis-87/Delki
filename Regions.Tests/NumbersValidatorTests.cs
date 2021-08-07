using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace Regions.Tests
{
 public   class NumbersValidatorTests
    {
        [Fact]
        public void IsNumber()
        {
          bool res =  Regex.IsMatch("1234", @"^-?[0-9][0-9,\.]+$");
            Assert.True(res);
        }
    }
}
