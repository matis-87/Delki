using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Services.Office
{
 public   interface IDelegationFileValidator
    {
        bool IsDocumentVerified(Document ValidatedDocument);
    }
}
