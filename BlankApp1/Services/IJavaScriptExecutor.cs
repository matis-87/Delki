using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Services
{
   public interface IJavaScriptExecutor
    {
        Task<string> ExecuteScript(string script);
    }
}
