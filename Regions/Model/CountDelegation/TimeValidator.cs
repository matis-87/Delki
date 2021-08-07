using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regions.Model.CountDelegation
{
   public static class TimeValidator
    {
        public static bool isTimeFomratValid(string Time)
        {
            if (Regex.IsMatch(Time, $"^([0-9]|0[0-9]|1[0-9]|2[0-3]):([0-9]|0[0-9]|1[0-9]|2[0-9]|3[0-9]|4[0-9]|5[0-9])$"))
                return true;
            return Regex.IsMatch(Time, $"^([0-9]|0[0-9]|1[0-9]|2[0-3]):([0-9]|0[0-9]|1[0-9]|2[0-9]|3[0-9]|4[0-9]|5[0-9]):([0-9]|0[0-9]|1[0-9]|2[0-9]|3[0-9]|4[0-9]|5[0-9])$");
        }
    }
}
