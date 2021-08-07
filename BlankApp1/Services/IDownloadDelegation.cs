using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Services
{
 public    interface IDownloadDelegation
    {
        string DownloadWordDocument(string FirstName, string Name);
    }
}
