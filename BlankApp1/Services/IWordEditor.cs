using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Services
{
  public  interface IWordEditor
    {
        void EditDocument(string FileName, bool isVisible, string EmployeeName, string ProjectName, string ProjectNumber);
    }
}
