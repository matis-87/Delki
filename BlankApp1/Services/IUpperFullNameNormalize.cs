using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Services
{
  public   interface IUpperFullNameNormalize
    {
        string NormalizeToUpper(string FirstName, string Name);
    }
}
