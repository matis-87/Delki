using Regions.Services;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Model
{
 public    class WordOpener : IWordOpener
    {
        public WordOpener()
        {

        }
        public Document Open(string FileName, bool isDocumentVisible)
        {
            Microsoft.Office.Interop.Word.Application WordApp = new Microsoft.Office.Interop.Word.Application();
            WordApp.Visible = isDocumentVisible;
            object fileName = FileName;
            object readOnly = false;
            object isVisible = isDocumentVisible;
            object missing = System.Reflection.Missing.Value;
            return  WordApp.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);

        }
    }
}
