using Regions.Services;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Regions.Services.NewDelegation;
using System.Diagnostics;

namespace Regions.Model.Office
{
 public    class WordOpener : IWordOpener
    {
        public WordOpener()
        {

        }
        Document OpenedDocument;
        Microsoft.Office.Interop.Word.Application WordApp = new Microsoft.Office.Interop.Word.Application();
        public Document Open(string FileName, bool isDocumentVisible)
        {
            WordApp.Visible = isDocumentVisible;
            object fileName = FileName;
            object readOnly = false;
            object isVisible = isDocumentVisible;
            object missing = System.Reflection.Missing.Value;
            return OpenedDocument = WordApp.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
           
        }

        public void Close()
        {
            OpenedDocument?.Close();
            WordApp?.Quit();
            
        }

    }
}
