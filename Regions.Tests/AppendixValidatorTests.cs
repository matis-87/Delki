using Regions.Model.NewDelegation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Regions.Tests
{
   public class AppendixValidatorTests
    {
        [Fact]
        public void IsAppendixValid_WhenStringIsEmpty_ReturnsFalse()
        {
            var Validator =new  AppendixValidator();
            var result = Validator.IsAppendixValid(string.Empty);
            Assert.False(result);
        }

        [Fact]
        public void IsAppendixValid_WhenStringIsNull_ReturnsFalse()
        {
            var Validator = new AppendixValidator();
            var result = Validator.IsAppendixValid(null);
            Assert.False(result);
        }

        [Fact]
        public void IsAppendixValid_WhenStringDoesNotContainFullAppendix_ReturnsFalse()
        {
            string AppendixBase = "\nkonto: 509 \nMPK: PSPSPROD\nRodzaj:4D-KRA";
            var Validator = new AppendixValidator();
            var result = Validator.IsAppendixValid(AppendixBase);
            Assert.False(result);
        }

        [Fact]
        public void IsAppendixValid_WhenStringContainsFullAppendix_ReturnsTrue()
        {
            string AppendixBase = "\rkonto: 509 \rMPK: PSPSPROD\rRodzaj: 4D - KRA-3 \r\r Projekt: TrendGlass Mover TUT042 / 20\r\a";
            var Validator = new AppendixValidator();
            var result = Validator.IsAppendixValid(AppendixBase);
            Assert.True(result);
        }


    }
}
