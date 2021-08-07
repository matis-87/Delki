using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Services.CountDelegation
{
  public  interface IPostDelegationEditor
    {
        void AddDepartureDetails(string StartedTown, DateTime StartingDate, TimeSpan StartingTime, string DestinationTown, DateTime EndingDate, TimeSpan EndingTime);
        void AddReturnDetails(string StartedTown, DateTime StartingDate, TimeSpan StartingTime, string DestinationTown, DateTime EndingDate, TimeSpan EndingTime);
        string GetDestinationCity();
        bool GetDocument(string FileName, bool isVisible);
        void AddCostSettlement(string Diet, string Accommodation, string OtherExpenses);
        void AddCalculations(string TotalExpenses, string Advance, string Results);
        void SpecifySignOfResults(string Results);
        void AddAppendix(string Appendix);
    }
}
