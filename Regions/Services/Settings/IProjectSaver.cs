using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Services.Settings
{
  public  interface IProjectSaver
    {
        void SaveProject<T>(T Projects);
    }
}
