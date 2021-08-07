using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Services.Settings
{
 public   interface IEmployeesSaver
    {
        void SaveEmployees<T>(T Employees);
    }
}
