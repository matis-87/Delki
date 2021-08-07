using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Services.NewDelegation
{
  public  interface IDelegationGenerator
    {
       Task GenerateDelegation(string name, DateTime FromDate, DateTime ToDate, string CompanyName, string Location, string Purpose, string CashAdvance);
    }
}
