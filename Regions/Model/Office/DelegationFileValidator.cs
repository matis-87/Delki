using Microsoft.Office.Interop.Word;
using Regions.Services.Office;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Model.Office
{
  public  class DelegationFileValidator: IDelegationFileValidator
    {
        const string Title = "POTWIERDZENIE POBYTU SŁUŻBOWEGO";
        const int DesiredNumbertOfTables = 4;
        const int ExpectedRowsCount = 35;
        const int ExpectedColumnsCount = 9;

        public bool IsDocumentVerified(Document ValidatedDocument)
        {
            bool NumberOfTablesVerified = IsNumberOfTablesVerified(ValidatedDocument);
            bool TitleVerified;
            bool TravelExpenseBillTableVerified;
            if (NumberOfTablesVerified)
            {
                TitleVerified = IsDocumentTitleVerified(ValidatedDocument);
                TravelExpenseBillTableVerified = IsTravelExpenseBillTableValidated(ValidatedDocument);
            }
            else
                return false;
            return TitleVerified && TravelExpenseBillTableVerified;
        }
        public bool IsNumberOfTablesVerified(Document ValidatedDocument)
        {
            if (ValidatedDocument.Tables.Count == DesiredNumbertOfTables)
                return true;
            return false;
        }

        public bool IsDocumentTitleVerified(Document ValidatedDocument)
        {
            string ReadTitle = TryToReadTitle(ValidatedDocument);
            if (ReadTitle.Contains(Title))
                return true;
            else
                return false;
        }

        string TryToReadTitle(Document ValidatedDocument)
        {
            try
            {
                return ValidatedDocument.Tables[1].Cell(1, 2).Range.Text;
            }
            catch
            {
                return string.Empty;
            }
        }

        public bool IsTravelExpenseBillTableValidated(Document ValidatedDocument)
        {
            int Rows = ValidatedDocument.Tables[4].Rows.Count;
            int Columns = ValidatedDocument.Tables[4].Columns.Count;
            if ((Rows == ExpectedRowsCount) && (Columns == ExpectedColumnsCount))
                return true;
            return false;
        }


    }
}
