using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Services.CountDelegation
{
  public  interface ICalculationDataReader: IDisposable
    {
        bool GetDocument(string FileName, bool isVisible);
        double GetAdvance();
        string GetDestinationCity();
        string GetAppendixCell();
    }
}
