using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Services.NewDelegation
{
  public  interface IEmployeeEditor
    {
        void Edit(string Firstname, string Name, string email, string acount);
    }
}
