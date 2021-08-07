using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Services.NewDelegation
{
  public  interface IAppendixDataExtractor
    {
        string ExtractProjectName(string Text);
        string ExtractProjectNumber(string Text);
    }
}
