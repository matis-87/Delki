using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Services
{
  public  interface IFillForm
    {
        string FillFormWithData(string FirstName, string Name, DateTime FromDate, DateTime ToDate, string CompanyName, string Location, string Purpose, string CashAdvance);
    }
}
