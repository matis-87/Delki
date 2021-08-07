using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Services.NewDelegation
{
  public  interface IMailCreator
    {
        void CreateMail(string Name, string Recipient, string Company, string AttachedFileName);
        void CreateMailWithTransfer(string FirstName, string Name, string CarbonCopy, string Recipient, string Company, string AccountNumber, string AttachedFileName);
    }
}
