using Regions.Services;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Regions.Services.NewDelegation;
using Regions.Model.Office;
using Regions.Services.CountDelegation;
using Regions.Services.Office;
using static Regions.Model.Helper.MyExtentions;

namespace Regions.Model.NewDelegation
{
  public  class DelegationFileEditor : WordEditor, IPreDelegationEditor, IPostDelegationEditor, IFileOpener, ICalculationDataReader, IDisposable

    {
        IUpperNameNormalize NameNormalizer;
        IDelegationFileValidator DelegationValidator;
        const int NumberOfTableWithAppendix = 1;
        const int NumberOfTableWithTravelDetails = 4;


        public DelegationFileEditor(IWordOpener wordOpener, IUpperNameNormalize nameNormalizer, IDelegationFileValidator delegationValidator) :base(wordOpener)
        {
            NameNormalizer = nameNormalizer;
            DelegationValidator = delegationValidator;


        }

       public bool IsSecondedCorrect(string Name)
        {
            if (GetDocumentText().Contains(NameNormalizer.NormalizeNameToUpper(Name)))
            {
                return true;
            }
            return false;
        }
        public  override bool GetDocument(string FileName, bool isVisible)
        {
            bool OpeningResult = base.GetDocument(FileName, isVisible);
            bool ValidationResult = false;
            if (OpeningResult)
                ValidationResult = DelegationValidator.IsDocumentVerified(WordDocument);
            else
                return false;
           
                return ValidationResult;
        }

        public void AddAppendix(string Appendix)
        {
            WordDocument.Tables[NumberOfTableWithAppendix].Cell(2, 2).Range.Text = Appendix;
            WordDocument.Tables[NumberOfTableWithAppendix].Cell(2, 2).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
        }

        public string GetAppendixCell()
        {
            return WordDocument.Tables[NumberOfTableWithAppendix].Cell(2, 2).Range.Text;
        }


        public void AddDepartureDetails(string StartedTown, DateTime StartingDate, TimeSpan StartingTime, string DestinationTown, DateTime EndingDate, TimeSpan EndingTime)
        {
            WordDocument.Tables[NumberOfTableWithTravelDetails].Range.Cells.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

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

        public void AddCostSettlement(string Diet, string Accommodation, string OtherExpenses)
        {
            WordDocument.Tables[NumberOfTableWithTravelDetails].Cell(14, 4).Range.Text = Diet.GetIntegralPart();
            WordDocument.Tables[NumberOfTableWithTravelDetails].Cell(14, 5).Range.Text = Diet.GetFractionalPart();

            WordDocument.Tables[NumberOfTableWithTravelDetails].Cell(15, 4).Range.Text = Accommodation.GetIntegralPart();
            WordDocument.Tables[NumberOfTableWithTravelDetails].Cell(15, 5).Range.Text = Accommodation.GetFractionalPart();
            WordDocument.Tables[NumberOfTableWithTravelDetails].Cell(17, 4).Range.Text = OtherExpenses.GetIntegralPart();
            WordDocument.Tables[NumberOfTableWithTravelDetails].Cell(17, 5).Range.Text = OtherExpenses.GetFractionalPart();
        }

        public void AddCalculations(string TotalExpenses, string Advance, string Results)
        {
            WordDocument.Tables[NumberOfTableWithTravelDetails].Cell(32, 3).Range.Text = TotalExpenses.GetIntegralPart();
            WordDocument.Tables[NumberOfTableWithTravelDetails].Cell(32, 4).Range.Text = TotalExpenses.GetFractionalPart();

            WordDocument.Tables[NumberOfTableWithTravelDetails].Cell(33, 4).Range.Text = Advance.GetIntegralPart();
            WordDocument.Tables[NumberOfTableWithTravelDetails].Cell(33, 5).Range.Text = Advance.GetFractionalPart();

            WordDocument.Tables[NumberOfTableWithTravelDetails].Cell(34, 4).Range.Text = Results.GetIntegralPart();
            WordDocument.Tables[NumberOfTableWithTravelDetails].Cell(34, 5).Range.Text = Results.GetFractionalPart();

        }

        public void SpecifySignOfResults(string Results)
        {
            WordDocument.Tables[NumberOfTableWithTravelDetails].Cell(34, 3).Range.Text = Results;
        }
        public string GetDestinationCity()
        {
            string DocumentText = base.GetDocumentText();
            int Begining = DocumentText.IndexOf("do\r");
            int Ending = DocumentText.IndexOf("na czas ");
            int Length = Ending - Begining;
            if((Begining < 0 ) || (Ending < 0) || (Length <1))
                    return string.Empty;
            string SubString = DocumentText.Substring(Begining, Length);
            string[] Strings = SubString.Split('\r');
            if (Strings.Length < 4)
                return string.Empty;
            string City = Strings[4].Trim();
            return City;
        }

        public double GetAdvance()
        {
            string Text = base.GetDocumentText(); 
            int Begining = Text.IndexOf("Proszę o wypłacenie zaliczki w kwocie zł ") + 41;
            int Ending = Text.IndexOf("słownie zł . . ");
            int Length = Ending - Begining;
            if ((Begining < 0) || (Ending < 0) || (Length < 1))
                return 0;
            string RawAdvance = Text.Substring(Begining, Length);
            double Advance = Convert.ToDouble(RawAdvance.Trim());
            return Advance;
        }


        public void Dispose()
        {
            Close();
        }
    }
}
