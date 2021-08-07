using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Services.NewDelegation
{
  public  interface IMailContentGenerator
    {
        string GetContentWithBankTransfer(string FirstName, string Name, string Company, string Account);
        string GetReguralContent(string Company);
    }
}
