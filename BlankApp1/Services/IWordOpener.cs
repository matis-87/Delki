using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Services
{
   public  interface IWordOpener
    {
        Document Open(string FileName, bool isDocumentVisible);
    }
}
