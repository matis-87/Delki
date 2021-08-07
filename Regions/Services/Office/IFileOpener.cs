using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Services.Office
{
 public   interface IFileOpener
    {
        bool GetDocument(string FileName, bool isVisible);
    }
}
