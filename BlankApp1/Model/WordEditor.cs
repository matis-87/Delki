using Regions.Services;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Model
{
  public  class WordEditor : IWordEditor
    {
        IWordOpener WordOpener;
        Document WordDocument;
        IUpperNameNormalize NameNormalizer;
        const string Appendix = "\nkonto: 509 \nMPK: PSPSPROD\nRodzaj:4D-KRA-3 \n\n Projekt: ";
        public WordEditor(IWordOpener wordOpener, IUpperNameNormalize nameNormalizer)
        {
            WordOpener = wordOpener;
            NameNormalizer = nameNormalizer;
        }

        public void EditDocument(string FileName, bool isVisible, string EmployeeName, string ProjectName, string ProjectNumber)
        {
            OpenDocument(FileName, isVisible);
            Activate();
            if(EmployeeOwnsDocument(NameNormalizer.NormalizeNameToUpper(EmployeeName)))
            {
                Edit(ProjectName, ProjectNumber);
                WordDocument.Save();
                if (isVisible)
                    WordDocument.ActiveWindow.Close();
            }
        }
        void OpenDocument(string FileName, bool isVisible)
        {
            WordDocument = WordOpener.Open(FileName, isVisible);
        }
        void Activate()
        {
            WordDocument.Activate();
            WordDocument.ActiveWindow.Selection.WholeStory();
            WordDocument.ActiveWindow.Selection.Copy();
        }
        bool EmployeeOwnsDocument(string Name)
        {
            if (GetDocumentText().Contains(Name))
            {
                return true;
            }
            return false;
        }
        string GetDocumentText()
        {
            return WordDocument.ActiveWindow.Selection.Text;
        }
   
        void  Edit(string ProjectName, string ProjectNumber)
        {
            string DocumentText = GetDocumentText();
            int Begining = DocumentText.IndexOf("\r\rdo");
            string SubText = DocumentText.Substring(Begining + 6, 100);
            int Ending = SubText.IndexOf("\r\r");
            Table Table = WordDocument.Tables[1];
            Cell TargetCell = Table.Cell(2, 2);
            TargetCell.Range.Text = Appendix + ProjectName + " " + ProjectNumber;
            TargetCell.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

        }

    }
}
