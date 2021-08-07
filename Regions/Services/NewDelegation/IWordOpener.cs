using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Services.NewDelegation
{
   public  interface IWordOpener
    {
        Document Open(string FileName, bool isDocumentVisible);
        void Close();
    }
}
