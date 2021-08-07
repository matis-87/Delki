using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Services.CountDelegation
{
 public   interface ICountDelegationTemplateGenerator
    {
        string FillFomrWithData(DateTime StartOfDelegation, TimeSpan TimeOfStartDelegation, DateTime EndOfDelegation, TimeSpan TimeOfEndDelegation, int NumbersOfBreakfast, string CostOfAccommodation, string Advance, string OtherExpenses);
        string GetCalculations();
    }
}
