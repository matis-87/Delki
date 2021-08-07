using Regions.Services.CountDelegation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Model.CountDelegation
{
 public   class BreakfastCounter : IBreakfastCounter
    {
        public int CountBreakfast(DateTime StartDelegation, DateTime EndDelegation)
        {

            TimeSpan Result = EndDelegation.Subtract(StartDelegation);
            if (Result.Days < 0)
                return 0;
            return Result.Days;
        }
    }
}
