using Microsoft.Office.Interop.Word;
using Regions.Model.NewDelegation;
using Regions.Model.Office;
using Regions.Services.CountDelegation;
using Regions.Services.NewDelegation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Model.CountDelegation
{
  public  class CalculatedDelegationDataFiller : WordEditor
    {
        const int NumberOfTableWithTravelDetails = 4;
        public CalculatedDelegationDataFiller(IWordOpener wordOpener):base(wordOpener)
        {
            
        }


        public void AddDepartureDetails(string StartedTown, DateTime StartingDate, TimeSpan StartingTime, string DestinationTown, DateTime EndingDate, TimeSpan EndingTime)
        {
            WordDocument.Tables[NumberOfTableWithTravelDetails].Cell(3, 1).Range.Text = StartedTown;
            WordDocument.Tables[NumberOfTableWithTravelDetails].Cell(3, 2).Range.Text = StartingDate.ToString("dd.MM.yy");
            WordDocument.Tables[NumberOfTableWithTravelDetails].Cell(3, 3).Range.Text = StartingTime.ToString();
            WordDocument.Tables[NumberOfTableWithTravelDetails].Cell(3, 4).Range.Text = DestinationTown;
            WordDocument.Tables[NumberOfTableWithTravelDetails].Cell(3, 5).Range.Text = EndingDate.ToString("dd.MM.yy");
            WordDocument.Tables[NumberOfTableWithTravelDetails].Cell(3, 6).Range.Text = EndingTime.ToString();
        }
        public void AddReturnDetails(string StartedTown, DateTime StartingDate, TimeSpan StartingTime, string DestinationTown, DateTime EndingDate, TimeSpan EndingTime)
        {
            WordDocument.Tables[NumberOfTableWithTravelDetails].Cell(4, 1).Range.Text = StartedTown;
            WordDocument.Tables[NumberOfTableWithTravelDetails].Cell(4, 2).Range.Text = StartingDate.ToString("dd.MM.yy");
            WordDocument.Tables[NumberOfTableWithTravelDetails].Cell(4, 3).Range.Text = StartingTime.ToString();
            WordDocument.Tables[NumberOfTableWithTravelDetails].Cell(4, 4).Range.Text = DestinationTown;
            WordDocument.Tables[NumberOfTableWithTravelDetails].Cell(4, 5).Range.Text = EndingDate.ToString("dd.MM.yy");
            WordDocument.Tables[NumberOfTableWithTravelDetails].Cell(4, 6).Range.Text = EndingTime.ToString();
        }
        public string GetDestinationCity(string DocumentText)
        {
            int Begining = DocumentText.IndexOf("do\r");
            int Ending = DocumentText.IndexOf("na czas ");
            int Length = Ending - Begining;
            string SubString = DocumentText.Substring(Begining, Length);
            string[] Strings = SubString.Split('\r');
            string City = Strings[4].Trim();
            return City;
          
        }
    }
}
