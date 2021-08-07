using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Model.Helper
{
  public static  class Helpers
    {
      public static  TimeSpan CalculateEndOfTravel(TimeSpan StartTime, TimeSpan Duration)
        {
            return StartTime.Add(Duration);
        }

      //  public static bool IsNumber(string )
    }
}
