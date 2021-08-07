using Microsoft.Office.Interop.Word;
using Regions.Services.NewDelegation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Model.Office
{
    public class WordEditor
    {
        protected IWordOpener WordOpener;
        protected Document WordDocument;
        public WordEditor(IWordOpener wordOpener)
        {
            WordOpener = wordOpener;
        }

        public virtual bool GetDocument(string FileName, bool isVisible)
        {

             bool result = TryToGetDocument(FileName, isVisible);
            if (result)
                Activate();
            return result;

        }

        protected bool TryToGetDocument(string FileName, bool isVisible)
        {
            try
            {
                WordDocument = WordOpener.Open(FileName, isVisible);
            }
            catch
            {
                return false;
            }
            if (WordDocument == null)
                return false;
            return true;
        }

        protected void Activate()
        {
            WordDocument.Activate();
        }

        public virtual string GetDocumentText()
        {
            WordDocument.ActiveWindow.Selection.WholeStory();
            WordDocument.ActiveWindow.Selection.Copy();
            return WordDocument.ActiveWindow.Selection.Text;
        }

        public virtual void Close()
        {
            WordDocument?.Save();
            WordOpener?.Close();
            
        }
    }
}
