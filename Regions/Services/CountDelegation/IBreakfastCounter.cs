using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Services.CountDelegation
{
    public interface IBreakfastCounter
    {
        int CountBreakfast(DateTime StartDelegation, DateTime EndDelegation);

    }   
}
